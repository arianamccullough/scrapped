using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{

  public class VaultModel
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Location { get; set; }

  }

  //Vault Class
  public class Vault
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Location { get; set; }
  }
  //VaultKeep Class
  public class VaultKeep
  {
    public int Id { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
    public string UserId { get; set; }
    public int Location { get; set; }
  }
}