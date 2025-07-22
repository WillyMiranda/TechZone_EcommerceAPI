using TechZone.Ecommerce.Interfaces.Persistence;
using TechZone.Ecommerce.Interfaces.Persistence.Repositories;
using TechZone.Ecommerce.Interfaces.Persistence.Services;

namespace TechZone.Ecommerce.Persistence
{
    internal sealed class UnitOfWork(
            IUserRepository users,
            IUserService usersService,
            ICategoryRepository categoryRepository,
            ICategoryService categoryService,
            ISubCategoryRepository subCategoryRepository,
            ISubCategoryService subCategoryService,
            IProductRepository productRepository,
            IProductService productService
        ) : IUnitOfWork
    {
        public IUserRepository Users => users;
        public IUserService UsersService => usersService;
        public ICategoryRepository Categories => categoryRepository;
        public ICategoryService CategoryService => categoryService;
        public ISubCategoryRepository SubCategories => subCategoryRepository;
        public ISubCategoryService SubCategoryService => subCategoryService;
        public IProductRepository Products => productRepository;
        public IProductService ProductService => productService;
    }
}
