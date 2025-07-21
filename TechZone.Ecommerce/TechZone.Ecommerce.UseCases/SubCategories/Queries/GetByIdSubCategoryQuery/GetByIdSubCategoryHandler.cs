using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Queries.GetByIdSubCategoryQuery
{
    internal sealed class GetByIdSubCategoryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetByIdSubCategoryQuery, Response<SubCategoryDto>>
    {
        public async Task<Response<SubCategoryDto>> Handle(GetByIdSubCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<SubCategoryDto>();
            response.Data = await _unitOfWork.SubCategoryService.GetByIdAsync(request.Id, cancellationToken);
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
