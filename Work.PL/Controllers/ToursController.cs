using Microsoft.AspNetCore.Mvc;
using Serilog;
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
        public async Task<TourModel> GetTourAsync([FromBody] int id)
        {
            return await _tourService.GetTourById(id);
        }

        [HttpPost]
        [Route("api/addTour")]
        public async Task AddTourAsync([FromBody] TourModel tourModel)
        {
            if (tourModel == null) return;
            await _tourService.AddTourAsync(tourModel);
        }

        [HttpPost]
        [Route("api/deleteTour")]
        public async Task DeleteTourAsync([FromBody] int id)
        {
            if(id == null) return;
            await _tourService.DeleteTourAsync(id);
        }

        [HttpPost]
        [Route("api/editTour")]
        public async Task EditTourAsync([FromBody] TourModel tourModel)
        {
            if (tourModel == null) return;
            await _tourService.EditTourAsync(tourModel);
        }
    }
}