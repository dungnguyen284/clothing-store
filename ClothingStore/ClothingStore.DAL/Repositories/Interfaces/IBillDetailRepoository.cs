using ClothingStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL.Repositories.Interfaces
{
    public interface IBillDetailRepoository
    {
        public void AddBillDetail(BillDetail billDetail);
        public void UpdateBillDetail(BillDetail billDetail);
        public void DeleteBillDetail(BillDetail billDetail);
        public List<BillDetail> GetAllBillDetails();
        public BillDetail GetBillDetailById(int id);
        public List<BillDetail> GetBillDetailsByBillId(int billId);

    }
}
