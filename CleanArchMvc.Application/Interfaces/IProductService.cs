using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int? id);

        Task AddAsync(ProductDTO productDTO);

        Task UpdateAsync(ProductDTO productDTO);

        Task RemoveAsync(int? id);
    }
}