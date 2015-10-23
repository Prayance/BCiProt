using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace BCiProt.DataModel
{
    /// <summary>
    /// First, I want to encapsulate all that logic for creating a bindable list of enum values without the need of an ObjectDataProvider.  
    /// I also want to eliminate the need to create a Resource that must be defined in order to be used in my XAML.  
    /// Ideally I would just do everything inline like I would with a normal object binding.  
    /// To accomplish this, I am going to enlist the help of a custom MarkupExtension.  
    /// This extension will simply take an enum Type and then create a bindable list of enum values for my control. 
    /// </summary>
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type _enumType;
        public Type EnumType
        {
            get { return this._enumType; }
            set
            {
                if (value != this._enumType)
                {
                    if (null != value)
                    {
                        Type enumType = Nullable.GetUnderlyingType(value) ?? value;
                        if (!enumType.IsEnum)
                            throw new ArgumentException("Type must be for an Enum.");
                    }

                    this._enumType = value;
                }
            }
        }

        public EnumBindingSourceExtension() { }

        public EnumBindingSourceExtension(Type enumType)
        {
            this.EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (null == this._enumType)
                throw new InvalidOperationException("The EnumType must be specified.");

            Type actualEnumType = Nullable.GetUnderlyingType(this._enumType) ?? this._enumType;
            Array enumValues = Enum.GetValues(actualEnumType);

            if (actualEnumType == this._enumType)
                return enumValues;

            Array tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
            enumValues.CopyTo(tempArray, 1);
            return tempArray;
        }
    }
}