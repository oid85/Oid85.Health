using Microsoft.AspNetCore.Mvc;
using Oid85.Health.Application.Interfaces.Services;
using Oid85.Health.Core;
using Oid85.Health.Core.Requests;
using Oid85.Health.Core.Responses;
using Oid85.Health.WebHost.Controller.Base;

namespace Oid85.Health.WebHost.Controller;

/// <summary>
/// Глюкоза
/// </summary>
[Route("api/glucose")]
[ApiController]
public class GlucoseController(
    IGlucoseService glucoseService)
    : BaseController
{
    /// <summary>
    /// Получение списка измерений глюкозы
    /// </summary>
    [HttpPost("list")]
    [ProducesResponseType(typeof(BaseResponse<GetGlucoseListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetGlucoseListResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<GetGlucoseListResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetGlucoseListAsync() =>
        GetResponseAsync(
            () => glucoseService.GetGlucoseListAsync(
                new GetGlucoseListRequest
                {
                    From = DateOnly.FromDateTime(DateTime.Today.AddMonths(-1)),
                    To = DateOnly.FromDateTime(DateTime.Today)
                }),
            result => new BaseResponse<GetGlucoseListResponse> { Result = result });

    /// <summary>
    /// Внести измерение глюкозы
    /// </summary>
    [HttpPost("set")]
    [ProducesResponseType(typeof(BaseResponse<SetGlucoseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<SetGlucoseResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<SetGlucoseResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> SetGlucoseAsync(
        [FromBody] SetGlucoseRequest request) =>
        GetResponseAsync(
            () => glucoseService.SetGlucoseAsync(request),
            result => new BaseResponse<SetGlucoseResponse> { Result = result });

    /// <summary>
    /// Получить количество измерений глюкозы за дату
    /// </summary>
    [HttpPost("count")]
    [ProducesResponseType(typeof(BaseResponse<GetCountGlucoseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetCountGlucoseResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<GetCountGlucoseResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetGlucoseAsync(
        [FromBody] GetCountGlucoseRequest request) =>
        GetResponseAsync(
            () => glucoseService.GetCountGlucoseAsync(request),
            result => new BaseResponse<GetCountGlucoseResponse> { Result = result });
}