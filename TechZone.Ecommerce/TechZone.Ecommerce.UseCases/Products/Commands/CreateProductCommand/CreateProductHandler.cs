using AutoMapper;
using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Products.Commands.CreateProductCommand
{
    internal sealed class CreateProductHandler(IUnitOfWork _unitOfWork, IMapper _mapper): IRequestHandler<CreateProductCommand, Response<bool>>
    {
        public async Task<Response<bool>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var product = _mapper.Map<Domain.Entities.Product>(request);
            response.Data = await _unitOfWork.Products.AddAsync(product, DateTime.Now, cancellationToken);
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
