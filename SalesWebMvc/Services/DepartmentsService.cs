using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class DepartmentsService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentsService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Department> FindAll() => _context.Department.OrderBy(x => x.Name).ToList();

        public void Insert(Seller seller)
        {
            //seller.Department = _context.Department.First();
            //_context.Add(seller);
            //_context.SaveChanges();
        }
    }
}