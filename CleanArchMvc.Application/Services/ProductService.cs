using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsEntity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task AddAsync(ProductDTO productDTO)
        {
            var productsEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(productsEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var productsEntity = await _productRepository.GetByIdAsync(id);
            await _productRepository.RemoveAsync(productsEntity);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var productsEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateAsync(productsEntity);
        }

        
    }
}