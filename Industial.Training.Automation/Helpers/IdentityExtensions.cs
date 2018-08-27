using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Industial.Training.Automation.Helpers
{
    public static  class IdentityExtensions
    {

        public static string GetFirstName(this IIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException("Invlaid user");

            var claimsIdentity = identity as ClaimsIdentity;

            if (claimsIdentity != null)
                return claimsIdentity.FindFirstValue("FirstName");

            throw new NullReferenceException("ClaimIdentity returned null");

        }
        public static string GetLastName(this IIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException("Invlaid user");

            var claimsIdentity = identity as ClaimsIdentity;

            if (claimsIdentity != null)
                return claimsIdentity.FindFirstValue("LastName");

            throw new NullReferenceException("ClaimIdentity returned null");
        }

    }
}