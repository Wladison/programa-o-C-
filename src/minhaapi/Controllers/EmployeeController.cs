using Microsoft.AspNetCore.Mvc;
using minhaapi.modul;
using minhaapi.modulo;
using minhaapi.viewmodel;

namespace minhaapi.Controllers
{
    [ApiController]
    [Route("minhaapi/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly iemployeeRepository _employeeRepository;

        public EmployeeController(iemployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }
        [HttpPost]
        public IActionResult add(EmployeeViewModel employeeView)
        {
            var filepath = Path.Combine("storage", employeeView.status.FileName);

            using Stream filestream = new FileStream(FilePath, FileMode.Create);
            employeeView.status.copyto(filestream);

            var employee = new Employee(employeeView.id, employeeView.descricao, employeeView.status);
           
            _employeeRepository.add(employee);
           
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        { 
            var employess = _employeeRepository.Get();
            return Ok(employess);
        
        }
    }
}
