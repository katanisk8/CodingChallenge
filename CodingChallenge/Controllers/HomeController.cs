using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodingChallenge.Models;
using CodingChallenge.UseCases;
using CodingChallenge.Integration.SmartyStreets;
using AutoMapper;
using System;

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
            return View(new IndexViewModel { SmartyStreetViewModel = GetDefaultSmartyStreetViewModel()});
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel viewModel)
        {
            return View(viewModel);
        }

        public IActionResult SmartyStreet(SmartyStreetViewModel viewModel)
        {
            SmartyStreetsDto dto = _mapper.Map<SmartyStreetsDto>(viewModel);

            _smartyStreetUc.GetInformation(dto);

            return View(nameof(HomeController.Index), viewModel);
        }

        private SmartyStreetViewModel GetDefaultSmartyStreetViewModel()
        {
            return new SmartyStreetViewModel
            {
                Geocode = true,
                Organization = "John Doe",
                Address1 = "Rua Padre Antonio D'Angelo 121",
                Address2 = "Casa Verde",
                Locality = "Sao Paulo",
                AdministrativeArea = "SP",
                Country = "Brazil",
                PostalCode = "02516-050"
            };
        }
    }
}
