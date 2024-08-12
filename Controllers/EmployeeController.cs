using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HrmanagementContext _context;

        public EmployeeController(HrmanagementContext context)
        {
            _context = context;
        }

        public static int CalculateAge(DateTime birthDate)
        {
            // วันที่ปัจจุบัน
            DateTime today = DateTime.Today;

            // คำนวณอายุ
            int age = today.Year - birthDate.Year;

            // ปรับอายุถ้าจริงแล้วยังไม่ถึงวันเกิดในปีนี้
            if (birthDate.Date > today.AddYears(-age).Date)
            {
                age--;
            }

            return age;
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }

        // POST: Employee/Create
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (model == null)
            {
                return Json(new Response { Code = 404, Message = "ข้อมูลที่ได้รับนั้นว่าง", Data = null });
            }
            if (model.CardId == null || model.CardId.Length != 13)
            {
                return Json(new Response { Code = 404, Message = "รหัสบัตรประชาชนต้องมี 13 หลัก", Data = null });
            }
            if (model.EmployeeId == null || model.EmployeeId.Length != 6)
            {
                return Json(new Response { Code = 404, Message = "รหัสพนักงานต้องมี 6 หลัก", Data = null });
            }
            if (model.Dateofbirth == default(DateTime))
            {
                return Json(new Response { Code = 404, Message = "วันเกิดไม่ถูกต้อง", Data = null });
            }

            model.Age = CalculateAge(model.Dateofbirth);
            _context.Employees.Add(model);
            _context.SaveChanges();
            return Json(new Response { Code = 200, Message = "CreateSuccess", Data = model });
        }

    
    }
}