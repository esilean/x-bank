using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace ZupBank.Application.Helpers
{
    public static class EnumHelper
    {
        /// <summary>
        /// Literal value
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            var memInfo = type.GetMember(en.ToString());
            var attr = memInfo[0].GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
            if (attr != null)
            {
                return attr.Value.ToUpper();
            }
            else
            {
                var descAttr = memInfo[0].GetCustomAttributes(false).OfType<DescriptionAttribute>().FirstOrDefault();
                if (descAttr != null)
                {
                    return descAttr.Description;
                }
            }

            throw new ArgumentException("Literal Attr not found.");
        }

        /// <summary>
        /// Get value from Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetValueFromEnumMember<T>(string value)
        {
            var type = typeof(T);
            if (type.GetTypeInfo().IsEnum)
            {
                foreach (var name in Enum.GetNames(type))
                {
                    var attr = type.GetRuntimeField(name).GetCustomAttribute<EnumMemberAttribute>(true);
                    if (attr != null && attr.Value == value.ToUpper())
                        return (T)Enum.Parse(type, name);
                }

                throw new ArgumentException("Value not found.");
            }

            throw new InvalidOperationException("Value is not a Enum.");
        }
    }
}
