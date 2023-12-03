using JobPortal.Maui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public interface ICarrierRepository
    {
        Task<Carrier> AddCarrier(Carrier carrier);
        Task<Carrier> UpdateCarrier(int carrierId, Carrier carrier);
        Task<Carrier> GetCarrierByUserId(int userId);
        Task DeleteCarrier(int carrierId);
    }
}
