using Microsoft.AspNetCore.Mvc;
using Work.BLL.Interfaces;
using Work.BLL.Models;

namespace Work.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITourService _tourService;

        public HomeController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        [Route("api/getTours")]
        public async Task<List<TourModel>> GetAllTours()
        {
            return await _tourService.GetAllTours();
        }

        [HttpGet]
        [Route("api/getTour")]
        public async Task<TourModel> GetTour(int id)
        {
            return await _tourService.GetTourById(id);
        }
    }
}