using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Cahe
{
    public interface IcacheIServices
    {
        Task SetCacheResponseAsync(string key, object response, TimeSpan time);
        Task<string> GetCacheResponseAsync(string key);
    }
}
