using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateBrandCommand createBrandCommand)
        {
            var response = await Mediator!.Send(createBrandCommand);
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
        {
            var getListBrandQuery = new GetListBrandQuery() { PageRequest = pageRequest };
            var response = await Mediator!.Send(getListBrandQuery);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var getByIdBrandQuery = new GetByIdBrandQuery() { Id = id };
            var response = await Mediator!.Send(getByIdBrandQuery);
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            var response = await Mediator!.Send(updateBrandCommand);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deleteBrandCommand = new DeleteBrandCommand() { Id = id };
            var response = await Mediator!.Send(deleteBrandCommand);
            return Ok(response);
        }
    }
}
