using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Work.BLL.Interfaces;
using Work.BLL.Models;
using Work.DAL.Data;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.DAL.Repositories;

namespace Work.BLL.Services;

public class TransportService : ITransportService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _transportMapper;

    public TransportService(DbContextOptions<TourDbContext> options)
    {
        _unitOfWork = new UnitOfWork(options);

        var configPerson = new MapperConfiguration(cfg => cfg.CreateMap<Transport, TransportModel>().ReverseMap());
        _transportMapper = new Mapper(configPerson);
    }

    public async Task<TransportModel> GetTransportByIdAsync(int id)
    {
        var transport = await _unitOfWork.Transports.GetByIdAsync(id);
        TransportModel model = _transportMapper.Map<Transport, TransportModel>(transport);

        return model;
    }

    public async Task AddTransport(TransportModel transportModel)
    {
        var transport = _transportMapper.Map<TransportModel, Transport>(transportModel);
        await _unitOfWork.Transports.CreateAsync(transport);
    }
}