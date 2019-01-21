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
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _repo;
    public KeepsController(KeepRepository repo)
    {
      _repo = repo;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {

      return Ok(_repo.GetAll());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      Keep result = _repo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep value)
    {
      value.UserId = HttpContext.User.Identity.Name;
      Keep result = _repo.AddThing(value);
      return Created("/api/keeps/" + result.Id, result);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep value)
    {
      if (value.Id == 0)
      {
        value.Id = id;
      }
      Keep result = _repo.EditThing(id, value);
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