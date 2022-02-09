using IdentityServer4.Models;
using IdentityServer4.Services;

namespace BeerlandWeb.Core;

public class ProfileService : IProfileService
{
    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        context.IssuedClaims = context.Subject.Claims.ToList();
        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive = true;
        return Task.CompletedTask;
    }
}