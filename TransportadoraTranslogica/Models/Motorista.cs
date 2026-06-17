using Enums;

namespace Models;

public class Motorista
{
    public string Cnh { get; private set; }
    public string Nome { get; private set; }
    public CategoriaCnhEnum Categoria { get; private set; }
    public int AnosExperiencia { get; private set; }
    public string CidadeBase { get; private set; }
    public bool Ativo { get; private set; }

    public Motorista(string cnh, string nome, CategoriaCnhEnum categoria,
                     int anosExperiencia, string cidadeBase, bool ativo = true)
    {
        Cnh = cnh;
        Nome = nome;
        Categoria = categoria;
        AnosExperiencia = anosExperiencia;
        CidadeBase = cidadeBase;
        Ativo = ativo;
    }

    public override string ToString() =>
        $"{Nome} | CNH {Cnh} | Categoria {Categoria} | {AnosExperiencia} anos";
}
