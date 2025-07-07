using AutoMapper;
using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Interfaces.Services;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Users.Commands.CreateUserCommand
{
    internal sealed class CreateUserHandler(IUnitOfWork _unitOfWork, ICurrentUser _currentUser, IMapper _mapper): IRequestHandler<CreateUserCommand, Response<bool>>
    {
        public async Task<Response<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();

            var user = _mapper.Map<Domain.Entities.User>(request);
            response.Data = await _unitOfWork.Users.AddAsync(_currentUser.UserId.GetValueOrDefault(), user, request.Password, request.RoleName, cancellationToken);
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
