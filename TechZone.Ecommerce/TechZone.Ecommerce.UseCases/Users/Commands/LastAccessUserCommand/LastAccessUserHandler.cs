using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Interfaces.Services;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Users.Commands.LastAccessUserCommand
{
    internal sealed class LastAccessUserHandler : IRequestHandler<LastAccessUserCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;
        public LastAccessUserHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
        }
        public async Task<Response<bool>> Handle(LastAccessUserCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            response.Data = await _unitOfWork.Users.SetLastAccessAsync(_currentUser.UserId.GetValueOrDefault(), request.LastAccess, cancellationToken);
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
