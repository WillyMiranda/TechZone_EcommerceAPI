using AutoMapper;
using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Categories.Commands.UpdateCategoryCommand
{
    internal sealed class UpdateCategoryHandler
        (IMapper _mapper, 
         IUnitOfWork _unitOfWork)
        : IRequestHandler<UpdateCategoryCommand, Response<bool>>
    {
        public async Task<Response<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var category = _mapper.Map<Domain.Entities.Category>(request);
            response.Data = await _unitOfWork.Categories.UpdateAsync(category, DateTime.Now, cancellationToken);
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
