using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodingChallenge.Models;
using CodingChallenge.UseCases;
using CodingChallenge.Integration.SmartyStreets;

namespace CodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmartyStreetUc _smartyStreetUc;

        public HomeController(ISmartyStreetUc smartyStreetUc)
        {
            _smartyStreetUc = smartyStreetUc;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel viewModel)
        {
            return View(viewModel);
        }

        public IActionResult SmartyStreet(IndexViewModel viewModel)
        {
            SmartyStreetsDto dto = AutoMapper.Mapper.Map<SmartyStreetsDto>(viewModel);

            _smartyStreetUc.GetInformation(dto);

            return View(nameof(HomeController.Index), viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
