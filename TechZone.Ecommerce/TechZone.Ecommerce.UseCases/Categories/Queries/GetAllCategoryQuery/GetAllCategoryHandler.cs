using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Categories.Queries.GetAllCategoryQuery
{
    internal sealed class GetAllCategoryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllCategoryQuery, Response<IEnumerable<CategoryDto>>>
    {
        public async Task<Response<IEnumerable<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<CategoryDto>>();
            response.Data = await _unitOfWork.CategoryService.GetAllAsync(cancellationToken);
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
