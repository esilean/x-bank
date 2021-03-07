using System.Collections.Generic;

namespace ZupBank.Application.AppSettings
{
    public class DataAppSettings
    {
        public DataAppSettingsConnectionStrings ConnectionStrings { get; set; }
        public IEnumerable<DataAppSettingsHttpClients> HttpClients { get; set; }
    }

    public class DataAppSettingsConnectionStrings
    {
        public string SqlCNN { get; set; }
    }

    public class DataAppSettingsHttpClients
    {
        public string Name { get; set; }
        public string BaseAddress { get; set; }
    }
}
