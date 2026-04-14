using tarefas.Enums;

namespace tarefas.Models;

public class Usuario
{
    public Usuario(PerfilAcessoEnum perfilAcesso, string nome, string email, DateTime dataNascimento)
    {
        Id = Guid.NewGuid().ToString();
        PerfilAcesso = perfilAcesso;
        Email = email;
        Senha = GerarSenhaAleatoria();
        Colaborador = new Colaborador(idUsuario: Id, nome, dataNascimento);
        // TODO: Criar um método para o perfil de acesso defina qual a instância do colaborador
        //  seja ele gerente ou funcionario, OU SEJA, definir qual o tipo será instanciado
    }

    public string Id { get; }
    public PerfilAcessoEnum PerfilAcesso { get; }
    public string Email { get; private set; }
    public string Senha { get; private set; }

    public Colaborador Colaborador { get; private set; }

    public void AlterarDadosCadastrais(string nome, DateTime dataNascimento, string email)
    {
        Email = email;
        Colaborador.AtualizarDadosPessoais(nome, dataNascimento);
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
            ? $" Id: {Id}, Nome: {Colaborador.Nome}, Email: {Email}"
            : $" Id: {Id}, Nome: {Colaborador.Nome}, Email: {Email}, Código Superior {Colaborador.ObterCodigoGerenteResponsavelFormatado()}";

        return textoApresentacao;
    }

    public void DefinirSuperiorDiretoDoColaborador(Colaborador colaborador) => Colaborador.DefinirSuperiorDireto(colaborador.Id);

    private string GerarSenhaAleatoria() => Guid.NewGuid().ToString().Substring(1, 7); // Cria uma hash aleatória usando o Guid, que é um identificador único global. Ele gera uma string única a cada vez que é chamado.
}
