using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Queries.GetAllByCategorySubCategoryQuery
{
    internal sealed class GetAllByCategorySubCategoryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllByCategorySubCategoryQuery, Response<IEnumerable<SubCategoryDto>>>
    {
        public async Task<Response<IEnumerable<SubCategoryDto>>> Handle(GetAllByCategorySubCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<SubCategoryDto>>();
            response.Data = await _unitOfWork.SubCategoryService.GetAllByCategoryAsync(request.CategoryId, cancellationToken);
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
