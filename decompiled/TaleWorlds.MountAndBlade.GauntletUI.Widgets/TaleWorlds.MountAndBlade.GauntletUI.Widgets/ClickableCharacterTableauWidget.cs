using System.Runtime.CompilerServices;
using TaleWorlds.GauntletUI;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.GauntletUI.Widgets;

public class ClickableCharacterTableauWidget : CharacterTableauWidget
{
	private const float DragThreshold = 5f;

	private float _dragThresholdSqr;

	private bool _isMouseDown;

	private bool _isDragging;

	private Vec2 _mousePressPos;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClickableCharacterTableauWidget(UIContext context)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnUpdate(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMousePressed()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseReleased()
	{
		throw null;
	}
}
