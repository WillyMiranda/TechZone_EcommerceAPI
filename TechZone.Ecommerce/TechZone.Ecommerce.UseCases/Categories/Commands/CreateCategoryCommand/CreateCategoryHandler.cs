using AutoMapper;
using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Interfaces.Services;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Categories.Commands.CreateCategoryCommand
{
    internal sealed class CreateCategoryHandler
        (IMapper _mapper, 
         IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateCategoryCommand, Response<bool>>
    {
        public async Task<Response<bool>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var category = _mapper.Map<Domain.Entities.Category>(request);
            response.Data = await _unitOfWork.Categories.AddAsync(category, DateTime.Now, cancellationToken);
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
