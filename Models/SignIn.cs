using System.ComponentModel.DataAnnotations;
public class SignIn{
    [Required(ErrorMessage = "Provide Email")]
    public string? Email {get; set;}

    [Required(ErrorMessage = "Provide Password")]
    public string? Password {get; set;}
}