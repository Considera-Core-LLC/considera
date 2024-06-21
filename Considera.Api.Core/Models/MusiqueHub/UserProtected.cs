using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Considera.Api.Core.Interfaces;

namespace Considera.Api.Core.Models.MusiqueHub;

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