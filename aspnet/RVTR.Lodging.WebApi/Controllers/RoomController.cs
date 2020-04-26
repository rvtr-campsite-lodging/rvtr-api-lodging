using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;

namespace RVTR.Lodging.WebApi.Controllers
{
  [ApiController]
  [EnableCors()]
  [Route("[controller]")]
  public class RoomController : ControllerBase
  {
    private readonly ILogger<RoomController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public RoomController(ILogger<RoomController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IEnumerable<LocationModel>> Get()
    {
      return await Task.FromResult<IEnumerable><RoomModel>(_unitOfWork.Room.Get());
    }

    [HttpPost]
    public async Task<LodgingModel> Post()
    {

    }

    [HttpDelete]
    public async Task<LodgingModel> Delete()
    {

    }

    [HttpPut]
    public async Task<LodgingModel> Put()
    {

    }
  }
}
