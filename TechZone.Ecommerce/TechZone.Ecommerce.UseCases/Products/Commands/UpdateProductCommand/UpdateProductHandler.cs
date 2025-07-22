using AutoMapper;
using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Products.Commands.UpdateProductCommand
{
    internal sealed class UpdateProductHandler(IUnitOfWork _unitOfWork, IMapper _mapper): IRequestHandler<UpdateProductCommand, Response<bool>>
    {
        public async Task<Response<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var product = _mapper.Map<Domain.Entities.Product>(request);
            response.Data = await _unitOfWork.Products.UpdateAsync(product, DateTime.Now, cancellationToken);
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
