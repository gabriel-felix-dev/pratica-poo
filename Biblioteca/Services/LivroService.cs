using Biblioteca.DTO;
using Biblioteca.Models;
using Biblioteca.Repositories;

namespace Biblioteca.Services;

public class LivroService // a service pode criar um obj
{
    public LivroService(LivroRepository livroRepositoryConstrutor)
    {
        _livroRepository = livroRepositoryConstrutor;
    }

    private LivroRepository _livroRepository;

    public void CadastrarLivro(LivroDTO dto)
    {
        // if(dto.NomeAutor == "joão") => regra de negócio viria aqui é validada aqui

        Livro livro = new Livro(dto.NomeLivro, dto.NomeAutor);

        _livroRepository.AdicionarLivro(livro); // Para poder acessar o Repository é necessário instanciar ele. 
                                                // Ele é instanciado na Program
    }
}
