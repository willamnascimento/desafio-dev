using System;
namespace Desafio.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime DataImportacao { get; set; }
}

