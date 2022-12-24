using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using Infrastructure.Repository;
using Core.Interfaces;
using Core.Entities;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWorkT<Owner> _owner;
        private readonly IUnitOfWorkT<PortfoloioItem> _Portfoloio;
        public HomeController(
            IUnitOfWorkT<Owner> owner,
            IUnitOfWorkT<PortfoloioItem> Portfoloio)
        { 
            _owner = owner;
            _Portfoloio = Portfoloio;
        }


        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().First(),
                portfoloioItems = _Portfoloio.Entity.GetAll().ToList()
            };
            return View(homeViewModel);
        }
    }
}
