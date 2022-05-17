using AutoMapper;
using Work.BLL.Interfaces;
using Work.BLL.Models;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.DAL.Repositories;

namespace Work.BLL.Services;

public class TransportService : ITransportService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _transportMapper;

    public TransportService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Transport, TransportModel>().ReverseMap());
        _transportMapper = new Mapper(config);
    }

    public async Task<TransportModel> GetTransportByIdAsync(int id)
    {
        var transport = await _unitOfWork.Transports.GetByIdAsync(id);
        var transportModel = _transportMapper.Map<Transport, TransportModel>(transport);
        return transportModel;
    }

    public async Task<List<TransportModel>> GetAllTransportsAsync()
    {
        var transports = await _unitOfWork.Transports.GetAllAsync();
        var transportsModels = _transportMapper.Map<List<Transport>, List<TransportModel>>(transports);

        return transportsModels;
    }

    public async Task AddTransportAsync(TransportModel transportModel)
    {
        var transport = _transportMapper.Map<TransportModel, Transport>(transportModel);
        await _unitOfWork.Transports.CreateAsync(transport);
    }

    public async Task EditTransportAsync(TransportModel transportViewModel)
    {
        var tour = _transportMapper.Map<TransportModel, Transport>(transportViewModel);
        await _unitOfWork.Transports.UpdateAsync(tour);
    }

    public async Task DeleteTransportAsync(int id)
    {
        var transportsList = await _unitOfWork.Transports.FindAsync(t => t.Id == id);
        var transport = transportsList.First();
        await _unitOfWork.Transports.DeleteAsync(transport);
    }
}