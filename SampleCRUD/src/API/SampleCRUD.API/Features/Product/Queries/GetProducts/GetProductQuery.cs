using MediatR;

namespace SampleCRUD.API.Features.Product.Queries.GetProducts;

public record GetProductQuery : IRequest<List<ProductDto>>;
