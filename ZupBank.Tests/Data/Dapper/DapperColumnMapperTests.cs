using System.ComponentModel.DataAnnotations.Schema;
using Xunit;
using ZupBank.Data.Data.Dapper;

namespace ZupBank.Tests.Data.Dapper
{
    /// <summary>
    /// 
    /// </summary>
    public class DapperColumnMapperTests
    {
        [Fact]
        public void DapperColumnMapper_GetMapDapperColumn_OK()
        {
            var value = new DapperColumnMapper().GetMapDapperColumn<MapColumnDapper>();

            Assert.Equal("CODIGO", value.GetMember("CODIGO").ColumnName);
            Assert.Equal("NOME", value.GetMember("NOME").ColumnName);
        }

        [Fact]
        public void DapperColumnMapper_GetParameterColumnClassType_OK()
        {
            MapColumnDapper mapColumnDapper = new MapColumnDapper
            {
                Id = 1,
                Name = "Dapper"
            };

            var parameters = new DapperColumnMapper().GetParameterColumnClassType(mapColumnDapper);

            Assert.Equal(1, parameters.Get<int>("P_CODIGO"));
            Assert.Equal("Dapper", parameters.Get<string>("P_NOME"));
        }
    }

    /// <summary>
    /// Objeto para testes da mapeamento das colunas no Dapper
    /// </summary>
    public class MapColumnDapper
    {
        [Column("CODIGO")]
        public int Id { get; set; }
        [Column("NOME")]
        public string Name { get; set; }
    }
}
