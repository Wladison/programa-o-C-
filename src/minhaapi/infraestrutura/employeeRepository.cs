using minhaapi.modul;
using minhaapi.modulo;

namespace minhaapi.infraestrutura
{
    public class employeeRepository : iemployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void add(Employee employee)
        {
            _context.employees.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> Get()
        {
            return _context.employees.ToList();
        }
    }
}
