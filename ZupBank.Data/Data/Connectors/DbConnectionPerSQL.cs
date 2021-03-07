using ZupBank.Application.AppSettings;

namespace ZupBank.Data.Data.Connectors
{
    public class DbConnectionPerSQL : DbConnectionProvider
    {
        public DbConnectionPerSQL(DataAppSettings dataAppSettings)
               : base(dataAppSettings.ConnectionStrings.SqlCNN)
        {
        }
    }
}
