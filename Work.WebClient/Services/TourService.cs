using System.Net.Http.Headers;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Services;

public class TourService : ITourService
{
    public async Task<bool> AddTourAsync(TourViewModel tourViewModel)
    {
        try
        {
            if (tourViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/addTour", tourViewModel);

                return result.IsSuccessStatusCode;
            }
        }
        catch (Exception e)
        {
            return false;
        }

        return false;
    }

    public async Task<bool> UpdateTourAsync(TourViewModel tourViewModel)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteTourAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<TourViewModel> GetTourAsync(int id)
    {
        throw new NotImplementedException();
    }
}