using Dapper;

namespace ZupBank.Data.Data.Dapper
{
    public interface IDapperColumnMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        CustomPropertyTypeMap GetMapDapperColumn<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemObject"></param>
        /// <returns></returns>
        DynamicParameters GetParameterColumnClassType(object itemObject);
    }
}
