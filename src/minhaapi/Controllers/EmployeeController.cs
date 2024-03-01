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
        public IActionResult add([FromForm] EmployeeViewModel employeeView)
        {
            var filePath = Path.Combine("storage", employeeView.photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            
            employeeView.photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.nome, employeeView.age, filePath);

            _employeeRepository.add(employee);

            return Ok();
        }

        [HttpPost]
        [Route("{id}z/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");

        }


       [HttpGet]
        public IActionResult Get()
        { 
            var employess = _employeeRepository.Get();
            return Ok(employess);
        
        }
    }
}
