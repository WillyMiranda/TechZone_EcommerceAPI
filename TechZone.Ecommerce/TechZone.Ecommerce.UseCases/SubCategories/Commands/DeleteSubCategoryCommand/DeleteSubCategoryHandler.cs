using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.SubCategories.Commands.DeleteSubCategoryCommand
{
    internal sealed class DeleteSubCategoryHandler
        (IUnitOfWork _unitOfWork)
        : IRequestHandler<DeleteSubCategoryCommand, Response<bool>>
    {
        public async Task<Response<bool>> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            response.Data = await _unitOfWork.SubCategories.DeleteAsync(request.Id, DateTime.Now, cancellationToken);
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
