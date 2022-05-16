﻿using Work.WebClient.Models;

namespace Work.WebClient.Interfaces;

public interface ITourService
{
    Task AddTourAsync(TourViewModel tourViewModel);

    Task EditTourAsync(TourViewModel tourViewModel);

    Task DeleteTourAsync(int id);

    Task<TourViewModel> GetTourAsync(int id);
}