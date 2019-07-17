using System.Threading;

namespace Emploee.Localization
{
    public static class CultureHelper
    {
        public static bool IsRtl
        {
            get { return Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft; }
        }
    }
}
