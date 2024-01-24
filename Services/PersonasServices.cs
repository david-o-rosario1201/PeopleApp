using Microsoft.EntityFrameworkCore;
using PeopleApp.DAL;
using PeopleApp.Models;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace PeopleApp.Services;

public class PersonasServices
{
	private readonly Contexto _contexto;

	public PersonasServices(Contexto contexto)
	{
		_contexto = contexto;
	}

	public async Task<bool> Crear(Personas persona)
	{
		if (!await Existe(persona.PersonaId))
			return await Insertar(persona);
		else
			return await Modificar(persona);
	}

	public async Task<bool> Existe(int id)
	{
		return await _contexto.Personas.AnyAsync(p => p.PersonaId == id);
	}

	public async Task<bool> Insertar(Personas persona)
	{
		_contexto.Personas.Add(persona);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Personas persona)
	{
		_contexto.Update(persona);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Eliminar(Personas persona)
	{
		var cantidad = await _contexto.Personas
			.Where(p => p.PersonaId == persona.PersonaId)
			.ExecuteDeleteAsync();

		return cantidad > 0;
	}

	public async Task<Personas?> Buscar(Personas persona)
	{
		return await _contexto.Personas
			.AsNoTracking()
			.FirstOrDefaultAsync(p => p.PersonaId == persona.PersonaId);
	}

	public async Task<bool> BuscarNombre(string nombre)
	{
		return await _contexto.Personas.AnyAsync(p => p.Nombre.ToLower() == nombre.ToLower());
	}

	public async Task<List<Personas>> Listar(Expression<Func<Personas, bool>> expression)
	{
		return await _contexto.Personas
			.AsNoTracking()
			.Where(expression)
			.ToListAsync();
	}
}