namespace GestaoLogistica.Models;

public class Cliente
{
    public Cliente(string nome, string email, string cpf, string telefone)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Cpf = cpf;
        Telefone = telefone;
    }

    public Guid Id { get; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Cpf { get; private set; }
    public string Telefone { get; private set; }

    public void AtualizarDados(string nome, string email, string cpf, string telefone)
    {
        Nome = nome;
        Email = email;
        Cpf = cpf;
        Telefone = telefone;
    }

    public override string ToString()
    {
        return $"Id: {Id} | Nome: {Nome} | E-mail: {Email} | CPF: {Cpf} | Telefone: {Telefone}";
    }
}
