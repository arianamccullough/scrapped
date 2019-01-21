using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{


  public class VaultKeep
  {
    public int Id { get; set; }

    public string UserId { get; set; }
    public int KeepId { get; set; }
    public int VaultId { get; set; }

  }


  public class Vault
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public int Location { get; set; }

  }
}