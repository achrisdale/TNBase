using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNBase.Objects;

namespace TNBase.External.DataExport
{
    public static class ListenerExtensions
    {
        public static string PauseStartDate(this Listener listener)
        {
            
            if (string.IsNullOrEmpty(listener.StatusInfo))
            {
                return string.Empty;
            }

            return listener.StatusInfo.Substring(0, listener.StatusInfo.IndexOf(","));
        }
        public static string PauseEndDate(this Listener listener)
        {
            if (string.IsNullOrEmpty(listener.StatusInfo))
            {
                return string.Empty;
            }

            return listener.StatusInfo.Substring(listener.StatusInfo.IndexOf(",") + 1);
        }
    }
}
