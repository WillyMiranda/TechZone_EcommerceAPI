using Moq;
using TechZone.Ecommerce.DTOs.DTOs;
using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Transversal;
using TechZone.Ecommerce.UseCases.Users.Queries.GetByEmailUserQuery;

namespace TechZone.Ecommerce.UsesCases.Users
{
    public sealed class GetByEmail
    {
        [Fact(DisplayName = "GetByEmail_ShouldReturnNull_WhenUserNotExists")]
        internal async Task GetByEmail_ShouldReturnNull_WhenUserNotExists()
        {
            //1 - Arrange - Preparar el escenario de prueba
            const string email = "jose@gmail.com";
            UserDto expectedUser = null;

            var mockService = new Mock<IUnitOfWork>();
            mockService.Setup(service => service.UsersService.GetUserByEmailAsync(email)).ReturnsAsync(expectedUser);

            var handler = new GetByEmailUserHandler(mockService.Object);

            //2 - Act - Ejecutar la acción que se va a probar
            var result = await handler.Handle(new GetByEmailUserQuery { Email = email }, new CancellationToken());


            //3 - Assert - Verificar el resultado de la acción
            Assert.Null(expectedUser);
            Assert.Equal(ResponseMessage.GET_FAILURE, result.Message);
            Assert.False(result.IsSuccess);

        }

        [Fact(DisplayName = "GetByEmail_ShouldReturnUserDto_WhenUserExists")]
        internal async Task GetByEmail_ShouldReturnUserDto_WhenUserExists()
        {
            //1 - Arrange - Preparar el escenario de prueba
            const string email = "j0s3m1r4nd41998@gmail.com";
            var expectedUser = new UserDto
            {
                Id = Guid.Parse("b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5e6"),
            };

            var mockService = new Mock<IUnitOfWork>();
            mockService.Setup(service => service.UsersService.GetUserByEmailAsync(email)).ReturnsAsync(expectedUser);

            var handler = new GetByEmailUserHandler(mockService.Object);

            //2 - Act - Ejecutar la acción que se va a probar
            var result = await handler.Handle(new GetByEmailUserQuery { Email = email }, new CancellationToken());


            //3 - Assert - Verificar el resultado de la acción
            Assert.Equal(expectedUser.Id, result.Data.Id);
            Assert.Equal(ResponseMessage.GET_SUCCESS, result.Message);
            Assert.True(result.IsSuccess);

        }
    } 
}
