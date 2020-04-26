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
  public class ReviewController : ControllerBase
  {
    private readonly ILogger<ReviewController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewController(ILogger<ReviewController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ReviewModel> Get()
    {
      return await Task.FromResult<ReviewModel>(new ReviewModel());
    }

    public async Task<ReviewModel> Get(int id)
    {
      return await Task.FromResult<ReviewModel>(new ReviewModel());
    }

    [HttpPost]
    public async Task<ReviewModel> Post()
    {

    }

    [HttpPut]
    public async Task<ReviewModel> Put()
    {

    }

    [HttpDelete]
    public async Task<ReviewModel> Delete(int id)
    {

    }
  }
}
