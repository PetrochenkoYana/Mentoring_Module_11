using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMusicStore.Logger
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogDebug(string message);
        void LogError(ApplicationException ex, string message);
    }
}
