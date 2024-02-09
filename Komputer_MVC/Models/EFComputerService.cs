using Data;
using Data.Entities;
using Komputer_MVC.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Komputer_MVC.Models
{
    public class EFComputerService : IComputerService
    {
        private AppDbContext _context;

        public EFComputerService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Computer computer)
        {
            var e = _context.Computers.Add(ComputerMapper.ToEntity(computer));
            _context.SaveChanges();
            return e.Entity.ComputerId;
        }

        public void Delete(int id)
        {
            var find = _context.Computers.Find(id);

            if (find != null)
            {
                _context.Computers.Remove(find);    
                _context.SaveChanges();
            }
        }

        public void Update(Computer computer) 
        {
            var entity = ComputerMapper.ToEntity(computer);
            _context.Update(entity);
            _context.SaveChanges();
        }

        public List<Computer> FindAll()
        {
            return _context
                .Computers
                .Include(c => c.Type)
                .Select(c => ComputerMapper.FromEntity(c))
                .ToList();
        } 

        public Computer? FindById(int id)
        {
            var find = _context.Computers.Include(c => c.Type).SingleOrDefault(c => c.ComputerId == id);
            return find is null ? null : ComputerMapper.FromEntity(find);
        }

        public List<Computer> FindByType(int typeId)
        {
            return _context.Computers.Include(c => c.Type).Where(c => c.TypeId == typeId).Select(c => ComputerMapper.FromEntity(c)).ToList();
        }

        public PagingList<Computer> FindPage(int page, int size, List<Computer> computers)
        {
            return PagingList<Computer>.Create(
                (p, s) => computers.OrderBy(c => c.Name).Skip((p - 1) * size).Take(s), page, size, computers.Count()
                );
        }
    }
}
