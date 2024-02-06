using MediatR;

namespace SampleCRUD.API.Features.Product.Commands.CreateNewProduct;

public class CreateNewProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime ProduceDate { get; set; }
    public string ManufacturePhone { get; set; }
    public string ManufactureEmail { get; set; }
}
