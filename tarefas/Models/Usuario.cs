using tarefas.Enums;

namespace tarefas.Models;

public class Usuario
{
    public Usuario(PerfilAcessoEnum perfilAcesso, string nome, string email)
    {
        Id = Guid.NewGuid().ToString();
        PerfilAcesso = perfilAcesso;
        Nome = nome;
        Email = email;
        Senha = GerarSenhaAleatoria();
        Colaborador = new Colaborador(idUsuario: Id);
    }

    public string Id { get; }
    public PerfilAcessoEnum PerfilAcesso { get; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Senha { get; private set; }

    public Colaborador Colaborador { get; private set; }

    public void AlterarDadosCadastrais(string nome, DateTime dataNascimento, string email)
    {
        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;
    }

    public void AlterarSenha(string novaSenha)
    {
        if (string.IsNullOrEmpty(novaSenha) || novaSenha.Length < 6)
        {
            Console.WriteLine("A senha deve conter pelo menos 6 caracteres.");
            return;
        }

        Senha = novaSenha;
    }

    public override string ToString()
    {
        string textoApresentacao = string.IsNullOrEmpty(Colaborador.IdSuperior)
            ? $" Id: {Id}, Nome: {Nome}, Email: {Email}"
            : $" Id: {Id}, Nome: {Nome}, Email: {Email}, Código Superior {Colaborador.ObterCodigoGerenteResponsavelFormatado()}";

        return textoApresentacao;
    }

    public void DefinirSuperiorDiretoDoColaborador(string id) => Colaborador.DefinirSuperiorDireto(id);

    private string GerarSenhaAleatoria()
    {
        Guid guidSenha = Guid.NewGuid(); // Cria uma hash aleatória usando o Guid, que é um identificador único global. Ele gera uma string única a cada vez que é chamado.
        string senhaAleatoria = guidSenha.ToString().Substring(1, 7);

        return senhaAleatoria;
    }

}
