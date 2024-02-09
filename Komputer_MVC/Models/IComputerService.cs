using Data.Entities;

namespace Komputer_MVC.Models
{
    public interface IComputerService
    {
        int Add(Computer computer);
        void Delete(int id);
        void Update(Computer computer);
        List<Computer> FindAll();
        Computer? FindById(int id);
        List<Computer> FindByType(int typeId);
        PagingList<Computer> FindPage(int page, int size, List<Computer> computers);
    }
}
