using LojaVirtual.Models;

namespace LojaVirtual.Repositories;

public class CategoriaRepository
{
    private static readonly List<Categoria> _categorias = [];

    public static void AdicionaCategoriaNaLista(Categoria categoria) => _categorias.Add(categoria);

    public static List<Categoria> RetornaLista() => _categorias;
}
