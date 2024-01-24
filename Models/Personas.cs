using System.ComponentModel.DataAnnotations;

namespace PeopleApp.Models;

public class Personas
{
	[Key]
	public int PersonaId { get; set; }

	[Required(ErrorMessage = "Por favor, ingrese un nombre")]
	public string Nombre { get; set; }

	[Phone(ErrorMessage = "El formato no es valido")]
	[Required(ErrorMessage = "Por favor, ingrese un numero de telefono")]
	public string Telefono { get; set; }
}
