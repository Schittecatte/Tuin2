using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;
using Microsoft.Build.Tasks;
using WebApplication2.Models;

namespace Application.Filters
{

    public class AuthorizeADAttribute : AuthorizeAttribute
    {
        public string Groups { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //var groups = Groups.Split(',').ToList<string>();
            if (base.AuthorizeCore(httpContext))
            {
                /* Return true immediately if the authorization is not 
                locked down to any particular AD group */
                if (String.IsNullOrEmpty(Groups))
                    return true;
                // Get the AD groups
                var groups = Groups.Split(',').ToList<string>();
                // Verify that the user is in the given AD group (if any)

                var context = new PrincipalContext(ContextType.Domain, "RENSON");
                var userPrincipal = UserPrincipal.FindByIdentity(context,
                    IdentityType.SamAccountName,
                    httpContext.User.Identity.Name);

                foreach (var group in groups)
                    if (userPrincipal.IsMemberOf(context, IdentityType.Name, group))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            return false;
        }
    }
}











