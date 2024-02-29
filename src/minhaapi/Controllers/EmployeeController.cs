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
           
            var employee = new Employee(employeeView.nome, employeeView.age, null);
           
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
