using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsideraDevApi.Core.Interfaces;

namespace ConsideraDevApi.Core.Models.MusiqueHub;

[Table("Users")]
public class UserProtected : IEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public bool IsLoggedIn { get; set; }

    public UserProtected()
    {
        Username = "";
    }

    public UserProtected(bool isLoggedIn)
    {
        IsLoggedIn = isLoggedIn;
        Username = "";
    }
}