using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleCRUD.API.Features.Product.Commands.CreateNewProduct;
using SampleCRUD.API.Features.Product.Queries.GetProducts;


namespace SampleCRUD.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<List<ProductDto>> Get()
    {
        var leaveTypes = await _mediator.Send(new GetProductQuery());
        return leaveTypes;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = "Employee")]
    public async Task<int> Post(CreateNewProductCommand command)
    {
        var response = await _mediator.Send(command);
        return response;
    }
}
