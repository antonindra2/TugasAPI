using Client.Base;
using Client.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class EmployeesController : Controller
    {
        
        BaseAddress baseAddress = new BaseAddress();
        // GET: Levels
        public async Task<ActionResult> Index()
        {
            IEnumerable<EmployeeVM> employee = null;

            using (var client = new HttpClient())
            {
                // define URL API
                client.BaseAddress = new Uri(baseAddress.Url());

                // define Request
                HttpResponseMessage responseTask = await client.GetAsync("Employees");


                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.ReadAsStringAsync().Result;
                    employee = JsonConvert.DeserializeObject<IEnumerable<EmployeeVM>>(readTask);
                    // return Json(level, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    employee = Enumerable.Empty<EmployeeVM>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(employee);
        }

        public JsonResult Create(EmployeeVM employeeVM)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress.Url());
                var myContent = JsonConvert.SerializeObject(employeeVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responseTask = client.PostAsync("Employees", byteContent).Result;
                return Json(responseTask);
            }
        }
    }
}