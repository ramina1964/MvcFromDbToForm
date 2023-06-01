namespace MvcApp.Controllers;

public class HomeController : Controller
{
    public HomeController(ILogger<HomeController> logger, IEmployeeService service)
    {
        _logger = logger;
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public IActionResult Index() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    public async Task<ActionResult> ViewEmployees()
    {
        ViewBag.Message = "Employees List";
        var result = await _service?.ReadAll();

        var employees = new List<EmployeeDisplay>();
        if (result is not null)
        {
            foreach (var row in result)
            {
                var employeeDisp = new EmployeeDisplay
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmail = row.EmailAddress
                };
                employees.Add(employeeDisp);
            }
        }

        return View(employees);
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        ViewBag.Message = "Employee Sign Up";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> SignUp(EmployeeDisplay employee)
    {
        if (ModelState.IsValid && employee != null)
        {
            var e = new Employee
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmailAddress = employee.EmailAddress
            };

            var records = await _service.Create(e);
            return RedirectToAction("ViewEmployees");
        }

        return View();
    }

    private readonly ILogger<HomeController> _logger;
    private readonly IEmployeeService _service;
}