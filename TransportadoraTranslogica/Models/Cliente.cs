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

    public override string ToString() => $"Id: {Id} | Cliente: {Nome} | {(Documento.Length == 14 ? "CNPJ" : "CPF")}: {(Documento.Length == 14 ? $"{Documento.Substring(0, 2)}.{Documento.Substring(2, 3)}.{Documento.Substring(5, 3)}/{Documento.Substring(7, 4)}-{Documento.Substring(12, 2)}" : $"{Documento.Substring(0, 3)}.{Documento.Substring(3, 3)}.{Documento.Substring(6, 3)}-{Documento.Substring(9, 2)}")} | Telefone: ({Telefone.Substring(0, 2)}) {Telefone.Substring(2, 1)} {Telefone.Substring(3, 4)}-{Telefone.Substring(7, 4)}";
}
