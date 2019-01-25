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

  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _repo;
    public VaultsController(VaultRepository vaultRepo)
    {
      _repo = vaultRepo;
    }

    //GetUsersVaults
    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Vault>> GetUserVaults()
    {
      var id = HttpContext.User.Identity.Name;
      IEnumerable<Vault> result = _repo.GetUserVaults(id);
      return Ok(result);

    }

    //GetVaultByVaultID
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Vault> GetById(int id)
    {
      var uId = HttpContext.User.Identity.Name;
      Vault result = _repo.GetById(id, uId);
      return Ok(result);
    }



    //addVault
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> AddVault(VaultModel vault)
    {
      var id = HttpContext.User.Identity.Name;
      vault.UserId = id;
      return Ok(_repo.AddVault(vault));
    }


    //delete vault
    [Authorize]
    [HttpDelete("{vaultId}")]
    public ActionResult<string> DeleteVault(int vaultId)
    {
      var id = HttpContext.User.Identity.Name;
      if (_repo.DeleteVault(vaultId, id))
      {
        return Ok("Successfully deleted");
      }
      return BadRequest("Unable to delete");
    }





  }
}