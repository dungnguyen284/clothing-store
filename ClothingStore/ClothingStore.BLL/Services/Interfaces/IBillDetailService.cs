using ClothingStore.BLL.CustomResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BLL.Services.Interfaces
{
    public interface IBillDetailService
    {
        Task<ApiResponse<bool>> GetBillDetailsOfBill(int billId);
    }
}
