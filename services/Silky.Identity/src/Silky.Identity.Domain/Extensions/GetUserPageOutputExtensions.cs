using System.Collections.Generic;
using System.Threading.Tasks;
using Silky.Core;
using Silky.Identity.Application.Contracts.User.Dtos;
using Silky.Organization.Application.Contracts.Organization;
using Silky.Position.Application.Contracts.Position;

namespace Silky.Identity.Domain.Extensions;

public static class GetUserPageOutputExtensions
{
    public static async Task SetUserSubsidiaries(this IEnumerable<GetUserPageOutput> userPageOutputs)
    {
        var positionAppService = EngineContext.Current.Resolve<IPositionAppService>();
        var organizationAppService = EngineContext.Current.Resolve<IOrganizationAppService>();
        foreach (var userPageOutput in userPageOutputs)
        {
            foreach (var userSubsidiaryOutput in userPageOutput.UserSubsidiaries)
            {
                userSubsidiaryOutput.OrganizationName =
                    (await organizationAppService.GetAsync(userSubsidiaryOutput.OrganizationId))?.Name;
                userSubsidiaryOutput.PositionName =
                    (await positionAppService.GetAsync(userSubsidiaryOutput.PositionId))?.Name;
            }
        }
    }
}