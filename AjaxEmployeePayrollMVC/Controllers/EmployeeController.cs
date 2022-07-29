using AjaxEmployeePayrollMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxEmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> AddEmployee(int id = 0)
        {
            if (id == 0)
                return View(new EmployeeModel());
            else
            {
                var empl = await _context.Employee.FindAsync(id);
                if (empl == null)
                {
                    return NotFound();
                }
                return View(empl);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(int id, [Bind("Employee_Id,Employee_Name,Gender,Department,Profile_Image,StartDate,Salary,Notes")] EmployeeModel emps)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {

                    _context.Add(emps);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    try
                    {
                        _context.Update(emps);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EmployeeModelExists(emps.Employee_Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Employee.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddEmployee", emps) });
        }


        // GET: Employee/DeleteEmployee
        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empl = await _context.Employee
                .FirstOrDefaultAsync(m => m.Employee_Id == id);
            if (empl == null)
            {
                return NotFound();
            }

            return View(empl);
        }

        // POST: Employee/DeleteEmployee
        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empl = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(empl);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Employee.ToList()) });
        }

        private bool EmployeeModelExists(int id)
        {
            return _context.Employee.Any(e => e.Employee_Id == id);
        }
    }
}