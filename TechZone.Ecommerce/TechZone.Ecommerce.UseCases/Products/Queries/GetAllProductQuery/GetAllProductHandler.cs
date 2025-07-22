using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Products.Queries.GetAllProductQuery
{
    internal sealed class GetAllProductHandler(IUnitOfWork _unitOfWork): IRequestHandler<GetAllProductQuery, ResponsePagination<IEnumerable<ProductDto>>>
    {
        public async Task<ResponsePagination<IEnumerable<ProductDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponsePagination<IEnumerable<ProductDto>>();
            var result = await _unitOfWork.ProductService.GetAllAsync(request.ProductName, request.CategoryId, request.SubCategoryId, request.PageNumber, request.PageSize, cancellationToken);
            if (result.List is null)
            {
                response.Message = ResponseMessage.GET_FAILURE;
                return response;
            }
            response.Data = result.List;
            response.PageNumber = request.PageNumber;
            response.PageSize = request.PageSize;
            response.TotalRecords = result.TotalRecords;
            response.IsSuccess = true;
            response.Message = ResponseMessage.GET_SUCCESS;
            return response;
        }
    }
}
