using LojaVirtual.Enums;

namespace LojaVirtual.Models;

public class Categoria
{
    public Categoria(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        StatusCategoria = StatusCategoriaEnum.Ativo;
    }

    public Guid Id { get; }
    public string Nome { get; private set; }
    public StatusCategoriaEnum StatusCategoria { get; private set; }

    public override string ToString() => $"Id: {Id} | Nome: {Nome} | Status Categoria:{StatusCategoria}";

}
