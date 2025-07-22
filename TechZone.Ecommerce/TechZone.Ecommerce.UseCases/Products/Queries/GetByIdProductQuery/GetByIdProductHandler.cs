using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Products.Queries.GetByIdProductQuery
{
    internal sealed class GetByIdProductHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetByIdProductQuery, Response<ProductDto>>
    {
        public async Task<Response<ProductDto>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<ProductDto>();
            response.Data = await _unitOfWork.ProductService.GetByIdAsync( request.Id, cancellationToken);
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
