using System.Runtime.CompilerServices;

namespace biblioteca_leia_mais.Models;

public class Usuario
{
    public Usuario(string nome)
    {
        Id = ++ContadorId;
        Nome = nome;
    }

    public static int ContadorId = 0;
    public int Id { get; }
    public String Nome { get; private set; }
    public int QuantidadeLivrosReservados { get; private set; }

    public override string ToString()
    {
        return $"Id: {Id} | Nome: {Nome} | Quantidade de Livros Reservados: {QuantidadeLivrosReservados}";
    }

    public void AdicionaLivrosReservados()
    {
        QuantidadeLivrosReservados++;
    }
}
