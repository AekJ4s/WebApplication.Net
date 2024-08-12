using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

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

        // POST: Employee/Create
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (model != null && model.CardId != null && model.CardId.Length == 13 && model.EmployeeId != null  && model.EmployeeId.Length == 6) 
            {
                model.Age = CalculateAge(model.Dateofbirth);
                _context.Employees.Add(model);
                _context.SaveChanges();
                return Json(new Response { Code = 200, Message = "CreateSuccess", Data = model });
            }
            else
            {
                if(model == null)
                {
                    return Json(new Response { Code = 404, Message = "ข้อมูลที่ได้รับนั้นว่าง", Data = null });
                }else if(model.CardId.Length != 13 && model.CardId != null)
                {
                    return Json(new Response { Code = 404, Message = "รหัสบัตรประชาชนต้องมี 13 หลัก", Data = null });
                }else if (model.EmployeeId.Length != 6 && model.EmployeeId != null)
                {
                    return Json(new Response { Code = 404, Message = "รหัสพนักงานต้องมี 6 หลัก", Data = null });
                }else{
                    return Json(new Response { Code = 500, Message = "ไม่สามารถติดต่อกับเซิร์ฟเวอร์ได้", Data = null });
                }

            }

        }
    }
}