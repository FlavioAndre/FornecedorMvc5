using System.Web.Mvc;
using SimpleInjector;

namespace Fornecedor.UI.Web.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}