using Microsoft.EntityFrameworkCore;
namespace AllergyMatchMaker.Models
{
  public class AllergyInfoContext :DbContext
  {
    public AllergyInfoContext(DbContextOptions<AllergyInfoContext> options) 
    :base(options)
    {

    }
    public DbSet<AllergyInfo> AllergyInfos { get; set; }
    
  }
}