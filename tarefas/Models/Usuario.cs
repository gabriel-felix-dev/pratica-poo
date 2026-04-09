using tarefas.Enums;

namespace tarefas.Models;

public class Usuario
{
    public Usuario(int id, PerfilAcessoEnum perfilAcesso, string nome, string email)
    {
        Id = id;
        PerfilAcesso = perfilAcesso;
        Nome = nome;
        Email = email;
        Senha = GerarSenhaAleatoria();
    }

    // ### => Pesquisar sobre enumerable e seu métodos - Exemplo: Count, Contains, Any
    // ### => Pesquisar sobre Guid

    // Encapsulamento: O encapsulamente garante que modificadores de acesso não alterem os atributos de uma classe diretamente.
    //      |=> Com isso podemos garantir a segurança dos atributos da classe

    public int Id { get; } // Propriedade somente de leitura. Ela só pode ser preenchida a partir do construtor
    public PerfilAcessoEnum PerfilAcesso { get; }
    public string Nome { get; private set; } // Propriedades com private set só podem ser alteradas dentro da classe. Fora dela só pode ser feito com métodos.
    public string Email { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Senha { get; private set; }

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
        return $" Nome: {Nome}, Email: {Email}";
    }

    private string GerarSenhaAleatoria()
    {
        Guid guidSenha = Guid.NewGuid(); // Cria uma hash aleatória usando o Guid, que é um identificador único global. Ele gera uma string única a cada vez que é chamado.
        string senhaAleatoria = guidSenha.ToString().Substring(1, 7);

        return senhaAleatoria + Id.ToString();
    }

}
