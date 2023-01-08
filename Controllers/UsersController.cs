using IBKS.Data;
using IBKS.Models;
using IBKS.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBKS.Controllers
{

   
    public class UsersController : Controller
    {
        private readonly IBKSDbContext ibksDbContext;
        public UsersController(IBKSDbContext ibksDbContext)
        {
            this.ibksDbContext = ibksDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await ibksDbContext.Users.ToListAsync();
            return View(users);
        }




        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel addUserRequest)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = addUserRequest.Name,
                Email = addUserRequest.Email,
                salary = addUserRequest.salary,
                Department = addUserRequest.Department,
                DateOfBirth = addUserRequest.DateOfBirth
            };
            await ibksDbContext.Users.AddAsync(user);
            await ibksDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var user = await ibksDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {

                var viewModel = new UpdateUserViewmodel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    salary = user.salary,
                    Department = user.Department,
                    DateOfBirth = user.DateOfBirth

                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateUserViewmodel model)
        {
            var user = await ibksDbContext.Users.FindAsync(model.Id);
            if (user != null)
            {
                user.Name = model.Name;
                user.Email = model.Email;
                user.salary = model.salary;
                user.DateOfBirth = model.DateOfBirth;
                user.Department = model.Department;

                await ibksDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task<IActionResult> Delete(UpdateUserViewmodel model)
        {
            var user = await ibksDbContext.Users.FindAsync(model.Id);
                if (user != null)
            {
                ibksDbContext.Users.Remove(user);
                    await ibksDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
      




        }
    }