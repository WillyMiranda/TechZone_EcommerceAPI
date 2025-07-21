using AutoMapper;
using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Commands.UpdateSubCategoryCommand
{
    internal sealed class UpdateSubCategoryHandler
        (IMapper _mapper, 
         IUnitOfWork _unitOfWork)
        : IRequestHandler<UpdateSubCategoryCommand, Response<bool>>
    {
        public async Task<Response<bool>> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var subCategory = _mapper.Map<Domain.Entities.SubCategory>(request);
            response.Data = await _unitOfWork.SubCategories.UpdateAsync(subCategory, DateTime.Now, cancellationToken);
            if (!response.Data)
            {
                response.Message = ResponseMessage.UPDATE_FAILURE;
                return response;
            }
            response.IsSuccess = true;
            response.Message = ResponseMessage.UPDATE_SUCCESS;
            return response;
        }
    }
}
