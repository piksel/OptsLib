using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibSettings
{

    public interface ISettingsManager
    {
        Task<ISettings> GetSettings();
        Type SettingsType { get; }
    }
}
