using AutoMapper;
using Mango.Service.ProductAPI.DbContexts;
using Mango.Service.ProductAPI.Models;
using Mango.Service.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<ProductDto, Product>(productDto);

            if(product.ProductId > 0)
            {
                _context.Products.Update(product);
            }
            else
            {
                _context.Products.Add(product);
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

                if (product == null) return false;
                
                _context.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
