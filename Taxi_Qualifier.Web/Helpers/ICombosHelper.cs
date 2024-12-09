using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Taxi_Qualifier.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboRoles();
    }

}
