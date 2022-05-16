﻿using System.Net.Http.Headers;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Services;

public class TourService : ITourService
{
    public async Task AddTourAsync(TourViewModel tourViewModel)
    {
        try
        {
            if (tourViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/addTour", tourViewModel);
            }
        }
        catch (Exception e)
        {
        }
    }

    public async Task EditTourAsync(TourViewModel tourViewModel)
    {
        try
        {
            if (tourViewModel != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/editTour", tourViewModel);
            }
        }
        catch (Exception e)
        {
        }
    }

    public async Task DeleteTourAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/deleteTour", id);
            }
        }
        catch (Exception e)
        {
        }
    }

    public async Task<TourViewModel> GetTourAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.GetFromJsonAsync<TourViewModel>($"api/getTour/?id={id}");

                return result;
            }
        }
        catch (Exception e)
        {
            return null;
        }
        return null;
    }

    public async Task<List<TourViewModel?>> GetAllToursAsync()
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60425/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return await httpClient.GetFromJsonAsync<List<TourViewModel>>("api/getTours");
        }
        catch (Exception e)
        {
            return null;
        }
    }
}