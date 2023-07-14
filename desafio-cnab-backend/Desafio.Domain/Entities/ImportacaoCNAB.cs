using System;
namespace Desafio.Domain.Entities;

public class ImportacaoCNAB : BaseEntity
{
	public int Tipo { get; set; }
	public DateTime Data { get; set; }
	public Decimal Valor { get; set; }
	public string Cpf { get; set; }
	public string Cartao { get; set; }
	public DateTime Hora { get; set; }
	public string RepresentanteLoja { get; set; }
	public string Loja { get; set; }
}

