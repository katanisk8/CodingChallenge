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
        private readonly ISearchedDataUc _searchedDataUc;

        public HomeController(
            IMapper mapper,
            IHomeUc homeUc,
            ISearchedDataUc searchedDataUc)
        {
            _mapper = mapper;
            _homeUc = homeUc;
            _searchedDataUc = searchedDataUc;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dto = _homeUc.GetDefaultSearchedData();
            var searchedDataVieModel = _mapper.Map<SearchedDataVieModel>(dto);
            var indexViewModel = new IndexViewModel
            {
                SearchedDataVieModel = searchedDataVieModel
            };

            return View(indexViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult FindInformations(SearchedDataVieModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", new IndexViewModel{ SearchedDataVieModel = viewModel});
            }

            var dto = _mapper.Map<SearchedDataDto>(viewModel);
            var resultDto = _searchedDataUc.GetMoreInformations(dto);
            var resultViewModel = _mapper.Map<SearchedResultViewModel>(resultDto);

            var indexViewModel = new IndexViewModel
            {
                SearchedDataVieModel = viewModel,
                SearchedResultViewModel = resultViewModel
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
