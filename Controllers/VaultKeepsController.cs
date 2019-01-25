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

  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;
    public VaultKeepsController(VaultKeepRepository repo)
    {
      _repo = repo;
    }

    //get VKs
    [Authorize]
    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<Keep>> GetVaultKeeps(int vaultId)
    {
      var userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> result = _repo.GetVaultKeeps(vaultId, userId);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    //Add VKs
    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeep> AddVaultKeep([FromBody] VaultKeep vaultKeep)
    {
      vaultKeep.UserId = HttpContext.User.Identity.Name;
      VaultKeep result = _repo.AddVaultKeep(vaultKeep);
      return Created("/api/vaultkeeps/" + result.Id, result);
    }

    //Delete VKs

    [HttpDelete("{vaultId}/{keepId}")]
    public ActionResult<string> DeleteVaultKeep(int vaultId, int keepId)
    {
      var userId = HttpContext.User.Identity.Name;
      if (_repo.DeleteVaultKeep(vaultId, keepId, userId))
      {
        return Ok("deleted");
      }
      return BadRequest();
    }


  }
}