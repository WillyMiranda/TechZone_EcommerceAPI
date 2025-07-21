using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Categories.Commands.DeleteCategoryCommand
{
    internal sealed class DeleteCategoryHandler
        (IUnitOfWork _unitOfWork)
        : IRequestHandler<DeleteCategoryCommand, Response<bool>>
    {
        public async Task<Response<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            response.Data = await _unitOfWork.Categories.DeleteAsync(request.Id, DateTime.Now, cancellationToken);
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
