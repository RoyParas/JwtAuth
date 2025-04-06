using System.ComponentModel.DataAnnotations;

public class SignUp {
    [Required(ErrorMessage = "Provide Email")]
    public string? Email {get; set;}

    [Required(ErrorMessage = "Provide Password")]
    public string? Password {get; set;}

    [Required(ErrorMessage = "Provide Password Again")]
    [Compare("Password")]
    public string? ConfirmPassword {get; set;}
}