using Microsoft.AspNetCore.Mvc;
using Work.BLL.Interfaces;
using Work.BLL.Models;

namespace Work.PL.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourService _tourService;

        public ToursController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        [Route("")]
        [Route("api/getTours")]
        public async Task<List<TourModel>> GetAllToursAsync()
        {
            return await _tourService.GetAllTours();
        }

        [HttpGet]
        [Route("api/getTour")]
        public async Task<TourModel> GetTourAsync(int id)
        {
            return await _tourService.GetTourById(id);
        }
    }
}
