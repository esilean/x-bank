using Dapper;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ZupBank.Data.Data.Dapper
{
    /// <summary>
    /// 
    /// </summary>
    public class DapperColumnMapper : IDapperColumnMapper
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public CustomPropertyTypeMap GetMapDapperColumn<T>()
        {
            var map = new CustomPropertyTypeMap(typeof(T),
                    (type, columnName) => type.GetProperties().FirstOrDefault(prop => GetDescriptionFromAttr(prop) == columnName));

            return map;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemObject"></param>
        /// <returns></returns>
        public DynamicParameters GetParameterColumnClassType(object itemObject)
        {
            if (itemObject != null)
            {
                var properties = itemObject.GetType().GetProperties();
                DynamicParameters parameters = new DynamicParameters();
                foreach (var prop in properties)
                {
                    var columnName = GetDescriptionFromAttr(prop);
                    parameters.Add(string.Concat("P_", columnName), prop.GetValue(itemObject));
                }

                return parameters;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        private string GetDescriptionFromAttr(MemberInfo memberInfo)
        {
            if (memberInfo == null) return null;

            var attr = (ColumnAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(ColumnAttribute), false);
            return attr == null ? memberInfo.Name : attr.Name;
        }
    }
}
