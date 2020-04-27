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
  /// API controller to enable storage domain interation for Address models
  /// </summary>
  [ApiController]
  [EnableCors()]
  [Route("[controller]/[action]")]
  public class AddressController : ControllerBase
  {
    private readonly ILogger<AddressController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public AddressController(ILogger<AddressController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Get a list of all address models in storage domain
    /// </summary>
    /// <returns>An enumerabl< of all address models/returns>
    [HttpGet]
    public async Task<IEnumerable<AddressModel>> Get()
    {
      return await Task.FromResult<IEnumerable<AddressModel>>(_unitOfWork.AddressRepository.Select());
    }

    /// <summary>
    /// Get an instance of address model from domain storage using an identifier
    /// </summary>
    /// <param name="id">Unique identifier for model to be returned</param>
    /// <returns>An address model matching the given id</returns>
    [HttpGet("{id}")]
    public async Task<AddressModel> Get(int id)
    {
      return await Task.FromResult<AddressModel>(_unitOfWork.AddressRepository.Select(id));
    }

    /// <summary>
    /// Post an address model to storage domain
    /// </summary>
    /// <param name="model">The address model to be posted</param>
    /// <returns>An ActionResult denoting success or failure</returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]AddressModel model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.AddressRepository.Insert(model));
      if (success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Update an address model already in the storage domain
    /// </summary>
    /// <param name="model">The updated model to the changed</param>
    /// <returns>An ActionResult denoting success or failure</returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]AddressModel model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.AddressRepository.Update(model));
            if (success)
      {
        return Ok();
      }
      return BadRequest();
    }

    /// <summary>
    /// Delete an address model from the storage domain
    /// </summary>
    /// <param name="model">The identifier of the model to be deleted</param>
    /// <returns>An ActionResult denoting success or failure</returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(int model)
    {
      var success = await Task.FromResult<bool>(_unitOfWork.AddressRepository.Delete(model));
      if (success)
      {
        return Ok();
      }
      return BadRequest();
    }
  }
}
