﻿namespace MvcApp.Controllers;

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

    public async Task<ActionResult> List()
    {
        ViewBag.Message = "Employees List";

        var result = await _service.ReadAll()!;
        var employees = result.Select(e => new EmployeeDisplay
        {
            Id = e.Id,
            EmployeeId = e.EmployeeId,
            FirstName = e.FirstName,
            LastName = e.LastName,
            EmailAddress = e.EmailAddress,
            ConfirmEmail = e.EmailAddress
        }).ToList() ?? new List<EmployeeDisplay>();

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

            _ = await _service.Create(e);
            return RedirectToAction("List");
        }

        return View();
    }

    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
        var empDisp = await GetEmployeeDisplay(id);

        return (empDisp is null)
            ? NotFound()
            : View(empDisp);
    }

    [HttpGet]
    public async Task<ActionResult> Update(int id)
    {
        var employee = await _service.ReadById(id);
        return (employee is null)
            ? NotFound()
            : View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Update(Employee employee)
    {
        if (ModelState.IsValid == false || employee is null)
        {
            return View();
        }
        await _service.Update(employee);

        return RedirectToAction("List");
    }

    [HttpGet]
    public async Task<ActionResult> Delete(int id)
    {
        var employee = await _service.ReadById(id);
        return (employee is null)
            ? NotFound()
            : View(employee);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        var result = await _service.Delete(id);
        return (result == 1)
            ? RedirectToAction("List")

            // Here you can handle the case when the employee is not found or not deleted.
            // Returning to the Delete view for now.
            : View();
    }

    private async Task<EmployeeDisplay?> GetEmployeeDisplay(int id)
    {
        var emp = await _service.ReadById(id);

        return (emp is null)
            ? null
            : new EmployeeDisplay
            {
                Id = id,
                EmployeeId = emp.EmployeeId,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                EmailAddress = emp.EmailAddress
            };
    }

    private readonly ILogger<HomeController> _logger;
    private readonly IEmployeeService _service;
}