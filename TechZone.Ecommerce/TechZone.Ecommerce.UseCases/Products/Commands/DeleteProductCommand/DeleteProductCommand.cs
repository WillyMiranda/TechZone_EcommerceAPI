using MediatR;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Products.Commands.DeleteProductCommand
{
    public sealed record DeleteProductCommand: IRequest<Response<bool>>
    {
        public Guid Id { get; init; }
    }
}
