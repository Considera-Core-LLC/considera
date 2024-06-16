using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsideraDevApi.Core.Interfaces;

namespace ConsideraDevApi.Core.Models.MusiqueHub;

[Table("Users")]
public class User : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public User()
    {
        Username = "";
        Password = "";
    }
}