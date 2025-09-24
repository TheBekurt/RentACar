﻿using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var getListModelQuery = new GetListModelQuery { PageRequest = pageRequest };
            var response = await Mediator!.Send(getListModelQuery);
            return Ok(response);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamicAsync([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamicQuery)
        {
            var getListByDynamicModelQuery = new GetListByDynamicModelQuery() { PageRequest = pageRequest, DynamicQuery = dynamicQuery};
            var response = await Mediator!.Send(getListByDynamicModelQuery);
            return Ok(response);
        }

    }
}
