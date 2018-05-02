using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

public class LoginModel
{
    public int Id { get; set; }
    [Required]
    [Display(Name = "User name")]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }


    //list db
    public class LogDBContext : DbContext
    {
        public DbSet<LoginModel> LoginModels { get; set; }
    }


}
