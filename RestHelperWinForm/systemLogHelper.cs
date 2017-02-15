using SMT.Foundation.Log;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RestHelperUI
{
   public class LogHelper
    {
        public static void WriteErrLog(string Msg)
        {
            Tracer.Debug(Msg);
        }
    }
}
