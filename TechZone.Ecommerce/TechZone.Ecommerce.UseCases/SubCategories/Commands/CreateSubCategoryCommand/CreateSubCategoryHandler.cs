using AutoMapper;
using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Interfaces.Services;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Commands.CreateSubCategoryCommand
{
    internal sealed class CreateSubCategoryHandler
        (IMapper _mapper, 
         IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateSubCategoryCommand, Response<bool>>
    {
        public async Task<Response<bool>> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var subCategory = _mapper.Map<Domain.Entities.SubCategory>(request);
            response.Data = await _unitOfWork.SubCategories.AddAsync(subCategory, DateTime.Now, cancellationToken);
            if (!response.Data)
            {
                response.Message = ResponseMessage.CREATE_FAILURE;
                return response;
            }
            response.IsSuccess = true;
            response.Message = ResponseMessage.CREATE_SUCCESS;
            return response;
        }
    }
}
