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
  /// Api controller for interacting with Lodgings
  /// </summary>
  /// <returns>List of Lodgings</returns>
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class LodgingController : ControllerBase
  {
    private readonly ILogger<LodgingController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public LodgingController(ILogger<LodgingController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }


    /// <summary>
    /// Get method for all lodgings
    /// </summary>
    /// <returns>List of logings</returns>
    [HttpGet]
    public async Task<IEnumerable<LodgingModel>> Get()
    {
      return await Task.FromResult<IEnumerable<LodgingModel>>(_unitOfWork.LodgingRepository.Select());
    }

    /// <summary>
    /// Get method for specific lodging
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Single Duration</returns>
    [HttpGet("{id}")]
    public async Task<LodgingModel> Get(int id)
    {
      return await Task.FromResult<LodgingModel>(_unitOfWork.LodgingRepository.Select(id));
    }

    /// <summary>
    /// Post method for lodging
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Returns an action result describing the post action</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]LodgingModel model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.LodgingRepository.Insert(model));
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
    public async Task<IActionResult> Put([FromBody]LodgingModel model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.LodgingRepository.Update(model));
      if (success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Delete method for lodgings
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Request success or failure</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.LodgingRepository.Delete(model));
      if (success)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}
