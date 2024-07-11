using ClothingStore.BLL.Services.Implementations;
using ClothingStore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.API.Controllers
{
    [Route("api/billDetails")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
        private IBillDetailService _billDetailService;
        public BillDetailController(IBillDetailService billDetailService)
        {
            _billDetailService = billDetailService;
        }
        [HttpGet("bill/{id}")]
        public async Task<IActionResult> GetBillDetailsByBillId(int id)
        {
            var result = await _billDetailService.GetBillDetailsOfBill(id);
            return Ok(result);
        }
    }
}
