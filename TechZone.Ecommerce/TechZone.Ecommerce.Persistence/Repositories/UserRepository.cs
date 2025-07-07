using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechZone.Ecommerce.Domain.Entities;
using TechZone.Ecommerce.Interfaces.Persistence.Repositories;
using TechZone.Ecommerce.Persistence.Contexts;

namespace TechZone.Ecommerce.Persistence.Repositories
{
    internal sealed class UserRepository(UserManager<User> _userManager, DapperContext _dapperContext, ApplicationDbContext _context) : IUserRepository
    {
        public async Task<bool> AddAsync(Guid userId, User user, string password, string role, CancellationToken cancellation)
        {
            //userName e email se usan de manera indistinta
            user.UserName = user.Email;
            var result = await _userManager.CreateAsync(user, password);
            var userCreated = await _userManager.FindByEmailAsync(user.Email);
            if (userCreated == null) return false;

            var userRole = await _userManager.AddToRoleAsync(userCreated, role);
            if (!userRole.Succeeded) return false;

            var userTel = await _userManager.SetPhoneNumberAsync(userCreated, user.PhoneNumber);
            if (!userTel.Succeeded) return false;

            var lockout = await _userManager.SetLockoutEnabledAsync(userCreated, user.LockoutEnabled);
            if (!lockout.Succeeded) return false;

            var twoFactor = await _userManager.SetTwoFactorEnabledAsync(userCreated, user.TwoFactorEnabled);
            if (!twoFactor.Succeeded) return false;

            if (role.Equals("Owner"))
            {
                var extendedProperties = await UpdateExtendedPropertiesBeforeCreateAsync(user.Id, user, cancellation);
                return extendedProperties;
            }
            else
            {
                var extendedProperties = await UpdateExtendedPropertiesBeforeCreateAsync(userId, user, cancellation);
                return extendedProperties;
            }
        }

        public async Task<bool> UpdateAsync(Guid ownerId, Guid userId, User user, string role, CancellationToken cancellation)
        {
            var userToUpdate = await _userManager.FindByIdAsync(user.Id.ToString());
            if (userToUpdate == null) return false;
            userToUpdate.RoleId = user.RoleId;
            userToUpdate.RoleName = user.RoleName;

            var securityStamp = await _userManager.UpdateSecurityStampAsync(userToUpdate);
            if (!securityStamp.Succeeded) return false;
            //actualizar datos del usuario
            var result = await _userManager.UpdateAsync(userToUpdate);

            //actualizar email
            var userEmail = await _userManager.SetEmailAsync(userToUpdate, user.Email);
            if (!userEmail.Succeeded) return false;
            var userName = await _userManager.SetUserNameAsync(userToUpdate, user.Email);
            if (!userName.Succeeded) return false;
            await _userManager.UpdateNormalizedEmailAsync(userToUpdate);
            await _userManager.UpdateNormalizedUserNameAsync(userToUpdate);

            //actualizar telefono
            var userTel = await _userManager.SetPhoneNumberAsync(userToUpdate, user.PhoneNumber);
            if (!userTel.Succeeded) return false;


            var twoFactor = await _userManager.SetTwoFactorEnabledAsync(userToUpdate, user.TwoFactorEnabled);
            if (!twoFactor.Succeeded) return false;

            if (!user.LockoutEnabled)
            {
                var r = await _userManager.SetLockoutEndDateAsync(userToUpdate, null);
            }
            var lockout = await _userManager.SetLockoutEnabledAsync(userToUpdate, user.LockoutEnabled);
            if (!lockout.Succeeded) return false;


            //actualizar datos del rol
            var currentUserRole = await _userManager.GetRolesAsync(userToUpdate);
            if (currentUserRole.Count == 0) return false;
            var userRole = await _userManager.RemoveFromRoleAsync(userToUpdate, currentUserRole.First());
            if (!userRole.Succeeded) return false;
            var userRoleAdd = await _userManager.AddToRoleAsync(userToUpdate, role);
            if (!userRoleAdd.Succeeded) return false;

            if (role.Equals("Owner"))
            {
                var extendedProperties = await UpdateExtendedPropertiesBeforeUpdateAsync(user.Id, userToUpdate, user, cancellation);
                return extendedProperties;
            }
            else
            {
                var extendedProperties = await UpdateExtendedPropertiesBeforeUpdateAsync(userId, userToUpdate, user, cancellation);
                return extendedProperties;
            }
        }

        public async Task<bool> UpdateExtendedPropertiesBeforeCreateAsync(Guid userId, User user, CancellationToken cancellation)
        {
            var existingUser = await _context.Users
                .Where(u => u.Email == user.Email)
                .FirstOrDefaultAsync(cancellation).ConfigureAwait(false);
            if (existingUser == null)
                return false;

            //existingUser.OwnerId = ownerId;
            existingUser.Name = user.Name;
            //existingUser.UserState = Domain.Enums.UserState.ACTIVE;
            existingUser.CreatedAt = DateTime.Now;

            _context.Users.Update(existingUser);
            var result = await _context.SaveChangesAsync(cancellation).ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> UpdateExtendedPropertiesBeforeUpdateAsync(Guid userId, User userToUpdate, User user, CancellationToken cancellation)
        {

            //userToUpdate.OwnerId = ownerId;
            //userToUpdate.Name = user.Name;
            //userToUpdate.UserState = user.UserState;
            userToUpdate.UpdatedAt = DateTime.Now;
            //userToUpdate.UpdatedBy = userId;

            _context.Users.Update(userToUpdate);
            var result = await _context.SaveChangesAsync(cancellation).ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> SetLastAccessAsync(Guid userId, DateTime lastAccessAt, CancellationToken cancellation)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return false;

            user.LastAccessAt = lastAccessAt;
            _context.Users.Update(user);
            var result = await _context.SaveChangesAsync(cancellation);

            return true;
        }

    }
}
