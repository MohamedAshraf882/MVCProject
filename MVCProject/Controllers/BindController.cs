using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class BindController : Controller
    {
        // /Bind/TestPrimitive?Age=20&Name=mohamed
        public  IActionResult TestPrimitive(int Age, string Name)
        {
            return Content($"Age: {Age}, Name: {Name}");
        }

        // /Bind/testcollection?Name=moh&Name=ali
        // /Bind/Testcollection?phones[mohamed]=231&phones[ahmed]=123
        public IActionResult TestDic(Dictionary<string,string>phones,string name)
        {
            return Content("ok");
        }
        // /Bind/testobj?Name=it&manger=ahmed
        public IActionResult testobj(Department deptobj)
        {
            return Content($"Department Name: {deptobj.Name}, Manger: {deptobj.Manger}");
        }

    }



}
