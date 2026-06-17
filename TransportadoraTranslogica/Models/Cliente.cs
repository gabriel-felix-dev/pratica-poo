namespace Models;

public class Cliente
{
    public string Documento { get; private set; }
    public string Nome { get; private set; }
    public string Telefone { get; private set; }
    public string Cidade { get; private set; }
    public string Segmento { get; private set; }
    public bool Vip { get; private set; }

    public Cliente(string documento, string nome, string telefone,
                   string cidade, string segmento, bool vip = false)
    {
        Documento = documento;
        Nome = nome;
        Telefone = telefone;
        Cidade = cidade;
        Segmento = segmento;
        Vip = vip;
    }

    public override string ToString() =>
        $"{Nome} | {Documento} | {Cidade} | {Segmento} | VIP: {(Vip ? "Sim" : "Não")}";
}
