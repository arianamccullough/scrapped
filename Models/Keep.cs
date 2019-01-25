using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class KeepModel
  {

    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public int Views { get; set; }
    public int Saves { get; set; }
    public int IsPrivate { get; set; }
    public int Location { get; set; }
  }

  public class Keep
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public int Views { get; set; }
    public int Saves { get; set; }
    public int IsPrivate { get; set; }
    public int Location { get; set; }
  }
}