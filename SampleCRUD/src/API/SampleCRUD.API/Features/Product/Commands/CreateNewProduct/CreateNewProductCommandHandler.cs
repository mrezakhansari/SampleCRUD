using AutoMapper;
using MediatR;
using SampleCRUD.Domain;
using System.Text;

namespace SampleCRUD.API.Features.Product.Commands.CreateNewProduct;

public class CreateNewProductCommandHandler : IRequestHandler<CreateNewProductCommand, int>
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<Domain.Product> productRepository;

    public CreateNewProductCommandHandler(IMapper mapper, IGenericRepository<Domain.Product> productRepository)
    {
        this.mapper = mapper;
        this.productRepository = productRepository;
    }
    public async Task<int> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateNewProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Any())
        {
            StringBuilder str = new StringBuilder();
            foreach (var err in validationResult.Errors)
            {
                str.AppendFormat(".{0}\n", err.ErrorMessage);
            }
            throw new Exception(str.ToString());
        }
        var product = mapper.Map<Domain.Product>(request);

        await productRepository.CreateAsync(product);

        return product.Id;
    }
}
