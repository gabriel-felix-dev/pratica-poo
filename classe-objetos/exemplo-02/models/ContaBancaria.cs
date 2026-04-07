using Exemplo2.Models.Transacao;
namespace Exemplo2.Models;

class ContaBancaria
{
    private string _numeroConta;
    private decimal _saldo;
    private string _titular;
    private List<Transacao> _historico;

    public string NumeroConta
    {
        get { return _numeroConta; }
        private set { _numeroConta = value; }
    }

    public decimal Saldo
    {
        get { return _saldo; }
        private set { _saldo = value; }
    }

    public string Titular
    {
        get { return _titular; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Titular obrigatório");
            _titular = value;
        }
    }

    //Somente leitura
    public IReadOnlyList<Transacao> Historico
    {
        get { return _historico.AsReadOnly(); }
    }

    public ContaBancaria(string numeroConta, string titular, decimal saldoInicial = 0)
    {
        if (string.IsNullOrWhiteSpace(numeroConta))
            throw new ArgumentException("Numero da conta obrigatório");

        NumeroConta = numeroConta;
        Titular = titular;
        Saldo = saldoInicial;
        _historico = new List<Transacao>();

        if (saldoInicial > 0)
            RegistrarTransacao("Deposito inicial", saldoInicial);
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Valor dese ver positivo");

        Saldo += valor;
        RegistrarTransacao("Deposito", valor);

        Console.WriteLine($"Deposito de {valor:c} realizado. Saldo: {Saldo:c}.");
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Valor deve ser positivo");

        if (valor > Saldo)
            throw new InvalidOperationException("Saldo insuficiente");

        Saldo -= valor;
        RegistrarTransacao("Saque", -valor);

        Console.WriteLine($"Saque de {valor:c} realizado. Saldo: {Saldo:c}");
    }

    public void Transferir(ContaBancaria contaDestino, decimal valor)
    {
        if (contaDestino == null)
            throw new ArgumentNullException(nameof(contaDestino));

        Sacar(valor);
        contaDestino.Depositar(valor);

        Console.WriteLine($"Transferencia de {valor:c} para conta {contaDestino.NumeroConta} realizada");
    }

    public void ExibirExtrato()
    {
        Console.WriteLine($"\n=== Extrato da Conta {NumeroConta} ===");
        Console.WriteLine($"Titular: {Titular}");
        Console.WriteLine($"Saldo Atual: {Saldo:c}\n");
        Console.WriteLine($"Historico de Transacoes:");

        foreach (var Transacao in _historico)
            Console.WriteLine($"{transacao.Data:dd/MM/yyyy HH:mm} - {transacao.Descricao}: {transacao.Valor:c}");

        Console.Write("=====================================\n");
    }

    Transacao transacao = new Transacao();

    private void RegistrarTransacao(string descricao, decimal valor)
    {
        _historico.Add(new Transacao
        {
            Data = DateTime.Now,
            Descricao = descricao,
            Valor = valor
        });
    }
}


