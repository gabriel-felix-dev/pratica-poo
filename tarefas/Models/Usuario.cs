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

    public override string ToString()
    {
        return $" Nome: {Nome}, Email: {Email}";
    }

    private string GerarSenhaAleatoria()
    {
        var random = new Random();
        var caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var senha = new char[8];

        for (int i = 0; i < senha.Length; i++)
            senha[i] = caracteres[random.Next(caracteres.Length)];

        return new string(senha);
    }

}
