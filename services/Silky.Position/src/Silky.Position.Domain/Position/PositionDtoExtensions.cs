using System.Threading.Tasks;
using Silky.Core;
using Silky.Organization.Application.Contracts.Organization;
using Silky.Position.Application.Contracts.Position.Dtos;

namespace Silky.Position.Domain;

public static class PositionDtoExtensions
{
    public static async Task SetOrganization(this PositionDtoBase positionDto)
    {
        var organizationAppService = EngineContext.Current.Resolve<IOrganizationAppService>();
        foreach (var positionOrganization in positionDto.PositionOrganizations)
        {
            positionOrganization.OrganizationName =
                (await organizationAppService.GetAsync(positionOrganization.OrganizationId)).Name;
        }
    }
}