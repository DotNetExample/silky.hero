using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Silky.Position.Application.Contracts.Position.Dtos;
using Silky.Position.Domain.Shared;
using Silky.Rpc.CachingInterceptor;
using Silky.Rpc.Routing;
using Silky.Rpc.Runtime.Server;
using Silky.Rpc.Security;

namespace Silky.Position.Application.Contracts.Position;

/// <summary>
/// 职位信息服务 
/// </summary>
[ServiceRoute]
[Authorize(PositionPermissions.Positions.Default)]
public interface IPositionAppService
{
    /// <summary>
    /// 更新职位信息
    /// </summary>
    /// <remarks>id为空时为新增</remarks>
    /// <param name="input"></param>
    /// <returns></returns>
    [Authorize(PositionPermissions.Positions.Create)]
    Task CreateAsync(CreatePositionInput input);

    /// <summary>
    /// 更新职位信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [RemoveCachingIntercept(typeof(GetPositionOutput), "id:{0}")]
    [RemoveCachingIntercept(typeof(bool), "HasPosition:{0}")]
    [Authorize(PositionPermissions.Positions.Update)]
    Task UpdateAsync(UpdatePositionInput input);

    /// <summary>
    /// 通过id获取职位信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [GetCachingIntercept("id:{0}")]
    Task<GetPositionOutput> GetAsync([CacheKey(0)] long id);

    /// <summary>
    /// 通过Id删除职位信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:long}")]
    [RemoveCachingIntercept(typeof(GetPositionOutput), "id:{0}")]
    [RemoveCachingIntercept(typeof(bool), "HasPosition:{0}")]
    [Authorize(PositionPermissions.Positions.Delete)]
    Task DeleteAsync([CacheKey(0)] long id);

    /// <summary>
    /// 分页查询职位信息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PagedList<GetPositionPageOutput>> GetPageAsync(GetPositionPageInput input);

    /// <summary>
    /// 不分页查询职位信息
    /// </summary>
    /// <param name="organizationId"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<ICollection<GetPositionOutput>> GetListAsync([FromQuery]long? organizationId, [FromQuery]string name);

    /// <summary>
    /// 判断是否存在职位
    /// </summary>
    /// <param name="positionId">职位Id</param>
    /// <returns></returns>
    [ProhibitExtranet]
    [GetCachingIntercept("HasPosition:{0}")]
    Task<bool> HasPositionAsync([CacheKey(0)] long positionId);
}