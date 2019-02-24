using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekHunters.App.Repositories.Interfaces;

namespace GeekHunters.App.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        public string GeekHuntersEndPoint { get; set; }
    }
}
