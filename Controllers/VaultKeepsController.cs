using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;
    public VaultKeepsController(VaultKeepRepository repo)
    {
      _repo = repo;
    }

    //Get
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> GetbyId(int id)
    {
      var userId = HttpContext.User.Identity.Name;
      var result = _repo.GetKeepsByVaultId(id, userId);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep value)
    {
      value.UserId = HttpContext.User.Identity.Name;
      _repo.AddThing(value);
      return value;
    }

    // PUT api/values/5
    // [HttpPut("{id}")]
    // public ActionResult<VaultKeep> Put(int id, [FromBody] VaultKeep value)
    // {
    //   if (value.Id == 0)
    //   {
    //     value.Id = id;
    //   }
    //   VaultKeep result = _repo.EditThing(id, value);
    //   if (result != null)
    //   {
    //     return Ok(result);
    //   }
    //   return NotFound();
    // }

    // DELETE api/values/5
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(VaultKeep vk)
    {
      if (_repo.DeleteThing(vk))
      {
        return Ok("successfully deleted vaultkeep");
      }
      return BadRequest("Can't Delete");
    }
  }
}