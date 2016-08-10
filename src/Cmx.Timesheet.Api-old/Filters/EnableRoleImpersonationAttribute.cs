using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using J2BI.Holidays.HotelBranding.Core.Configuration;

namespace J2BI.Holidays.HotelBranding.Api.Filters
{
    public class EnableRoleImpersonationAttribute : ActionFilterAttribute
    {
        private readonly IAppConfigReader _appConfigReader;
        private const string J2BIRolesHeaderKey = "J2BI-Roles";

        public EnableRoleImpersonationAttribute(IAppConfigReader appConfigReader)
        {
            _appConfigReader = appConfigReader;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (IsSuperUser(actionContext.RequestContext.Principal))
            {
                SwitchToClaimsPrincipal(actionContext);
                AddRoleClaimsFromHttpHeader(actionContext);
                AddSuperUserGroupsAsRoleClaims(actionContext);
                return;
            }

            if (_appConfigReader.CanImpersonateRole)
            {
                SwitchToClaimsPrincipal(actionContext);
                AddRoleClaimsFromHttpHeader(actionContext);
            }
        }

        private void SwitchToClaimsPrincipal(HttpActionContext actionContext)
        {
            var identity = actionContext.RequestContext.Principal.Identity;
            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, identity.Name));
            actionContext.RequestContext.Principal = new ClaimsPrincipal(claimsIdentity);
        }

        private void AddRoleClaimsFromHttpHeader(HttpActionContext actionContext)
        {
            var claimsIdentity = actionContext.RequestContext.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity == null)
            {
                throw new InvalidOperationException("This operation can only be performed on ClaimsIdentity.");
            }

            var roleClaims = actionContext.Request.Headers
                .Where(header => header.Key == J2BIRolesHeaderKey)
                .SelectMany(item => item.Value)
                .SelectMany(item => item.Split(','))
                .Select(value => new Claim(ClaimTypes.Role, value.Trim()));
            claimsIdentity.AddClaims(roleClaims);
        }

        private void AddSuperUserGroupsAsRoleClaims(HttpActionContext actionContext)
        {
            var claimsIdentity = actionContext.RequestContext.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity == null)
            {
                throw new InvalidOperationException("This operation can only be performed on ClaimsIdentity.");
            }

            _appConfigReader.SuperUserActiveDirectoryGroups.ToList()
                .ForEach(group => claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, group)));
        }

        private bool IsSuperUser(IPrincipal principal)
        {
            var superUserGroups = _appConfigReader.SuperUserActiveDirectoryGroups.ToList();
            return superUserGroups.Any() && superUserGroups.Any(principal.IsInRole);
        }

    }
}