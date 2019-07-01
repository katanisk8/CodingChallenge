using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodingChallenge.Models;
using CodingChallenge.UseCases;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using CodingChallenge.Integration.DTO;

namespace CodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHomeUc _homeUc;
        private readonly IDataUc _dataUc;

        public HomeController(
            IMapper mapper,
            IHomeUc homeUc,
            IDataUc dataUc)
        {
            _mapper = mapper;
            _homeUc = homeUc;
            _dataUc = dataUc;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dto = _homeUc.GetDefaultData();
            var dataVieModel = _mapper.Map<DataVieModel>(dto);
            var indexViewModel = new IndexViewModel
            {
                DataVieModel = dataVieModel
            };

            return View(indexViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult FindInformations(DataVieModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", new IndexViewModel{ DataVieModel = viewModel});
            }

            var dto = _mapper.Map<DataDto>(viewModel);
            var resultDto = _dataUc.GetMoreInformations(dto);
            var resultViewModel = _mapper.Map<ResultViewModel>(resultDto);

            var indexViewModel = new IndexViewModel
            {
                DataVieModel = viewModel,
                ResultViewModel = resultViewModel
            };

            return View("Index", indexViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
