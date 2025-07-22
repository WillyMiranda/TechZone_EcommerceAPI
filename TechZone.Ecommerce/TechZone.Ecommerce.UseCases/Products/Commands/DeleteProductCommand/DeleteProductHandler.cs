using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Products.Commands.DeleteProductCommand
{
    internal sealed class DeleteProductHandler
        (IUnitOfWork _unitOfWork)
        : IRequestHandler<DeleteProductCommand, Response<bool>>
    {
        public async Task<Response<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            response.Data = await _unitOfWork.Products.DeleteAsync(request.Id, DateTime.Now, cancellationToken);
            if (!response.Data)
            {
                response.Message = ResponseMessage.DELETE_FAILURE;
                return response;
            }
            response.IsSuccess = true;
            response.Message = ResponseMessage.DELETE_SUCCESS;
            return response;
        }

    }
}
