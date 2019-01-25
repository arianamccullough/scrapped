using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _repo;
    public KeepsController(KeepRepository repo)
    {
      _repo = repo;
    }

    //get all keeps for home page
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> GetHomeKeeps()
    {
      return Ok(_repo.GetHomeKeeps());
    }

    [HttpGet("user")]
    [Authorize]
    public ActionResult<IEnumerable<Keep>> GetMyKeeps()
    {
      var userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> result = _repo.GetMyKeeps(userId);
      return Ok(result);
    }

    [HttpGet("{keepId}")]
    public ActionResult<Keep> GetAKeep(int keepId)
    {
      return Ok(_repo.GetAKeep(keepId));
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Keep> AddKeep(KeepModel setKeep)
    {
      var userId = HttpContext.User.Identity.Name;
      setKeep.UserId = userId;
      return Ok(_repo.AddKeep(setKeep));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> DeleteKeep(int id)
    {
      var userId = HttpContext.User.Identity.Name;
      if (_repo.DeleteKeep(id, userId))
      {
        return Ok("deleted");
      }
      return BadRequest();
    }

    [HttpPut("{id}")]
    public ActionResult<Keep> UpdateKeep(int keepId, [FromBody] Keep editedKeep)
    {
      Keep result = _repo.UpdateKeep(keepId, editedKeep);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }
  }
}