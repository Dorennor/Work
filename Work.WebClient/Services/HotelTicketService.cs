using Serilog;
using System.Net.Http.Headers;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Services;

public class HotelTicketService : IHotelTicketService
{
    public async Task<HotelTicketViewModel> GetHotelTicketByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.GetFromJsonAsync<HotelTicketViewModel>($"api/getHotelTicket/?id={id}");

                return result;
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
        return null;
    }

    public async Task<List<HotelTicketViewModel>> GetAllHotelTickets()
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60425/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await httpClient.GetFromJsonAsync<List<HotelTicketViewModel>>("api/getHotelTickets");
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task AddHotelTicketAsync(HotelTicketViewModel hotelTicketViewModel)
    {
        try
        {
            if (hotelTicketViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/addHotelTicket", hotelTicketViewModel);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task EditHotelTicketAsync(HotelTicketViewModel hotelTicketViewModel)
    {
        try
        {
            if (hotelTicketViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/editHotelTicket", hotelTicketViewModel);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteHotelTicketAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/deleteHotelTicket", id);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}