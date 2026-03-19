# Gauntlet Layout: Decompiled Source Evidence

Decompiled from `TaleWorlds.GauntletUI.dll` (random_logs branch, `.github/workflows/dlls/`).

## 1. Widget.SetLayout — HorizontalAlignment controls position

**File:** `TaleWorlds.GauntletUI.BaseTypes/Widget.cs` (decompiled)

```csharp
private void SetLayout(float left, float bottom, float right, float top)
{
    left += ScaledMarginLeft;
    right -= ScaledMarginRight;
    top += ScaledMarginTop;
    bottom -= ScaledMarginBottom;
    float num = right - left;
    float num2 = bottom - top;
    float left2 = ((HorizontalAlignment == HorizontalAlignment.Left) ? left : 
        ((HorizontalAlignment != HorizontalAlignment.Center) ? (right - MeasuredSize.X) : 
        (left + num / 2f - MeasuredSize.X / 2f)));
    float top2 = ((VerticalAlignment == VerticalAlignment.Top) ? top : ...);
    Left = left2;
    Top = top2;
    Size = MeasuredSize;
}
```

**Implication:** For a child with `MeasuredSize.X` smaller than the layout box:
- **Left:** `Left = left` (align to left edge)
- **Center:** `Left = left + (right-left)/2 - MeasuredSize.X/2` (centered)
- **Right:** `Left = right - MeasuredSize.X` (align to right edge)

## 2. StackLayout.LayoutLinearVertical — VerticalBottomToTop gives full width to each child

**File:** `TaleWorlds.GauntletUI.Layout/StackLayout.cs` (decompiled)

```csharp
private void LayoutLinearVertical(Widget widget, float left, float bottom, float right, float top)
{
    // ...
    float left2 = 0f;
    float right2 = right - left;   // full width
    // ...
    for (int j = 0; j < widget.ChildCount; j++)
    {
        Widget child2 = widget.GetChild(j);
        // ...
        child2.Layout(left2, num2, right2, num);  // child gets (0, right2) = full width
    }
}
```

**Implication:** Each child receives a layout box spanning the full width. The child’s `HorizontalAlignment` and `MeasuredSize.X` then determine its final position via `Widget.SetLayout`.

## 3. StackLayout.MeasureLinear — CoverChildren vs StretchToParent

**File:** `TaleWorlds.GauntletUI.Layout/StackLayout.cs` (decompiled)

```csharp
case AlignmentAxis.Vertical:
    if (child.HeightSizePolicy == SizePolicy.StretchToParent)
    {
        num4++;
        num3 += itemDescription.HeightStretchRatio;
    }
    else
    {
        num += child.MeasuredSize.Y + child.ScaledMarginTop + child.ScaledMarginBottom;
    }
    num2 = MathF.Max(num2, child.MeasuredSize.X + child.ScaledMarginLeft + child.ScaledMarginRight);
    break;
```

For vertical layout, the perpendicular (horizontal) size is `num2 = MathF.Max(num2, child.MeasuredSize.X + ...)`. Children with `WidthSizePolicy.CoverChildren` use their content width; children with `StretchToParent` get the parent’s width from the measure spec.

**Implication:** With `CoverChildren`, `MeasuredSize.X` is the content width. With `StretchToParent`, `MeasuredSize.X` equals the available width. So:
- **CoverChildren:** narrow width → if `HorizontalAlignment` is Center (or default), content is centered.
- **StretchToParent:** full width → child fills the row; `TextHorizontalAlignment` on the inner `TextWidget` controls text alignment.

## 4. HorizontalAlignment enum default

**File:** `TaleWorlds.GauntletUI/HorizontalAlignment.cs`

```csharp
public enum HorizontalAlignment
{
    Left,    // 0
    Center,  // 1
    Right    // 2
}
```

Uninitialized enum fields default to 0 (`Left`). XML/prefab parsing may override this.

## 5. TextWidget/RichTextWidget — Brush wins over widget attribute

**File:** `TaleWorlds.GauntletUI.BaseTypes/TextWidget.cs` (decompiled)

```csharp
protected void RefreshTextParameters()
{
    _text.HorizontalAlignment = base.ReadOnlyBrush.TextHorizontalAlignment;
    // ...
}
```

**Implication:** Text alignment comes from the brush, not from a widget attribute. Use `Brush.TextHorizontalAlignment="Left"` or `Brush.TextHorizontalAlignment="Right"` on the TextWidget to override the brush default.

## 6. Fix rationale

The ContentSegments `ItemTemplate` root had `WidthSizePolicy="CoverChildren"`:
- Child measured to content width.
- `Widget.SetLayout` positions it using `HorizontalAlignment` and `MeasuredSize.X`.
- If `HorizontalAlignment` is Center (or effectively centered by layout), the narrow content is centered in the row.

Changing to `WidthSizePolicy="StretchToParent"`:
- Child gets full row width from the measure spec.
- `MeasuredSize.X` = full width.
- `Widget.SetLayout`: for Left, `Left = left` and `Size.X = MeasuredSize.X` → child spans full width.
- Inner `TextWidget` with `Brush.TextHorizontalAlignment="Left"` or `"Right"` then aligns text within that full-width area.

## Checklist: Keep NPC left, Player right

| Layer | NPC (left) | Player (right) |
|-------|------------|----------------|
| `ListPanel` | `HorizontalAlignment="Left"` | `HorizontalAlignment="Right"` |
| ContentSegments `ItemTemplate` root | `WidthSizePolicy="StretchToParent"` | `WidthSizePolicy="StretchToParent"` |
| Body/pill container | `HorizontalAlignment="Left"` | `HorizontalAlignment="Right"` |
| `TextWidget` | `Brush.TextHorizontalAlignment="Left"` | `Brush.TextHorizontalAlignment="Right"` |

The brush must be overridden: `TextWidget` uses `ReadOnlyBrush.TextHorizontalAlignment`, so the widget attribute must be `Brush.TextHorizontalAlignment="Left"` (not `TextHorizontalAlignment="Left"`).
