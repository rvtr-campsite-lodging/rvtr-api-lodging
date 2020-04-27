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
  /// API controller that allows bedroom models to interact with the storage domain
  /// </summary>
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class BedroomController : ControllerBase
  {
    private readonly ILogger<RentalController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public BedroomController(ILogger<RentalController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Get all instances of bedroom models from the storage domain
    /// </summary>
    /// <returns> An enumerable of all bedroom models</returns>
    [HttpGet]
    public async Task<IEnumerable<BedroomModel>> Get()
    {
      return await Task.FromResult<IEnumerable<BedroomModel>>(_unitOfWork.BedroomRepository.Select());
    }

    /// <summary>
    /// Get an individual bedroom model based on given id
    /// </summary>
    /// <param name="id">Unique identifier for a given bedroom model</param>
    /// <returns>A bedroom model</returns>
    [HttpGet]
    public async Task<BedroomModel> Get(int id)
    {
      return await Task.FromResult<BedroomModel>(_unitOfWork.BedroomRepository.Select(id));
    }

    /// <summary>
    /// Post a bedroom model to the storage domain
    /// </summary>
    /// <param name="model">The model to be added to the storage domain</param>
    /// <returns>An ActionResult denoting success or failure</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]BedroomModel model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.BedroomRepository.Insert(model));
      if (success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Update an existing bedroom model in the storage domain
    /// </summary>
    /// <param name="model">The updated model to be placed in storage</param>
    /// <returns>An ActionResult denoting success or failure</returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]BedroomModel model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.BedroomRepository.Update(model));
            if (success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Deletean existing bedroom model from the storage domain
    /// </summary>
    /// <param name="model">The identifier for the bedroom model to be deleted</param>
    /// <returns>An ActionResult denoting success or failure</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.BedroomRepository.Delete(model));
      if (success)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}
