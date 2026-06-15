using MedConsulta.Enums;

namespace MedConsulta.Models;

public class Medico(string crm, string nome, EspecialidadeEnum especialidade)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Crm { get; private set; } = crm;
    public string Nome { get; private set; } = nome;
    public EspecialidadeEnum Especialidade { get; private set; } = especialidade;

    public void AtulizarDados(string nome, EspecialidadeEnum especialidade)
    {
        Nome = nome;
        Especialidade = especialidade;
    }

    public void AtulizarCrm(string crm) => Crm = crm;

    public override string ToString() => $"Id: {Id} | Médico: {Nome} | CRM: {Crm} | Especialidade: {Especialidade}";
}
