using MediatR;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Commands.UpdateSubCategoryCommand
{
    public sealed record UpdateSubCategoryCommand : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public string Image { get; init; }
        public bool IsActive { get; init; }
        public Guid CategoryId { get; init; }
    }
}
