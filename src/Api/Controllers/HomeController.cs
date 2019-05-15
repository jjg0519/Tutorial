using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        public IActionResult Index()
        {
            var result = new JsonResult(new { Name = "Index", Note = "这是不需要权限的", Date = DateTime.UtcNow });
            return result;
        }

        [Authorize]
        public IActionResult About()
        {
            var user = User;

            var result = new JsonResult(new { Name = "About", Note = "登录以后就能访问到", Date = DateTime.UtcNow });
            return result;
        }

        [Authorize(Roles = "管理员")]
        public IActionResult Note()
        {
            var result = new JsonResult(new { Name = "About", Note = "这个需要管理员才能访问", Date = DateTime.UtcNow });
            return result;
        }
    }
}