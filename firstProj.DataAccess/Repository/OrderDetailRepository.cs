using firstProj.DataAccess.Repository.IRepository;
using firstProject.DataAccess.Data;
using firstProj.Models;
using firstProj.DataAccess.Repository.IRepository;
using firstProj.DataAccess.Repository;
using firstProj.Models;
using firstProject.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace firstProj.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);
        }
    }
}
