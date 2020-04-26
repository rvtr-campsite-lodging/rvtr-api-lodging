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
  public class LocationController : ControllerBase
  {
    private readonly ILogger<LodgingController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public LocationController(ILogger<LodgingController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IEnumerable<LocationModel>> Get()
    {
      return await Task.FromResult<IEnumerable<LocationModel>>(_unitOfWork.Location.Get());
    }

    [HttpGet]
    public async Task<LocationModel> Get(int id)
    {
      return await Task.FromResult<LocationModel>(_unitOfWork.Location.Get(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(LocationModel model)
    {
      return await Task.FromResult<IActionResult>(_unitOfWork.Location.Post(model));
    }

    [HttpPut]
    public async Task<IActionResult> Put(LocationModel model)
    {
      return await Task.FromResult<IActionResult>(_unitOfWork.Location.Update(model));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(LocationModel model)
    {
      return await Task.FromResult<IActionResult>(_unitOfWork.Location.Delete(model));
    }
  }
}
