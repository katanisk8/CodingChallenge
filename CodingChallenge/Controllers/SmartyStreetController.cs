using Microsoft.AspNetCore.Mvc;
using CodingChallenge.Models;
using CodingChallenge.UseCases;
using CodingChallenge.Integration.SmartyStreets;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace CodingChallenge.Controllers
{
    [Authorize]
    public class SmartyStreetController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISmartyStreetUc _smartyStreetUc;

        public SmartyStreetController(
            IMapper mapper,
            ISmartyStreetUc smartyStreetUc)
        {
            _mapper = mapper;
            _smartyStreetUc = smartyStreetUc;
        }
        
        [HttpPost]
        public IActionResult GetInformations(SmartyStreetViewModel viewModel)
        {
            SmartyStreetsDto dto = _mapper.Map<SmartyStreetsDto>(viewModel);

            _smartyStreetUc.GetInformation(dto);

            return View(nameof(HomeController.Index), viewModel);
        }
    }
}
