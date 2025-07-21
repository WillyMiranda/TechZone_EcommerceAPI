using MediatR;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Categories.Commands.CreateCategoryCommand
{
    public sealed record CreateCategoryCommand: IRequest<Response<bool>>
    {
        public string Name { get; init; }
        public string Image { get; init; }
    }
}
