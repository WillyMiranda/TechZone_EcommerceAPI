using MediatR;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Categories.Commands.UpdateCategoryCommand
{
    public sealed record UpdateCategoryCommand: IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public string Image { get; init; }
        public bool IsActive { get; init; }
    }
}
