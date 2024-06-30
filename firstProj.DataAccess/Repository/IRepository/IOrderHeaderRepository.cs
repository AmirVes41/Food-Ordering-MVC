using firstProj.Models;
using firstProj.DataAccess.Repository.IRepository;
using firstProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstProj.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader obj);
        //status of payment
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        void UpdatePaymentID(int id, string session, string paymentIntentId);
    }
}