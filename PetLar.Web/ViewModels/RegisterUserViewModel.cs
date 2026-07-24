using System.ComponentModel.DataAnnotations;

namespace PetLar.Web.ViewModels;

public class RegisterUserViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [Display(Name = "Nome da ONG / Responsável")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Digite um formato de e-mail válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
