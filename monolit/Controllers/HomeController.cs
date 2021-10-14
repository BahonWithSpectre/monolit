using DataAccess.EFCore.UnitOfWorks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using monolit.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace monolit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

            if(!_unitOfWork.Developers.Any())
            {
                var developer = new Developer
                {
                    Followers = 35,
                    Name = "Mukesh Developer"
                };

                _unitOfWork.Developers.Add(developer);
                _unitOfWork.Complete();
            }
            if(!_unitOfWork.Projects.Any())
            {
                var project = new Project
                {
                    Name = "Mukesh Project"
                };
                _unitOfWork.Projects.Add(project);
                _unitOfWork.Complete();
            }
        }

        public IActionResult Index(int? Id)
        {
            if(Id != null)
            {
                var data = _unitOfWork.Developers.GetById((int)Id);

                if (data != null)
                    return Content(data.Name);
                else
                    return View();
            }
            else
            {
                return View();
            }
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
