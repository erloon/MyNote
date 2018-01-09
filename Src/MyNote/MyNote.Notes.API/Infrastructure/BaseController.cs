using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MyNote.Notes.Domain.Model;

namespace MyNote.Notes.API.Infrastructure
{
    public class BaseController : Controller
    {
        protected UserContext GetUserClaims(ClaimsPrincipal claims)
        {
            return new UserContext()
            {
                OrganizationId = GetOrganizationId(claims.Claims),
                UserId = GetUserId(claims.Claims)
            };
        }

        private Guid GetUserId(IEnumerable<Claim> claims)
        {
            return Guid.Parse(claims.FirstOrDefault(x => x.Type.Equals("userId")).Value);
        }

        private Guid GetOrganizationId(IEnumerable<Claim> claims)
        {
            return Guid.Parse(claims.FirstOrDefault(x => x.Type.Equals("organizationId")).Value);
        }
    }
}