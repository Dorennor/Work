using System.Net.Http.Headers;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Services;

public class HotelService : IHotelService
{
    public async Task<List<HotelViewModel>> GetAllHotels()
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60425/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await httpClient.GetFromJsonAsync<List<HotelViewModel>>("api/getHotels");
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task AddHotelAsync(HotelViewModel hotelViewModel)
    {
        try
        {
            if (hotelViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/addHotel", hotelViewModel);
            }
        }
        catch (Exception e)
        {
        }
    }

    public async Task<HotelViewModel> GetHotelByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.GetFromJsonAsync<HotelViewModel>($"api/getHotel/?id={id}");

                return result;
            }
        }
        catch (Exception e)
        {
            return null;
        }
        return null;
    }

    public async Task EditHotelAsync(HotelViewModel hotelViewModel)
    {
        try
        {
            if (hotelViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/editHotel", hotelViewModel);
            }
        }
        catch (Exception e)
        {
        }
    }

    public async Task DeleteHotelAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/deleteHotel", id);
            }
        }
        catch (Exception e)
        {
        }
    }
}