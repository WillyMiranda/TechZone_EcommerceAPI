using MediatR;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Categories.Commands.DeleteCategoryCommand
{
    public sealed record DeleteCategoryCommand: IRequest<Response<bool>>
    {
        public Guid Id { get; init; }
    }
}
