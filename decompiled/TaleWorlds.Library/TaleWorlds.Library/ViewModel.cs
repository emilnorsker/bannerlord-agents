using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TaleWorlds.Library;

public abstract class ViewModel : IViewModel, INotifyPropertyChanged
{
	public interface IViewModelGetterInterface
	{
		bool IsValueSynced(string name);

		Type GetPropertyType(string name);

		object GetPropertyValue(string name);

		void OnFinalize();
	}

	public interface IViewModelSetterInterface
	{
		void SetPropertyValue(string name, object value);

		void OnFinalize();
	}

	private class DataSourceTypeBindingPropertiesCollection
	{
		public Dictionary<string, PropertyInfo> Properties
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		public Dictionary<string, MethodInfo> Methods
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				throw null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public DataSourceTypeBindingPropertiesCollection(Dictionary<string, PropertyInfo> properties, Dictionary<string, MethodInfo> methods)
		{
			throw null;
		}
	}

	public static bool UIDebugMode;

	private List<PropertyChangedEventHandler> _eventHandlers;

	private List<PropertyChangedWithValueEventHandler> _eventHandlersWithValue;

	private List<PropertyChangedWithBoolValueEventHandler> _eventHandlersWithBoolValue;

	private List<PropertyChangedWithIntValueEventHandler> _eventHandlersWithIntValue;

	private List<PropertyChangedWithFloatValueEventHandler> _eventHandlersWithFloatValue;

	private List<PropertyChangedWithUIntValueEventHandler> _eventHandlersWithUIntValue;

	private List<PropertyChangedWithColorValueEventHandler> _eventHandlersWithColorValue;

	private List<PropertyChangedWithDoubleValueEventHandler> _eventHandlersWithDoubleValue;

	private List<PropertyChangedWithVec2ValueEventHandler> _eventHandlersWithVec2Value;

	private Type _type;

	private DataSourceTypeBindingPropertiesCollection _propertiesAndMethods;

	private static Dictionary<Type, DataSourceTypeBindingPropertiesCollection> _cachedViewModelProperties;

	public event PropertyChangedEventHandler PropertyChanged
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			throw null;
		}
	}

	public event PropertyChangedWithValueEventHandler PropertyChangedWithValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			throw null;
		}
	}

	public event PropertyChangedWithBoolValueEventHandler PropertyChangedWithBoolValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			throw null;
		}
	}

	public event PropertyChangedWithIntValueEventHandler PropertyChangedWithIntValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			throw null;
		}
	}

	public event PropertyChangedWithFloatValueEventHandler PropertyChangedWithFloatValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			throw null;
		}
	}

	public event PropertyChangedWithUIntValueEventHandler PropertyChangedWithUIntValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			throw null;
		}
	}

	public event PropertyChangedWithColorValueEventHandler PropertyChangedWithColorValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			throw null;
		}
	}

	public event PropertyChangedWithDoubleValueEventHandler PropertyChangedWithDoubleValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			throw null;
		}
	}

	public event PropertyChangedWithVec2ValueEventHandler PropertyChangedWithVec2Value
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
			throw null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
			throw null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected ViewModel()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private PropertyInfo GetProperty(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected bool SetField<T>(ref T field, T value, string propertyName)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPropertyChangedWithValue<T>(T value, [CallerMemberName] string propertyName = null) where T : class
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPropertyChangedWithValue(bool value, [CallerMemberName] string propertyName = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPropertyChangedWithValue(int value, [CallerMemberName] string propertyName = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPropertyChangedWithValue(float value, [CallerMemberName] string propertyName = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPropertyChangedWithValue(uint value, [CallerMemberName] string propertyName = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPropertyChangedWithValue(Color value, [CallerMemberName] string propertyName = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPropertyChangedWithValue(double value, [CallerMemberName] string propertyName = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void OnPropertyChangedWithValue(Vec2 value, [CallerMemberName] string propertyName = null)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetViewModelAtPath(BindingPath path, bool isList)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetViewModelAtPath(BindingPath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static object GetChildAtPath(IMBBindingList bindingList, BindingPath path)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetPropertyValue(string name, PropertyTypeFeeder propertyTypeFeeder)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public object GetPropertyValue(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Type GetPropertyType(string name)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetPropertyValue(string name, object value)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void OnFinalize()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ExecuteCommand(string commandName, object[] parameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private bool AreParametersCompatibleWithMethod(object[] parameters, ParameterInfo[] methodParameters)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static object ConvertValueTo(string value, Type parameterType)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public virtual void RefreshValues()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RefreshPropertyAndMethodInfos()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly[] GetViewModelAssemblies()
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static DataSourceTypeBindingPropertiesCollection GetPropertiesOfType(Type t)
	{
		throw null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ViewModel()
	{
		throw null;
	}
}
