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
        Colaborador = CriarColaborador(perfilAcesso, nome, dataNascimento); // new Colaborador(idUsuario: Id, nome, dataNascimento);

        // TODO: Criar um método para que o nosso perfil de acesso defina qual é a instância do colaborador
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
        // Return inicial de colaborador
        // return Colaborador?.Superior is null
        //     ? $" Id: {Id}, Nome: {Colaborador.Nome}, Email: {Email}"
        //     : $" Id: {Id}, Nome: {Colaborador.Nome}, Email: {Email}, Nome do Superior {Colaborador.Superior.Nome}";

        string stringColaborador = Colaborador?.ToString();

        return string.IsNullOrEmpty(stringColaborador)
            ? $"Email: {Email}, Perfil de Acesso: {PerfilAcesso}" // Retornará no caso do Adm
            : Colaborador.Superior is null
                ? $"{stringColaborador}, Email: {Email}" // Retornará o colaborador sem superior
                : stringColaborador; // Retornará o colaborador sem superior
    }

    public void DefinirSuperiorDiretoDoColaborador(Colaborador colaborador) => Colaborador.DefinirSuperiorDireto(colaborador);

    private string GerarSenhaAleatoria() => Guid.NewGuid().ToString().Substring(1, 7);
    // Cria uma hash aleatória usando o Guid, que é um identificador único global. Ele gera uma string única a cada vez que é chamado.

    private Colaborador CriarColaborador(PerfilAcessoEnum perfilAcesso, string nome, DateTime dataNascimento)
    {
        return perfilAcesso switch
        {
            PerfilAcessoEnum.Gerente => new Gerente(Id, nome, dataNascimento),
            PerfilAcessoEnum.Funcionario => new Funcionario(Id, nome, dataNascimento),
            _ => null
        };
    }
}
