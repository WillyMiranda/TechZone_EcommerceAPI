using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Users.Queries.GetByEmailUserQuery
{
    internal sealed class GetByEmailUserHandler : IRequestHandler<GetByEmailUserQuery, Response<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetByEmailUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Response<UserDto>> Handle(GetByEmailUserQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<UserDto>();

            response.Data = await _unitOfWork.UsersService.GetUserByEmailAsync(request.Email);

            if (response.Data is null)
            {
                response.Message = ResponseMessage.GET_FAILURE;
                return response;
            }
            response.IsSuccess = true;
            response.Message = ResponseMessage.GET_SUCCESS;
            return response;
        }
    }
}
