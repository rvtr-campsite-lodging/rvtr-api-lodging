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
  /// API Controller for interacting with Bathrooms
  /// </summary>
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class BathroomController : ControllerBase
  {
    private readonly ILogger<BathroomController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public BathroomController(ILogger<BathroomController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Action method to get all instances of bathrooms
    /// </summary>
    /// <returns>Returns an enumerable of bathrooms</returns>
    [HttpGet]
    public async Task<IEnumerable<BathroomModel>> Get()
    {
      return await Task.FromResult<IEnumerable<BathroomModel>>(_unitOfWork.BathroomRepository.Select());
    }

    /// <summary>
    /// Action method to get an instance of bathroom by id
    /// </summary>
    /// <param name="id">The identifier for the bathroom</param>
    /// <returns>The bathroom corresponding to the id</returns>
    [HttpGet("{id}")]
    public async Task<BathroomModel> Get(int id)
    {
      return await Task.FromResult<BathroomModel>(_unitOfWork.BathroomRepository.Select(id));
    }

    /// <summary>
    /// Action method to post an instance of a bathroom to storage domain
    /// </summary>
    /// <param name="model">The model being added</param>
    /// <returns>ActionResult denoting success or failure</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]BathroomModel model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.BathroomRepository.Insert(model));
      if (success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Action method to update an existing bathroom model
    /// </summary>
    /// <param name="model">The updated model to update</param>
    /// <returns>ActionResult denoting success or failure</returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]BathroomModel model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.BathroomRepository.Update(model));
            if (success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Action method to delete a bathroom model from storage domain
    /// </summary>
    /// <param name="model">The bathroom model to be deleted</param>
    /// <returns>ActionResult denoting success or failure</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.BathroomRepository.Delete(model));
      if (success)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}
