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

  /// <summary>
  /// Api controller for interacting with RentalUnits
  /// </summary>
  /// <returns>List of RentalUnits</returns>
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class RentalUnitController : ControllerBase
  {
    private readonly ILogger<RentalUnitController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public RentalUnitController(ILogger<RentalUnitController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Get method for all RentalUnits
    /// </summary>
    /// <returns>List of RentalUnits</returns>
    [HttpGet]
    public async Task<IEnumerable<RentalUnitModel>> Get()
    {
      return await Task.FromResult<IEnumerable<RentalUnitModel>>(_unitOfWork.RentalUnitRepository.Select());
    }

    /// <summary>
    /// Get method for specific RentalUnit
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Single Duration</returns>
    [HttpGet("{id}")]
    public async Task<RentalUnitModel> GetOne(int id)
    {
      return await Task.FromResult<RentalUnitModel>(_unitOfWork.RentalUnitRepository.Select(id));
    }

    /// <summary>
    /// Post method for RentalUnit
    /// </summary>
    /// <param name="Room"></param>
    /// <returns>Returns an action result describing the post action</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]RentalUnitModel room)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.RentalUnitRepository.Insert(room));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Put method for RentalUnit
    /// </summary>
    /// <param name="room"></param>
    /// <returns>Request success or failure</returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]RentalUnitModel room)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.RentalUnitRepository.Update(room));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Delete method for RentalUnits
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Request success or failure</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.RentalUnitRepository.Delete(id));
      if(success)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}
