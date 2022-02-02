using System.Collections.Generic;
using Silky.Rpc.CachingInterceptor;

namespace Silky.Position.Application.Contracts.Position.Dtos;

public class UpdatePositionInput : PositionDtoBase
{
    public UpdatePositionInput()
    {
        OrganizationIds = new List<long>();
    }
    
    /// <summary>
    /// 职位主键
    /// </summary>
    [CacheKey(0)]
    public long Id { get; set; }

    /// <summary>
    /// 所属岗位
    /// </summary>
    public ICollection<long> OrganizationIds { get; set; }
}