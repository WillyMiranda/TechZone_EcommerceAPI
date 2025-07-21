using MediatR;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Commands.DeleteSubCategoryCommand
{
    public sealed record DeleteSubCategoryCommand: IRequest<Response<bool>>
    {
        public Guid Id { get; init; }
    }
}
