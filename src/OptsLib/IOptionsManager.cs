using System;
using System.Threading.Tasks;

namespace OptsLib
{

    public interface IOptionsManager
    {
        Task<IOptions> GetOptions();
        Type SettingsType { get; }
    }
}
