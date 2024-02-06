using AutoMapper;
using SampleCRUD.API.Features.Product.Commands.CreateNewProduct;
using SampleCRUD.API.Features.Product.Queries.GetProducts;
using SampleCRUD.Domain;

namespace SampleCRUD.API.MappingProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateNewProductCommand, Product>();
    }
}
