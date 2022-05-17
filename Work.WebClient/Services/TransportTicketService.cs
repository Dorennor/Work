using System.Net.Http.Headers;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Services;

public class TransportTicketService : ITransportTicketService
{
    public async Task<TransportTicketViewModel> GetTransportTicketTicketByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.GetFromJsonAsync<TransportTicketViewModel>($"api/getTransportTicket/?id={id}");

                return result;
            }
        }
        catch (Exception e)
        {
            return null;
        }
        return null;
    }

    public async Task<List<TransportTicketViewModel>> GetAllTransportTicketTickets()
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60425/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await httpClient.GetFromJsonAsync<List<TransportTicketViewModel>>("api/getTransportTickets");
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task AddTransportTicketAsync(TransportTicketViewModel transportTicketViewModel)
    {
        try
        {
            if (transportTicketViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/addTransportTicket", transportTicketViewModel);
            }
        }
        catch (Exception e)
        {
        }
    }

    public async Task EditTransportTicketAsync(TransportTicketViewModel transportTicketViewModel)
    {
        try
        {
            if (transportTicketViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/editTransportTicket", transportTicketViewModel);
            }
        }
        catch (Exception e)
        {
        }
    }

    public async Task DeleteTransportTicketAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/deleteTransportTicket", id);
            }
        }
        catch (Exception e)
        {
        }
    }
}