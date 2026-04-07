namespace Exemplo01.Models;

class Pessoa
{
    private string _nome;
    private int _idade;
    private string _email;

    public string Nome
    {
        get { return _nome; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Nome não pode ser vazio");

            _nome = value;
        }
    }

    public int Idade
    {
        get { return _idade; }
        set
        {
            if (value < 0 || value > 150)
                throw new ArgumentException("Idade inválida");

            _idade = value;
        }
    }

    public string Email
    {
        get { return _email; }
        set
        {
            if (!value.Contains("@"))
                throw new ArgumentException("Email inválido");

            _email = value;
        }
    }

    public Pessoa()
    {
        _nome = "Sem nome";
        _idade = 0;
        _email = "sem@email.com";
    }

    public Pessoa(string nome, int idade, string email)
    {
        Nome = nome;
        Idade = idade;
        Email = email;
    }

    public void ApresentarSe()
    {
        Console.WriteLine($"Olá, meu nome é {Nome} e tenho {Idade} anos.");
    }

    public void FazerAniversario()
    {
        Idade++;
        Console.WriteLine($"Feliz aniversário! Agora tenho {Idade} anos.");
    }
    public void AtualizarEmail(string novoEmail)
    {
        Email = novoEmail;
        Console.WriteLine($"Email atualizado para: {Email}");
    }

    public bool EMaiorDeIdade()
    {
        return Idade >= 18;
    }

    public override string ToString()
    {
        return $"Pessoa: {Nome}, {Idade} anos, {Email}";
    }
}
