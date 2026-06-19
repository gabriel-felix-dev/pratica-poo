namespace TransportadoraTranslogica.Models;

public class Cliente(string nome, string telefone, string documento)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Nome { get; private set; } = nome;
    public string Telefone { get; private set; } = telefone;
    public string Documento { get; private set; } = documento;

    public void AlterarDados(string nome, string telefone)
    {
        Nome = nome;
        Telefone = telefone;
    }

    public void AlterarDocumento(string documento) => Documento = documento;

    public override string ToString() => $"Id: {Id} | Cliente: {Nome} | {(Documento.Length == 14 ? "CNPJ" : "CPF")}: {Documento} | Telefone: {Telefone}";
}
