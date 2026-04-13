namespace tarefas.Models;

public class Colaborador
{
    public Colaborador(string idUsuario)
    {
        Id = Guid.NewGuid().ToString();
        IdUsuario = idUsuario;
    }

    public string Id { get; }
    public string IdUsuario { get; set; }
    public string IdSuperior { get; private set; }

    public void DefinirSuperiorDireto(string idSuperior) => IdSuperior = idSuperior;

    public string ObterCodigoGerenteResponsavelFormatado() => IdSuperior.Substring(1, 7);

}
