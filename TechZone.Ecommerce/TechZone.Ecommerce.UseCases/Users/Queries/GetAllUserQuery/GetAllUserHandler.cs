using MediatR;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.UseCases.Users.Queries.GetAllUserQuery
{
    internal sealed class GetAllUserHandler : IRequestHandler<GetAllUserQuery, Response<IEnumerable<UserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Response<IEnumerable<UserDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<UserDto>>();
            response.Data = await _unitOfWork.UsersService.GetAllAsync(cancellationToken);
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
