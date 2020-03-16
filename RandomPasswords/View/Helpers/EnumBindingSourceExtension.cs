﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace RandomPasswords.View
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
		private Type _enumType;

		public Type EnumType
		{
			get { return _enumType; }
			set 
			{ 
				if (value != _enumType)
				{
					if (null != _enumType)
					{
						Type enumType = Nullable.GetUnderlyingType(value) ?? value;

						if (!enumType.IsEnum)
							throw new ArgumentException("Type must be for an Enum.");
					}
					_enumType = value; 
				}
			}
		}

		public EnumBindingSourceExtension() {}

		public EnumBindingSourceExtension(Type enumType)
		{
			EnumType = enumType;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (null == _enumType)
				throw new InvalidOperationException("The EnumType must be specified.");

			Type actualEnumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;
			Array enumValues = Enum.GetValues(actualEnumType);

			if (actualEnumType == _enumType)
				return enumValues;

			Array array = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
			enumValues.CopyTo(array, 1);
			return array;
		}
	}
}
