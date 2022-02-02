using System.Collections.Generic;

namespace Silky.Position.Application.Contracts.Position.Dtos;

/// <summary>
/// 新增或更新职位DTO对象
/// </summary>
public class CreatePositionInput : PositionDtoBase
{
    public CreatePositionInput()
    {
        OrganizationIds = new List<long>();
    }

    public ICollection<long> OrganizationIds { get; set; }
}