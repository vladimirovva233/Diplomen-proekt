using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBeautyShop.Domain;
using WebBeautyShop.Models.Client;

namespace WebBeautyShop.Controllers
{
    public class ClientController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
            
        public ClientController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        // GET: ClientController
        public async Task<IActionResult> Index()
        {
            var allUsers = this.userManager.Users
                 .Select(u => new ClientIndexVM
                 {
                     Id = u.Id,
                     UserName = u.UserName,
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Adress = u.Adress,
                     Email = u.Email,
                 })
                 .ToList();
            var adminIds = (await this.userManager.GetUsersInRoleAsync("Administrator"))
                .Select(a => a.Id).ToList();

            foreach (var user in allUsers)
            {
                user.IsAdmin = adminIds.Contains(user.Id);
            }

            var users = allUsers.Where(x => x.IsAdmin == false)
                .OrderBy(x => x.UserName).ToList();

            return this.View(users);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(string id)
        {
            var user = this.userManager.Users.FirstOrDefault(x => x.Id == id);
            if (user==null)
            {
                return NotFound();
            }
            ClientDeleteVM userToDelete = new ClientDeleteVM()
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Adress = user.Adress,
                Email = user.Email,
            };
            return View(userToDelete);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ClientDeleteVM bindingModel)
        {
            string id = bindingModel.Id;
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            else
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("SuccessDeleteUser");
                else
                {
                    return NotFound();
                }
            }
        }
    
        public ActionResult SuccessDeleteUser()
        {
            return View();
        }
    }
}
