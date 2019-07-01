using Microsoft.AspNetCore.Mvc;
using CodingChallenge.Models;
using CodingChallenge.UseCases;
using CodingChallenge.Integration.SmartyStreets;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace CodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISmartyStreetUc _smartyStreetUc;

        public HomeController(
            IMapper mapper,
            ISmartyStreetUc smartyStreetUc)
        {
            _mapper = mapper;
            _smartyStreetUc = smartyStreetUc;
        }

        [HttpGet]
        public IActionResult Index()
        {
            SmartyStreetsDto dto = _smartyStreetUc.GetSmartyStreetsDto();
            SmartyStreetViewModel viewModel = _mapper.Map<SmartyStreetViewModel>(dto);

            return View(new IndexViewModel
            {
                SmartyStreetViewModel = viewModel
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Index(IndexViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
