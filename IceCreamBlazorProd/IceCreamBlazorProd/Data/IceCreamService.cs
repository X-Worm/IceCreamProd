using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamBlazorProd.Data
{
    public class IceCreamService
    {
        private readonly ApplicationDbContext _db;

        public IceCreamService(ApplicationDbContext db)
        {
            _db = db;
        }

        // CRUD

        // get
        public List<IceCream> Get()
        {
            var empList = _db.IceCreams.ToList();
            return empList;
        }

        // insert
        public void Create(IceCream emp)
        {
            _db.IceCreams.Add(emp);
            _db.SaveChanges();
        }

        // delete
        public void Delete(IceCream emp)
        {
            _db.IceCreams.Remove(emp);
            _db.SaveChanges();
        }

        // update
        public void Update(IceCream emp)
        {
            _db.IceCreams.Update(emp);
            _db.SaveChanges();
        }

        // get by id
        public IceCream GetById(int id)
        {
            return _db.IceCreams.ToList().Where(item => item.IceCreamId == id).FirstOrDefault();

        }
    }
}
