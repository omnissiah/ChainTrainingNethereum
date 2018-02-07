using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainCore.Helpers
{
    public static class ServiceSync
    {
        public static T Sync<T>(Task<T> call)
        {
            return Task.Run(() => call).Result;
        }
    }
}
