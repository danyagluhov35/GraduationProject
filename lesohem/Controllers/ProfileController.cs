using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lesohem.Controllers
{
    public class ProfileController : Controller
    {
        [Authorize(Roles = "admin,user")]
        public IActionResult Profile() => View();
    }
}
