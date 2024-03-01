using minhaapi.modulo;

namespace minhaapi.modul
{
    public interface iemployeeRepository
    {
        void add(Employee employee);

        List<Employee> Get();
        Employee? Get(int id);
    }
}
