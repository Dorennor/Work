using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Pages.Views.Order
{
    public class OrderTourModel : PageModel
    {
        private readonly IUserManagerService _userManagerService;
        private readonly IHotelService _hotelService;
        private readonly ITransportService _transportService;
        private readonly IOrderService _orderService;
        private readonly ITransportTicketService _transportTicketService;
        private readonly IHotelTicketService _hotelTicketService;

        public static TourViewModel Tour { get; set; }
        public List<TransportViewModel> Transports { get; set; }
        public List<HotelViewModel> Hotels { get; set; }

        [BindProperty]
        public int TransportId { get; set; }

        [BindProperty]
        public int TransportNumberOfUse { get; set; }

        [BindProperty]
        public int HotelId { get; set; }

        [BindProperty]
        public int HotelDaysBook { get; set; }

        public OrderTourModel(IHotelService hotelService, ITransportService transportService, IOrderService orderService, ITransportTicketService transportTicketService, IHotelTicketService hotelTicketService, IUserManagerService userManagerService)
        {
            _hotelService = hotelService;
            _transportService = transportService;
            _orderService = orderService;
            _transportTicketService = transportTicketService;
            _hotelTicketService = hotelTicketService;
            _userManagerService = userManagerService;

            Transports = _transportService.GetAllTransports().Result;
            Hotels = _hotelService.GetAllHotels().Result;
        }

        public async Task OnGetAsync(int id, string name, string type, string region, string movement, DateTime date, int duration, double price)
        {
            Tour = new TourViewModel
            {
                Id = id,
                TourName = name,
                TourType = type,
                TourRegion = region,
                TourMovementType = movement,
                TourDateTime = date,
                TourDurationInDays = duration,
                TourPrice = price
            };

            Transports = await _transportService.GetAllTransports();
            Hotels = await _hotelService.GetAllHotels();
        }

        public async Task OnPostAsync()
        {
            var tour = Tour;
            var hotel = await _hotelService.GetHotelByIdAsync(HotelId);
            var transport = await _transportService.GetTransportByIdAsync(TransportId);

            var transportTicket = new TransportTicketViewModel
            {
                NumberOfUsing = TransportNumberOfUse,
                TransportId = TransportId,
                TransportPrice = transport.TransportPrice * TransportNumberOfUse,
            };

            var hotelTicket = new HotelTicketViewModel
            {
                HotelId = HotelId,
                NumberOfDays = HotelDaysBook,
                SummaryPrice = HotelDaysBook * hotel.HotelPrice,
            };

            await _hotelTicketService.AddHotelTicketAsync(hotelTicket);
            await _transportTicketService.AddTransportTicketAsync(transportTicket);

            var hotelTicketModel = _hotelTicketService.GetAllHotelTickets().Result;
            hotelTicket.Id = hotelTicketModel.Where(h => h.HotelId == HotelId && h.SummaryPrice == hotelTicket.SummaryPrice)!.First().Id;

            var transportTicketModel = _transportTicketService.GetAllTransportTicketTickets().Result;
            transportTicket.Id = transportTicketModel.Where(h => h.TransportId == TransportId && h.TransportPrice == transportTicket.TransportPrice)!.First().Id;


            var order = new OrderViewModel
            {
                TourId = Tour.Id,
                UserId = _userManagerService.LoggedUser!.Id,
                TransportTicketId = transportTicket.Id,
                HotelTicketId = hotelTicket.Id,
                FinalPrice = tour.TourPrice + transportTicket.TransportPrice + hotelTicket.SummaryPrice
            };
            
            await _orderService.AddOrderAsync(order);

            Response.Redirect("/Views/Home/Index");
        }
    }
}