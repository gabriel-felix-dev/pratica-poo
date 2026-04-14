using Biblioteca.Enums;

namespace Biblioteca.Models;

public class Usuario
{
    public Usuario(string nome, string email, string telefone)
    {
        Id = ++ContadorId;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        StatusCadastrado = StatusCadastroEnum.Ativo;
        DataCadastro = DateTime.Now;
    }
    //lista de emprestimos
    public static int ContadorId = 0;
    public int Id { get; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public StatusCadastroEnum StatusCadastrado { get; private set; }
    public int LivrosReservados { get; private set; } = 0;
    public DateTime DataCadastro { get; }

    public void AdicinaQuantidadeLivroReservado() => LivrosReservados++;

    public void RemoveLivroDeAluno() => LivrosReservados--;

    public string DeletaAluno()
    {
        if (LivrosReservados > 0)        
            return"Não foi possível excluir o usuário, ele tem livros reservados.";

        StatusCadastrado = StatusCadastroEnum.Inativo;
        return $"\nStatus de cadastro do usuario {Nome} foi alterado!";
    }

    public override string ToString() => $"Id: {Id} | Nome: {Nome} | Email: {Email} | Telefone: {Telefone} | Quantidade de livros reservados: {LivrosReservados} | Status Cadastro: {StatusCadastrado} | Data de Cadastro: {DataCadastro}";

}
