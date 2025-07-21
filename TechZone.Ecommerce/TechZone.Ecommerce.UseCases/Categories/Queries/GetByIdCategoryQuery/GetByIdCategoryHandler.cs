using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Categories.Queries.GetByIdCategoryQuery
{
    internal sealed class GetByIdCategoryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetByIdCategoryQuery, Response<CategoryDto>>
    {
        public async Task<Response<CategoryDto>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<CategoryDto>();
            response.Data = await _unitOfWork.CategoryService.GetByIdAsync( request.Id, cancellationToken);
            if (response.Data is null)
            {
                response.Message = ResponseMessage.GET_FAILURE;
                return response;
            }
            response.IsSuccess = true;
            response.Message = ResponseMessage.GET_SUCCESS;
            return response;
        }
    }
}
