using Microsoft.AspNetCore.Mvc;

namespace InterviewWebAPIQuestions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
                _employeeService = employeeService;
        }

        // [HttpGet()] --> it will accept only get request only, if you send other get request it will return status code as 405 (Method Not Allowed)
        // [Route("")] --> it will accept all the request types but you should handle it properly. better use route with http attributes
        #region GetMethodWithRouteAndHttpGetAttributeWithDifferentCombination
        //https://localhost:7127/api/Employee
        [HttpGet]
        public async Task<IActionResult> GetEmployeesByDefault()
        {
            var employees = await _employeeService.GetEmployeesAsync();

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        // https://localhost:7127/api/Employee/EmployeesByHttpGet
        [HttpGet("EmployeesByHttpGet", Name = "EmployeesByHttpGet")]
        public async Task<IActionResult> GetEmployeesByHttpGet()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            
            if(employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        // https://localhost:7127/EmployeesByHttpGet
        [Route("/EmployeesByRouteType")]
        public async Task<IActionResult> GetEmployeesByRouteType()
        {
            var employees = await _employeeService.GetEmployeesAsync();

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        //https://localhost:7127/api/Employee/GetEmployeesByQueryString?userName=ram
        [HttpGet("/api/Employee/GetEmployeesByQueryString", Name = "GetEmployeesByQueryString")]
        public async Task<IActionResult> GetEmployeesWithDifferentCombination2([FromQuery] string userName)
        {
            var employees = await _employeeService.GetEmployeesAsync();

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        //https://localhost:7127/api/123/EmployeesByRouteType/John
        [Route("/api/{id}/EmployeesByRouteType/{userName}", Name = "GetEmployeesWithDifferentCombination")]
        public async Task<IActionResult> GetEmployeesWithDifferentCombination(int id, string userName)
        {
            var employees = await _employeeService.GetEmployeesAsync();

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        //https://localhost:7127/api/123/EmployeesByRouteType/John
        [HttpGet("/api/{id}/EmployeesByRouteType/{userName}", Name = "GetEmployeesWithDifferentCombination2")]
        public async Task<IActionResult> GetEmployeesWithDifferentCombination2(int id, string userName)
        {
            var employees = await _employeeService.GetEmployeesAsync();

            if (employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        #endregion

        #region HttpPost
        [HttpPost("CreateEmployee", Name = "CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdEmployee = await _employeeService.AddEmployeesAsync(employee);
            return Created(nameof(GetEmployeesByDefault), createdEmployee);
        }

        [Route("CreateEmployeeWithRoute", Name = "CreateEmployeeWithRoute")]
        public async Task<IActionResult> CreateEmployeeWithRoute([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdEmployee = await _employeeService.AddEmployeesAsync(employee);
            return Created(nameof(GetEmployeesByDefault), createdEmployee);
        }
        #endregion
    }
}
