using Serilog;
using System.Net.Http.Headers;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Services;

public class OrderService : IOrderService
{
    public async Task<OrderViewModel> GetOrderByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.GetFromJsonAsync<OrderViewModel>($"api/getOrder/?id={id}");

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

    public async Task<List<OrderViewModel>> GetAllOrders()
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60425/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await httpClient.GetFromJsonAsync<List<OrderViewModel>>("api/getOrders");
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task AddOrderAsync(OrderViewModel orderViewModel)
    {
        try
        {
            if (orderViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/addOrder", orderViewModel);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task EditOrderAsync(OrderViewModel orderViewModel)
    {
        try
        {
            if (orderViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/editOrder", orderViewModel);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteOrderAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/deleteOrder", id);
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}