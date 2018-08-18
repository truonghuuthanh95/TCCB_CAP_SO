using System.Web;
using System.Web.Mvc;

namespace TCCB_ThuyenChuyen_TuyenDung
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
