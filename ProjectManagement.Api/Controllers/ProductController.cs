using EHealthcare.Entities;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class ProductController : BaseController<Product>
    {
        private IBaseRepository<Category> CatRepository { get; set; }
        public ProductController(IBaseRepository<Category> repository)
        {
            CatRepository = repository;
        }

        [HttpPost("addMedicine")]
        public async Task<IActionResult> AddMedicine(Product product)
        {
            return await base.Post(product);

        }

        [HttpPut("updateMedicine")]
        public async Task<IActionResult> UpdateMedicine(Product product)
        {
            return await base.Put(product);

        }

        [HttpGet("getAllMedicine")]
        public IActionResult Get()
        {
            return base.Get();
        }

        [HttpGet("getMedicineById/{id}")]
        public IActionResult UpdateMedicine(long id)
        {
            return base.Get(id);

        }

        [HttpDelete("deleteMedicineById/{id}")]
        public async Task<IActionResult> DeleteMedicine(long id)
        {
            return await base.Delete(id);

        }
    }
}
