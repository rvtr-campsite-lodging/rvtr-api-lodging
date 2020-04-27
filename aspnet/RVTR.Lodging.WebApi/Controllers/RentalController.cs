using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;

namespace RVTR.Lodging.WebApi.Controllers
{

  /// <summary>
  /// Api controller for interacting with Rentals
  /// </summary>
  /// <returns>List of Rentals</returns>
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class RentalController : ControllerBase
  {
    private readonly ILogger<RentalController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public RentalController(ILogger<RentalController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Get method for all Rentals
    /// </summary>
    /// <returns>List of Rentals</returns>
    [HttpGet]
    public async Task<IEnumerable<RentalModel>> Get()
    {
      return await Task.FromResult<IEnumerable<RentalModel>>(_unitOfWork.RentalRepository.Select());
    }
    /// <summary>
    /// Get method for specific RentalUnit
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Single Duration</returns>
    [HttpGet("{id}")]
    public async Task<RentalModel> Get(int id)
    {
      return await Task.FromResult<RentalModel>(_unitOfWork.RentalRepository.Select(id));
    }

    /// <summary>
    /// Post method for Rental
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Returns an action result describing the post action</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]RentalModel model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.RentalRepository.Insert(model));
      if (success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Put method for RentalUnit
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Request success or failure</returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]RentalModel model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.RentalRepository.Update(model));
            if (success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Delete method for Rentals
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Request success or failure</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.RentalRepository.Delete(model));
      if (success)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}
