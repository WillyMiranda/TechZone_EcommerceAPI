using AutoMapper;
using MediatR;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Interfaces.Services;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Users.Commands.UpdateUserCommand
{
    internal sealed class UpdateUserHandler: IRequestHandler<UpdateUserCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;
        public UpdateUserHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUser currentUser)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
        }
        public async Task<Response<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<bool>();
            var user = _mapper.Map<Domain.Entities.User>(request);
            response.Data = await _unitOfWork.Users.UpdateAsync(_currentUser.UserId.GetValueOrDefault(), user, request.RoleName, cancellationToken);
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
