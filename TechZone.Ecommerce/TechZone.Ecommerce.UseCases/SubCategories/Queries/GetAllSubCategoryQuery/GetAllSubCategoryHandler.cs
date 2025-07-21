using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Queries.GetAllSubCategoryQuery
{
    internal sealed class GetAllSubCategoryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllSubCategoryQuery, Response<IEnumerable<SubCategoryDto>>>
    {
        public async Task<Response<IEnumerable<SubCategoryDto>>> Handle(GetAllSubCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<SubCategoryDto>>();
            response.Data = await _unitOfWork.SubCategoryService.GetAllAsync(cancellationToken);
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
