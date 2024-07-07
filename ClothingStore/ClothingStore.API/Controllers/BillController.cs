using ClothingStore.BLL.DTOs;
using ClothingStore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.API.Controllers
{
    [Route("api/bills")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService = billService;
        }
        [HttpGet] 
        public async Task<IActionResult> GetAllBill()
        {
            var result = await _billService.GetAllBillsAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillById(int id)
        {
            var result = await _billService.GetBillByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("date")]
        public async Task<IActionResult> GetBillsBetweenDate(DateRequest dateRequest)
        {
            if(dateRequest.BeginDate == null || dateRequest.EndDate == null)
            {
                return BadRequest(new { message = "The parameters cannot be null" });
            }
            var result = await _billService.GetBillsBetweenAsync(dateRequest.BeginDate, dateRequest.EndDate);
            return Ok(result);

        }
        [HttpGet("{date}")]
        public async Task<IActionResult> GetBillsByDate(DateTime date)
        {

            var result = await _billService.GetBillsByDate(date);
            return Ok(result);

        }

    }
}
