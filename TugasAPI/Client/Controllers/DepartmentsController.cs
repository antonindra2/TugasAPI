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
    public class DepartmentsController : Controller
    {
       

        BaseAddress baseAddress = new BaseAddress();
        // GET: Levels
        public async Task<ActionResult> Index()
        {
            IEnumerable<DepartmentVM> department = null;

            using (var client = new HttpClient())
            {
                // define URL API
                client.BaseAddress = new Uri(baseAddress.Url());

                // define Request
                HttpResponseMessage responseTask = await client.GetAsync("Departments");


                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.ReadAsStringAsync().Result;
                    department = JsonConvert.DeserializeObject<IEnumerable<DepartmentVM>>(readTask);
                    // return Json(level, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    department = Enumerable.Empty<DepartmentVM>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(department);
        }

        public JsonResult Create(LevelVM levelVM)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress.Url());
                var myContent = JsonConvert.SerializeObject(levelVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responseTask = client.PostAsync("Department", byteContent).Result;
                return Json(responseTask);
            }
        }
    }
}