using IBKS.Data;
using IBKS.Models;
using IBKS.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBKS.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IBKSDbContext ibksDbContext;
        public ProjectsController(IBKSDbContext ibksDbContext)
        {
            this.ibksDbContext = ibksDbContext;
        }
       

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projects = await ibksDbContext.Projects.ToListAsync();
            return View(projects);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProjectViewModel addProjectRequest)
        {
            var project = new Project()
            {
                Id = Guid.NewGuid(),
                ProjName = addProjectRequest.ProjName,
                Type = addProjectRequest.Type,
                status = addProjectRequest.status,
                DateOfCreation = addProjectRequest.DateOfCreation,
                UserName = addProjectRequest.UserName
            };
            await ibksDbContext.Projects.AddAsync(project);
            await ibksDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var project  = await ibksDbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);

            if (project != null)
            {

                var viewModel = new UpdateProjectViewmodel()
                {
                    Id = project.Id,
                    ProjName = project.ProjName,
                    Type =  project.Type,
                    status =  project.status,
                    DateOfCreation = project.DateOfCreation,
                    UserName = project.UserName
                   

                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateProjectViewmodel model)
        {
            var project = await ibksDbContext.Projects.FindAsync(model.Id);
            if (project != null)
            {
                project.ProjName = model.ProjName;
                project.Type = model.Type;
                project.status = model.status;
                project.DateOfCreation = model.DateOfCreation;
                project.UserName = model.UserName;
                

                await ibksDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task<IActionResult> Delete(UpdateProjectViewmodel model)
        {
            var project = await ibksDbContext.Projects.FindAsync(model.Id);
            if (project != null)
            {
                ibksDbContext.Projects.Remove(project);
                await ibksDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

    }
}
