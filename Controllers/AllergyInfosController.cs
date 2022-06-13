using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllergyMatchMaker.Models;
using System.Linq;
namespace AllergyMatchMaker.Controllers
{
  
  [Produces("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  public class AllergyInfosController :ControllerBase
  {
    private readonly AllergyInfoContext _db;
    public AllergyInfosController(AllergyInfoContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<List<AllergyInfo>> Get()
    {

      var  query = await _db.AllergyInfos.ToListAsync();
      return query;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<AllergyInfo>> GetBusiness(int id)
    {
      var allergyinfo = await _db.AllergyInfos.FindAsync(id);
      if(allergyinfo == null)
      {
        return NotFound();
      }
      return allergyinfo;

    }

    [HttpPost]
    public async Task<ActionResult<AllergyInfo>> Post(AllergyInfo allergyinfo)
    {
      _db.AllergyInfos.Add(allergyinfo);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetBusiness),new{id=allergyinfo.AllergyInfoId},allergyinfo);
    } 
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, AllergyInfo allergyinfo )
    { 
      if(id!=allergyinfo.AllergyInfoId)
      {
        return BadRequest();
      }
      _db.Entry(allergyinfo).State =EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch(DbUpdateConcurrencyException)
      {
        if(!LocalBusinessExists(id))
        {
          return  NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();

    }
    private bool LocalBusinessExists(int id )
    {
      return _db.AllergyInfos.Any(entry=>entry.AllergyInfoId ==id);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var allergyinfo =await _db.AllergyInfos.FindAsync(id);
      if(allergyinfo == null)
      {
        return NotFound();
      }
      _db.AllergyInfos.Remove(allergyinfo);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}
