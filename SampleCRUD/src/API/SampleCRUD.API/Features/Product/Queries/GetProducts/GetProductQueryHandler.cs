using AutoMapper;
using MediatR;
using SampleCRUD.Domain;

namespace SampleCRUD.API.Features.Product.Queries.GetProducts;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ProductDto>>
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<Domain.Product> productRepository;

    public GetProductQueryHandler(IMapper mapper, IGenericRepository<Domain.Product> productRepository)
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
    }
    public async Task<List<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.GetAsync();
        var finalResult = mapper.Map<List<ProductDto>>(result);
        return finalResult;
    }
}
