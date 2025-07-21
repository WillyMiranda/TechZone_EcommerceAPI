using MediatR;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Commands.CreateSubCategoryCommand
{
    public sealed record CreateSubCategoryCommand: IRequest<Response<bool>>
    {
        public string Name { get; init; }
        public string Image { get; init; }
        public Guid CategoryId { get; init; }
    }
}
