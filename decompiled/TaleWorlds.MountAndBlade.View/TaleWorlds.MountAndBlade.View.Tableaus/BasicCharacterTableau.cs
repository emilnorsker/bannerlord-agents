using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace TaleWorlds.MountAndBlade.View.Tableaus;

public class BasicCharacterTableau
{
	private static int _tableauIndex;

	private bool _isVersionCompatible;

	private const int _expectedCharacterCodeVersion = 4;

	private bool _initialized;

	private int _tableauSizeX;

	private int _tableauSizeY;

	private float RenderScale;

	private float _cameraRatio;

	private List<string> _equipmentMeshes;

	private List<bool> _equipmentHasColors;

	private List<bool> _equipmentHasGenderVariations;

	private List<bool> _equipmentHasTableau;

	private uint _clothColor1;

	private uint _clothColor2;

	private MatrixFrame _mountSpawnPoint;

	private MatrixFrame _initialSpawnFrame;

	private Scene _tableauScene;

	private SkinMask _skinMeshesMask;

	private bool _isFemale;

	private string _skeletonName;

	private string _characterCode;

	private UnderwearTypes _underwearType;

	private string _mountMeshName;

	private string _mountCreationKey;

	private string _mountMaterialName;

	private uint _mountManeMeshMultiplier;

	private BodyMeshTypes _bodyMeshType;

	private HairCoverTypes _hairCoverType;

	private BeardCoverTypes _beardCoverType;

	private BodyDeformTypes _bodyDeformType;

	private string _mountSkeletonName;

	private string _mountIdleAnimationName;

	private string _mountHarnessMeshName;

	private string _mountReinsMeshName;

	private string[] _maneMeshNames;

	private bool _mountHarnessHasColors;

	private bool _isFirstFrame;

	private float _faceDirtAmount;

	private float _mainCharacterRotation;

	private bool _isVisualsDirty;

	private bool _isRotatingCharacter;

	private bool _isEnabled;

	private int _race;

	private readonly GameEntity[] _currentCharacters;

	private readonly GameEntity[] _currentMounts;

	private int _currentEntityToShowIndex;

	private bool _checkWhetherEntitiesAreReady;

	private BodyProperties _bodyProperties;

	private Banner _banner;

	public Texture Texture
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private set
		{
			throw null;
		}
	}

	public bool IsVersionCompatible
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	private TableauView View
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public BasicCharacterTableau()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnTick(float dt)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UpdateCharacterRotation(int mouseMoveX)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SetEnabled(bool enabled)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetTargetSize(int width, int height)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DeserializeCharacterCode(string code)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ResetProperties()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void FirstTimeInit()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void ApplyBannerTextureToMesh(Mesh armorMesh, Texture bannerTexture)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void RefreshCharacterTableau()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void SetCamera()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RotateCharacter(bool value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetBannerCode(string value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void CharacterTableauContinuousRenderFunction(Texture sender, EventArgs e)
	{
		throw null;
	}
}
