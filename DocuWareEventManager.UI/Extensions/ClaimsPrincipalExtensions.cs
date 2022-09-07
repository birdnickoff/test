using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DocuWareEventManager.UI.Extensions
{
    internal static class ClaimsPrincipalExtensions
    {
        internal static int GetId(this ClaimsPrincipal claimsPrincipal)
                => int.Parse(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
