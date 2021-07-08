using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Infra.Data.Contexts
{
    public class DoLinkDatabaseSettings : IDoLinkDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDoLinkDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
