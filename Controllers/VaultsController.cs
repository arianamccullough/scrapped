using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _repo;
    public VaultsController(VaultRepository repo)
    {
      _repo = repo;
    }

    // GET api/values
    [HttpGet]

    public ActionResult<IEnumerable<Vault>> Get()
    {

      return Ok(_repo.GetAll());
    }

    // GET api/values/5
    [HttpGet("{id}")]

    public ActionResult<IEnumerable<Vault>> Get(int id)
    {
      var uid = HttpContext.User.Identity.Name;
      Vault result = _repo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault value)
    {
      Vault result = _repo.AddThing(value);
      return Created("/api/vaults/" + result.Id, result);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Vault> Put(int id, [FromBody] Vault value)
    {
      if (value.Id == 0)
      {
        value.Id = id;
      }
      Vault result = _repo.EditThing(id, value);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_repo.DeleteThing(id))
      {
        return Ok("success");
      }
      return BadRequest("Can't Delete");
    }
  }
}