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

        var configPerson = new MapperConfiguration(cfg => cfg.CreateMap<Transport, TransportModel>().ReverseMap());
        _transportMapper = new Mapper(configPerson);
    }

    public async Task<TransportModel> GetTransportByIdAsync(int id)
    {
        var transport = await _unitOfWork.Transports.GetByIdAsync(id);
        TransportModel model = _transportMapper.Map<Transport, TransportModel>(transport);

        return model;
    }

    public async Task AddTransportAsync(TransportModel transportModel)
    {
        await _unitOfWork.Transports.CreateAsync(_transportMapper.Map<TransportModel, Transport>(transportModel));
    }
}