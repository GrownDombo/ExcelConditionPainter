using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelConditionPainter
{
    internal static class AppOptions
    {
        public static bool ExportSplitByConditions => Properties.Settings.Default.ExportSplitByConditions;
    }
}
