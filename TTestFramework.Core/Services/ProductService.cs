using Microsoft.EntityFrameworkCore;
using TTestFramework.Core.Entities;
using TTestFramework.Core.Interfaces;
using TTestFramework.Core.Repositories;
using TTestFramework.Shared.Models;

namespace TTestFramework.Core.Services
{
    public interface IProductService
    {
        Task CreateProduct(CreateProductModel model);
        Task<IEnumerable<ProductListModel>> GetProducts();
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProduct(CreateProductModel model)
        {
            ProductEntity entity = new ProductEntity
            {
                Name = model.Name,
                Price = model.Price,
            };

            await _productRepository.Create(entity);

            await _unitOfWork.CommitChanges();
        }

        public async Task<IEnumerable<ProductListModel>> GetProducts()
        {
            ProductListModel[] models = await _productRepository.Query().Select(e => new ProductListModel
            {
                Name = e.Name,
                Price = e.Price,
            }).ToArrayAsync();

            return models;
        }
    }
}
