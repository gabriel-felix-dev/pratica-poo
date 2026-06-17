# 60 Exercícios de LINQ em C# — TransLógica
### Transportadora com motoristas, clientes, viagens, roteiros e cargas

> **Contexto:** Você foi contratado como desenvolvedor júnior da **TransLógica**, uma transportadora que controla motoristas, clientes, viagens com roteiros de paradas e cargas vinculadas a cada viagem. O sistema já possui classes, enums e listas pré-carregadas. **Sua tarefa:** implementar apenas as consultas LINQ pedidas em cada exercício.

> **Regra da lista:** cada questão deve usar no mínimo **2 métodos LINQ combinados**. Use preferencialmente sintaxe fluente: `.Where(...)`, `.Select(...)`, `.GroupBy(...)`, `.OrderBy(...)`, `.ToList()`.

---

## Estrutura Base

Crie as pastas:

- `Models`
- `Enums`

Depois coloque cada arquivo abaixo na pasta correspondente.

---

## Enums

### `Enums/CategoriaCnhEnum.cs`
```csharp
namespace Enums;

public enum CategoriaCnhEnum
{
    A,
    B,
    C,
    D,
    E
}
```

### `Enums/StatusViagemEnum.cs`
```csharp
namespace Enums;

public enum StatusViagemEnum
{
    Planejada,
    EmAndamento,
    Concluida,
    Cancelada
}
```

### `Enums/TipoCargaEnum.cs`
```csharp
namespace Enums;

public enum TipoCargaEnum
{
    Padrao,
    Fragil,
    Perigosa,
    Refrigerada,
    Expressa
}
```

### `Enums/StatusCargaEnum.cs`
```csharp
namespace Enums;

public enum StatusCargaEnum
{
    Pendente,
    EmTransito,
    Entregue,
    Cancelada
}
```

### `Enums/TipoDestinoEnum.cs`
```csharp
namespace Enums;

public enum TipoDestinoEnum
{
    ParadaRoteiro,
    EnderecoDireto
}
```

---

## Models

### `Models/Motorista.cs`
```csharp
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
```

### `Models/Cliente.cs`
```csharp
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
```

### `Models/Viagem.cs`
```csharp
using Enums;

namespace Models;

public class Viagem
{
    public string Codigo { get; private set; }
    public Motorista Motorista { get; private set; }
    public string PlacaVeiculo { get; private set; }
    public string ModeloVeiculo { get; private set; }
    public double CapacidadeKg { get; private set; }
    public string FilialOrigem { get; private set; }
    public DateTime DataSaida { get; private set; }
    public DateTime? DataChegada { get; private set; }
    public int KmInicial { get; private set; }
    public int? KmFinal { get; private set; }
    public StatusViagemEnum Status { get; private set; }
    public List<string> RoteiroCidades { get; private set; }

    public Viagem(string codigo, Motorista motorista, string placaVeiculo,
                  string modeloVeiculo, double capacidadeKg, string filialOrigem,
                  DateTime dataSaida, int kmInicial, List<string> roteiroCidades,
                  StatusViagemEnum status = StatusViagemEnum.Planejada,
                  DateTime? dataChegada = null, int? kmFinal = null)
    {
        Codigo = codigo;
        Motorista = motorista;
        PlacaVeiculo = placaVeiculo;
        ModeloVeiculo = modeloVeiculo;
        CapacidadeKg = capacidadeKg;
        FilialOrigem = filialOrigem;
        DataSaida = dataSaida;
        KmInicial = kmInicial;
        RoteiroCidades = roteiroCidades;
        Status = status;
        DataChegada = dataChegada;
        KmFinal = kmFinal;
    }

    public int? DistanciaPercorrida() =>
        KmFinal.HasValue ? KmFinal.Value - KmInicial : null;

    public override string ToString() =>
        $"{Codigo} | {Motorista.Nome} | {PlacaVeiculo} | {FilialOrigem} | {Status}";
}
```

### `Models/Carga.cs`
```csharp
using Enums;

namespace Models;

public class Carga
{
    public string CodigoRastreio { get; private set; }
    public Cliente Cliente { get; private set; }
    public Viagem Viagem { get; private set; }
    public double PesoKg { get; private set; }
    public decimal ValorDeclarado { get; private set; }
    public TipoCargaEnum Tipo { get; private set; }
    public StatusCargaEnum Status { get; private set; }
    public TipoDestinoEnum TipoDestino { get; private set; }
    public string? CidadeParadaEntrega { get; private set; }
    public string? EnderecoDireto { get; private set; }
    public DateTime DataDespacho { get; private set; }

    public Carga(string codigoRastreio, Cliente cliente, Viagem viagem,
                 double pesoKg, decimal valorDeclarado, TipoCargaEnum tipo,
                 StatusCargaEnum status, TipoDestinoEnum tipoDestino,
                 DateTime dataDespacho, string? cidadeParadaEntrega = null,
                 string? enderecoDireto = null)
    {
        CodigoRastreio = codigoRastreio;
        Cliente = cliente;
        Viagem = viagem;
        PesoKg = pesoKg;
        ValorDeclarado = valorDeclarado;
        Tipo = tipo;
        Status = status;
        TipoDestino = tipoDestino;
        DataDespacho = dataDespacho;
        CidadeParadaEntrega = cidadeParadaEntrega;
        EnderecoDireto = enderecoDireto;
    }

    public string LocalEntrega() =>
        TipoDestino == TipoDestinoEnum.ParadaRoteiro
            ? CidadeParadaEntrega ?? "Parada não informada"
            : EnderecoDireto ?? "Endereço não informado";

    public override string ToString() =>
        $"{CodigoRastreio} | {Cliente.Nome} | {Tipo} | {PesoKg:N1} kg | {Status}";
}
```

---

## Listas Pré-construídas — Cole no `Program.cs`

```csharp
using Models;
using Enums;

// ============================================================
//  MOTORISTAS
// ============================================================
var joao = new Motorista("12345678900", "João Pereira", CategoriaCnhEnum.E, 12, "São Paulo");
var marcia = new Motorista("23456789011", "Márcia Almeida", CategoriaCnhEnum.D, 9, "Curitiba");
var carlos = new Motorista("34567890122", "Carlos Nogueira", CategoriaCnhEnum.E, 15, "Belo Horizonte");
var renata = new Motorista("45678901233", "Renata Lima", CategoriaCnhEnum.C, 6, "Recife");
var diego = new Motorista("56789012344", "Diego Torres", CategoriaCnhEnum.D, 4, "Goiânia");
var sandra = new Motorista("67890123455", "Sandra Costa", CategoriaCnhEnum.E, 18, "Porto Alegre");
var paulo = new Motorista("78901234566", "Paulo Ribeiro", CategoriaCnhEnum.C, 3, "Salvador");
var bia = new Motorista("89012345677", "Beatriz Rocha", CategoriaCnhEnum.B, 2, "Manaus", ativo: false);

var motoristas = new List<Motorista>
{
    joao, marcia, carlos, renata, diego, sandra, paulo, bia
};

// ============================================================
//  CLIENTES
// ============================================================
var clienteTech = new Cliente("11222333000100", "TechNova Equipamentos", "11990000001", "São Paulo", "Tecnologia", true);
var clienteFood = new Cliente("22333444000111", "SaborSul Alimentos", "41990000002", "Curitiba", "Alimentos", true);
var clienteFarm = new Cliente("33444555000122", "VidaMais Farmácia", "31990000003", "Belo Horizonte", "Farmacêutico", true);
var clienteMoveis = new Cliente("44555666000133", "CasaNobre Móveis", "81990000004", "Recife", "Móveis");
var clienteAuto = new Cliente("55666777000144", "AutoPeças Central", "62990000005", "Goiânia", "Automotivo");
var clienteGames = new Cliente("66777888000155", "PixelWare Games", "51990000006", "Porto Alegre", "Tecnologia", true);
var clientePet = new Cliente("77888999000166", "PetFeliz Distribuidora", "71990000007", "Salvador", "Pet");
var clienteModa = new Cliente("88999000000177", "ModaLivre Confecções", "92990000008", "Manaus", "Vestuário");
var clienteQuimica = new Cliente("99000111000188", "Quimix Industrial", "11990000009", "São Paulo", "Químico", true);
var clienteLivros = new Cliente("10111213000199", "Livraria Horizonte", "31990000010", "Belo Horizonte", "Livros");

var clientes = new List<Cliente>
{
    clienteTech, clienteFood, clienteFarm, clienteMoveis, clienteAuto,
    clienteGames, clientePet, clienteModa, clienteQuimica, clienteLivros
};

// ============================================================
//  VIAGENS
// ============================================================
var viagens = new List<Viagem>
{
    new("VIA0001", joao, "TRK1A01", "Volvo FH", 18000, "São Paulo",
        new DateTime(2026, 6, 1, 8, 0, 0), 120000,
        new() { "Campinas", "Ribeirão Preto", "Uberaba" },
        StatusViagemEnum.Concluida, new DateTime(2026, 6, 2, 18, 0, 0), 120980),

    new("VIA0002", marcia, "TRK2B02", "Mercedes Atego", 12000, "Curitiba",
        new DateTime(2026, 6, 3, 7, 30, 0), 84500,
        new() { "Joinville", "Florianópolis" },
        StatusViagemEnum.Concluida, new DateTime(2026, 6, 3, 20, 0, 0), 85180),

    new("VIA0003", carlos, "TRK3C03", "Scania R450", 22000, "Belo Horizonte",
        new DateTime(2026, 6, 4, 6, 0, 0), 210300,
        new() { "Divinópolis", "Uberlândia", "Goiânia" },
        StatusViagemEnum.EmAndamento),

    new("VIA0004", renata, "TRK4D04", "Iveco Daily", 7000, "Recife",
        new DateTime(2026, 6, 5, 9, 0, 0), 45000,
        new() { "Caruaru", "Maceió", "Aracaju" },
        StatusViagemEnum.Planejada),

    new("VIA0005", diego, "TRK5E05", "MAN TGX", 15000, "Goiânia",
        new DateTime(2026, 6, 6, 8, 20, 0), 98000,
        new() { "Anápolis", "Brasília", "Palmas" },
        StatusViagemEnum.EmAndamento),

    new("VIA0006", sandra, "TRK6F06", "DAF XF", 20000, "Porto Alegre",
        new DateTime(2026, 6, 7, 5, 40, 0), 175000,
        new() { "Caxias do Sul", "Lages", "Curitiba" },
        StatusViagemEnum.Concluida, new DateTime(2026, 6, 8, 22, 10, 0), 176120),

    new("VIA0007", paulo, "TRK7G07", "Volks Delivery", 6000, "Salvador",
        new DateTime(2026, 6, 8, 10, 0, 0), 39000,
        new() { "Feira de Santana", "Vitória da Conquista" },
        StatusViagemEnum.Planejada),

    new("VIA0008", joao, "TRK1A01", "Volvo VM", 14000, "São Paulo",
        new DateTime(2026, 6, 9, 13, 0, 0), 121500,
        new() { "Sorocaba", "Bauru", "Marília" },
        StatusViagemEnum.Cancelada),

    new("VIA0009", carlos, "TRK9I09", "Scania P320", 16000, "Belo Horizonte",
        new DateTime(2026, 6, 10, 6, 30, 0), 211000,
        new() { "Juiz de Fora", "Rio de Janeiro" },
        StatusViagemEnum.Planejada),

    new("VIA0010", sandra, "TRK0J10", "DAF CF", 10000, "Porto Alegre",
        new DateTime(2026, 6, 11, 7, 0, 0), 177000,
        new() { "Pelotas", "Rio Grande" },
        StatusViagemEnum.EmAndamento)
};

// ============================================================
//  CARGAS
// ============================================================
var cargas = new List<Carga>
{
    new("CRG0001", clienteTech, viagens[0], 2400, 85000m, TipoCargaEnum.Fragil, StatusCargaEnum.Entregue, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 5, 31), cidadeParadaEntrega: "Campinas"),
    new("CRG0002", clienteQuimica, viagens[0], 5200, 140000m, TipoCargaEnum.Perigosa, StatusCargaEnum.Entregue, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 5, 31), cidadeParadaEntrega: "Uberaba"),
    new("CRG0003", clienteLivros, viagens[0], 1800, 28000m, TipoCargaEnum.Padrao, StatusCargaEnum.Entregue, TipoDestinoEnum.EnderecoDireto, new DateTime(2026, 6, 1), enderecoDireto: "Av. Central, 100 - Ribeirão Preto"),
    new("CRG0004", clienteFood, viagens[1], 3500, 60000m, TipoCargaEnum.Refrigerada, StatusCargaEnum.Entregue, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 6, 2), cidadeParadaEntrega: "Florianópolis"),
    new("CRG0005", clienteModa, viagens[1], 1200, 22000m, TipoCargaEnum.Padrao, StatusCargaEnum.Entregue, TipoDestinoEnum.EnderecoDireto, new DateTime(2026, 6, 2), enderecoDireto: "Rua das Flores, 50 - Joinville"),
    new("CRG0006", clienteFarm, viagens[2], 4200, 110000m, TipoCargaEnum.Fragil, StatusCargaEnum.EmTransito, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 6, 3), cidadeParadaEntrega: "Uberlândia"),
    new("CRG0007", clienteAuto, viagens[2], 7600, 95000m, TipoCargaEnum.Padrao, StatusCargaEnum.EmTransito, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 6, 3), cidadeParadaEntrega: "Goiânia"),
    new("CRG0008", clienteQuimica, viagens[2], 3000, 130000m, TipoCargaEnum.Perigosa, StatusCargaEnum.Pendente, TipoDestinoEnum.EnderecoDireto, new DateTime(2026, 6, 4), enderecoDireto: "Distrito Industrial - Uberlândia"),
    new("CRG0009", clienteMoveis, viagens[3], 2500, 45000m, TipoCargaEnum.Padrao, StatusCargaEnum.Pendente, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 6, 4), cidadeParadaEntrega: "Caruaru"),
    new("CRG0010", clientePet, viagens[3], 900, 18000m, TipoCargaEnum.Expressa, StatusCargaEnum.Pendente, TipoDestinoEnum.EnderecoDireto, new DateTime(2026, 6, 4), enderecoDireto: "Av. Praia, 300 - Maceió"),
    new("CRG0011", clienteAuto, viagens[4], 6100, 88000m, TipoCargaEnum.Padrao, StatusCargaEnum.EmTransito, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 6, 5), cidadeParadaEntrega: "Brasília"),
    new("CRG0012", clienteTech, viagens[4], 1800, 75000m, TipoCargaEnum.Fragil, StatusCargaEnum.EmTransito, TipoDestinoEnum.EnderecoDireto, new DateTime(2026, 6, 5), enderecoDireto: "Setor Comercial, 88 - Palmas"),
    new("CRG0013", clienteGames, viagens[5], 2100, 99000m, TipoCargaEnum.Fragil, StatusCargaEnum.Entregue, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 6, 6), cidadeParadaEntrega: "Curitiba"),
    new("CRG0014", clienteFood, viagens[5], 5300, 72000m, TipoCargaEnum.Refrigerada, StatusCargaEnum.Entregue, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 6, 6), cidadeParadaEntrega: "Lages"),
    new("CRG0015", clienteLivros, viagens[5], 1600, 26000m, TipoCargaEnum.Padrao, StatusCargaEnum.Entregue, TipoDestinoEnum.EnderecoDireto, new DateTime(2026, 6, 7), enderecoDireto: "Rua do Saber, 12 - Caxias do Sul"),
    new("CRG0016", clientePet, viagens[6], 800, 15000m, TipoCargaEnum.Expressa, StatusCargaEnum.Pendente, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 6, 7), cidadeParadaEntrega: "Feira de Santana"),
    new("CRG0017", clienteModa, viagens[6], 1100, 21000m, TipoCargaEnum.Padrao, StatusCargaEnum.Pendente, TipoDestinoEnum.EnderecoDireto, new DateTime(2026, 6, 7), enderecoDireto: "Centro, 44 - Vitória da Conquista"),
    new("CRG0018", clienteQuimica, viagens[8], 4400, 125000m, TipoCargaEnum.Perigosa, StatusCargaEnum.Pendente, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 6, 9), cidadeParadaEntrega: "Rio de Janeiro"),
    new("CRG0019", clienteFarm, viagens[8], 2000, 68000m, TipoCargaEnum.Fragil, StatusCargaEnum.Pendente, TipoDestinoEnum.EnderecoDireto, new DateTime(2026, 6, 9), enderecoDireto: "Av. Saúde, 900 - Juiz de Fora"),
    new("CRG0020", clienteGames, viagens[9], 1300, 52000m, TipoCargaEnum.Expressa, StatusCargaEnum.EmTransito, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 6, 10), cidadeParadaEntrega: "Rio Grande"),
    new("CRG0021", clienteTech, viagens[9], 2600, 91000m, TipoCargaEnum.Fragil, StatusCargaEnum.EmTransito, TipoDestinoEnum.EnderecoDireto, new DateTime(2026, 6, 10), enderecoDireto: "Porto, 77 - Pelotas"),
    new("CRG0022", clienteFood, viagens[3], 2200, 40000m, TipoCargaEnum.Refrigerada, StatusCargaEnum.Cancelada, TipoDestinoEnum.ParadaRoteiro, new DateTime(2026, 6, 5), cidadeParadaEntrega: "Aracaju")
};
```

---

# Questões

## Nível 1 — Aquecimento

### [QUESTÃO 1 — Clientes VIP em ordem alfabética]

Liste todos os clientes VIP da TransLógica, mostrando nome, cidade e segmento em ordem alfabética pelo nome.

**[DIRECIONAMENTO]**

Use `Where` para filtrar `Vip == true`, `OrderBy` pelo nome e `Select` para projetar apenas os campos pedidos.

---

### [QUESTÃO 2 — Motoristas ativos por experiência]

Liste os motoristas ativos, ordenando do mais experiente para o menos experiente. Mostre nome, categoria da CNH e anos de experiência.

**[DIRECIONAMENTO]**

Use `Where` para filtrar motoristas ativos, `OrderByDescending` por `AnosExperiencia` e `Select` para formatar o resultado.

---

### [QUESTÃO 3 — Viagens planejadas]

Liste as viagens com status `Planejada`, mostrando código, filial de origem, motorista e data de saída. Ordene pela data de saída mais próxima.

**[DIRECIONAMENTO]**

Use `Where` pelo status, `OrderBy` por `DataSaida` e `Select` para montar o retorno.

---

### [QUESTÃO 4 — Cargas pendentes mais valiosas]

Liste as cargas pendentes ordenadas pelo maior valor declarado. Mostre código de rastreio, cliente, tipo e valor.

**[DIRECIONAMENTO]**

Use `Where` com `StatusCargaEnum.Pendente`, `OrderByDescending` pelo valor declarado e `Select`.

---

### [QUESTÃO 5 — Busca parcial de cliente]

Receba um trecho de nome e liste todos os clientes cujo nome contenha esse trecho, ignorando maiúsculas e minúsculas.

**[DIRECIONAMENTO]**

Use `Where` com `Contains(trecho, StringComparison.OrdinalIgnoreCase)`, depois `OrderBy` pelo nome e `ToList()`.

---

### [QUESTÃO 6 — Cargas frágeis em trânsito]

Liste todas as cargas do tipo `Fragil` que estão `EmTransito`, ordenando pelo menor peso.

**[DIRECIONAMENTO]**

Use `Where` com duas condições, `OrderBy` por `PesoKg` e `Select` para exibir os dados principais.

---

### [QUESTÃO 7 — Viagens por filial de origem]

Agrupe as viagens por filial de origem e mostre a quantidade de viagens em cada filial.

**[DIRECIONAMENTO]**

Use `GroupBy(v => v.FilialOrigem)`, `Select` com `Count()` e `OrderByDescending` pela quantidade.

---

### [QUESTÃO 8 — Tipos de carga existentes]

Liste os tipos de carga que aparecem nas cargas cadastradas, sem repetição, em ordem alfabética.

**[DIRECIONAMENTO]**

Use `Select(c => c.Tipo)`, `Distinct()`, `OrderBy` e `ToList()`.

---

### [QUESTÃO 9 — Top 5 cargas mais pesadas]

Liste as 5 cargas mais pesadas, mostrando código, cliente, viagem e peso.

**[DIRECIONAMENTO]**

Use `OrderByDescending` por `PesoKg`, `Take(5)` e `Select`.

---

### [QUESTÃO 10 — Clientes por cidade]

Agrupe clientes por cidade e mostre cidade, quantidade de clientes e quantos são VIP.

**[DIRECIONAMENTO]**

Use `GroupBy(c => c.Cidade)`, `Count()` e `Count(c => c.Vip)` dentro do `Select`.

---

## Nível 2 — Básico com filtros compostos

### [QUESTÃO 11 — Viagens não canceladas por motorista]

Receba parte do nome de um motorista e liste as viagens não canceladas desse motorista.

**[DIRECIONAMENTO]**

Use `Where` combinando `Motorista.Nome.Contains(...)` e `Status != Cancelada`, depois `OrderByDescending` por `DataSaida`.

---

### [QUESTÃO 12 — Cargas acima de peso mínimo]

Receba um peso mínimo e liste as cargas com peso maior ou igual a esse valor, ordenadas por peso e depois por valor declarado.

**[DIRECIONAMENTO]**

Use `Where`, `OrderByDescending` por `PesoKg`, `ThenByDescending` por `ValorDeclarado` e `ToList()`.

---

### [QUESTÃO 13 — Viagens com roteiro longo]

Liste viagens que possuem 3 ou mais cidades no roteiro, mostrando código, motorista e quantidade de paradas.

**[DIRECIONAMENTO]**

Use `Where(v => v.RoteiroCidades.Count >= 3)`, `Select` e `OrderByDescending` pela quantidade de paradas.

---

### [QUESTÃO 14 — Clientes que despacharam carga]

Liste os clientes que possuem ao menos uma carga cadastrada, sem repetir cliente.

**[DIRECIONAMENTO]**

Use `Where(c => cargas.Any(cg => cg.Cliente.Documento == c.Documento))`, depois `OrderBy` e `ToList()`.

---

### [QUESTÃO 15 — Clientes sem carga]

Liste clientes que ainda não despacharam nenhuma carga.

**[DIRECIONAMENTO]**

Use `Where` com negação de `Any`, depois `OrderBy` pelo nome.

---

### [QUESTÃO 16 — Viagens com cargas perigosas]

Liste as viagens que possuem ao menos uma carga perigosa, sem repetir a viagem.

**[DIRECIONAMENTO]**

Use `Where` em `viagens` com `cargas.Any(...)`, depois `OrderBy` por `DataSaida`.

---

### [QUESTÃO 17 — Cargas por status]

Agrupe as cargas por status e mostre status, quantidade e peso total.

**[DIRECIONAMENTO]**

Use `GroupBy(c => c.Status)`, `Count()`, `Sum(c => c.PesoKg)` e ordene pela maior quantidade.

---

### [QUESTÃO 18 — Valor total por tipo de carga]

Agrupe as cargas por tipo e calcule o valor declarado total de cada tipo.

**[DIRECIONAMENTO]**

Use `GroupBy(c => c.Tipo)`, `Sum(c => c.ValorDeclarado)` e `OrderByDescending` pelo total.

---

### [QUESTÃO 19 — Motoristas por categoria CNH]

Agrupe motoristas ativos por categoria da CNH e mostre quantidade e média de anos de experiência.

**[DIRECIONAMENTO]**

Use `Where(m => m.Ativo)`, `GroupBy(m => m.Categoria)`, `Count()` e `Average()`.

---

### [QUESTÃO 20 — Histórico de cargas por cliente]

Receba parte do nome de um cliente e liste as cargas dele em ordem cronológica pela data de saída da viagem.

**[DIRECIONAMENTO]**

Use `FirstOrDefault` para encontrar o cliente, depois `Where` nas cargas por documento do cliente e `OrderBy(c => c.Viagem.DataSaida)`.

---

## Nível 3 — Intermediário com agregações

### [QUESTÃO 21 — Ocupação de uma viagem]

Receba o código de uma viagem e calcule peso total das cargas, capacidade do veículo e percentual de ocupação.

**[DIRECIONAMENTO]**

Use `FirstOrDefault` para buscar a viagem, `Where` para cargas daquela viagem e `Sum(c => c.PesoKg)`.

---

### [QUESTÃO 22 — Viagens quase lotadas]

Liste viagens não canceladas cuja ocupação esteja em pelo menos 80% da capacidade do veículo.

**[DIRECIONAMENTO]**

Use `Where` nas viagens e, dentro dele, `cargas.Where(...).Sum(...) / v.CapacidadeKg >= 0.8`. Depois ordene pelo maior percentual.

---

### [QUESTÃO 23 — Ranking de cargas por viagem]

Monte um ranking das viagens pela quantidade de cargas vinculadas.

**[DIRECIONAMENTO]**

Use `GroupBy(c => c.Viagem.Codigo)`, `Select` com `Count()` e `OrderByDescending`.

---

### [QUESTÃO 24 — Ranking de clientes por valor despachado]

Liste clientes ordenados pelo maior valor declarado total em cargas.

**[DIRECIONAMENTO]**

Use `GroupBy(c => c.Cliente.Documento)`, `Sum(c => c.ValorDeclarado)`, `First()` para recuperar o cliente e ordene pelo total.

---

### [QUESTÃO 25 — Média de peso por tipo de carga]

Agrupe cargas por tipo e calcule a média de peso, mostrando apenas tipos com pelo menos 2 cargas.

**[DIRECIONAMENTO]**

Use `GroupBy`, `Average`, `Count` e um `Where` após o `Select`.

---

### [QUESTÃO 26 — Filiais com maior peso transportado]

Agrupe cargas pela filial de origem da viagem e some o peso total transportado por filial.

**[DIRECIONAMENTO]**

Use `GroupBy(c => c.Viagem.FilialOrigem)`, `Sum(c => c.PesoKg)` e `OrderByDescending`.

---

### [QUESTÃO 27 — Cidades visitadas no roteiro]

Liste todas as cidades que aparecem nos roteiros das viagens, sem repetição.

**[DIRECIONAMENTO]**

Use `SelectMany(v => v.RoteiroCidades)`, `Distinct()`, `OrderBy` e `ToList()`.

---

### [QUESTÃO 28 — Cidades mais frequentes no roteiro]

Agrupe todas as cidades dos roteiros e mostre quantas vezes cada cidade aparece.

**[DIRECIONAMENTO]**

Use `SelectMany`, `GroupBy(cidade => cidade)`, `Count()` e `OrderByDescending`.

---

### [QUESTÃO 29 — Cargas entregues por cidade de parada]

Agrupe cargas entregues em parada de roteiro pela cidade de entrega.

**[DIRECIONAMENTO]**

Use `Where` filtrando `TipoDestinoEnum.ParadaRoteiro` e `StatusCargaEnum.Entregue`, depois `GroupBy(c => c.CidadeParadaEntrega)`.

---

### [QUESTÃO 30 — Cargas diretas por cidade no endereço]

Liste cargas com destino direto que possuem endereço contendo uma cidade informada.

**[DIRECIONAMENTO]**

Use `Where` por `TipoDestino`, `EnderecoDireto.Contains(cidade, StringComparison.OrdinalIgnoreCase)` e `OrderBy`.

---

## Nível 4 — Normal com consultas relacionadas

### [QUESTÃO 31 — Motoristas sem viagem ativa]

Liste motoristas ativos que não possuem viagem `EmAndamento`.

**[DIRECIONAMENTO]**

Use `Where(m => m.Ativo && !viagens.Any(v => v.Motorista.Cnh == m.Cnh && v.Status == EmAndamento))`.

---

### [QUESTÃO 32 — Veículos usados mais de uma vez]

Agrupe viagens por placa de veículo e liste placas que aparecem mais de uma vez.

**[DIRECIONAMENTO]**

Use `GroupBy(v => v.PlacaVeiculo)`, `Select` com `Count()` e `Where(g => g.Quantidade > 1)`.

---

### [QUESTÃO 33 — Clientes por tipo de carga em uma viagem]

Receba código da viagem e tipo de carga. Liste os clientes que despacharam aquele tipo naquela viagem, em ordem alfabética.

**[DIRECIONAMENTO]**

Use `Where` com código da viagem e tipo, `Select(c => c.Cliente)`, `DistinctBy(c => c.Documento)` e `OrderBy`.

---

### [QUESTÃO 34 — Roteiro da viagem com cargas por parada]

Receba o código de uma viagem e liste cada cidade do roteiro com as cargas programadas para ela.

**[DIRECIONAMENTO]**

Use `FirstOrDefault` para a viagem e depois `RoteiroCidades.Select(cidade => new { ... cargas.Where(...) ... })`.

---

### [QUESTÃO 35 — Viagens com todas as cargas não canceladas]

Liste viagens que possuem cargas e em que todas as cargas estão diferentes de `Cancelada`.

**[DIRECIONAMENTO]**

Use `Where` com `Any` para garantir que existem cargas e `All` para verificar o status.

---

### [QUESTÃO 36 — Viagens com alguma carga cancelada]

Liste viagens que possuem pelo menos uma carga cancelada.

**[DIRECIONAMENTO]**

Use `Where(v => cargas.Any(c => c.Viagem.Codigo == v.Codigo && c.Status == Cancelada))` e ordene pela data.

---

### [QUESTÃO 37 — Clientes VIP com carga perigosa]

Liste clientes VIP que já despacharam pelo menos uma carga perigosa.

**[DIRECIONAMENTO]**

Use `Where(c => c.Vip && cargas.Any(... TipoCargaEnum.Perigosa ...))`, depois `OrderBy`.

---

### [QUESTÃO 38 — Clientes por segmento e valor médio]

Agrupe cargas por segmento do cliente e calcule quantidade, valor total e valor médio declarado.

**[DIRECIONAMENTO]**

Use `GroupBy(c => c.Cliente.Segmento)`, `Count`, `Sum` e `Average`.

---

### [QUESTÃO 39 — Viagens concluídas por distância]

Liste viagens concluídas com distância percorrida calculada, ordenadas pela maior distância.

**[DIRECIONAMENTO]**

Use `Where(v => v.Status == Concluida && v.DistanciaPercorrida().HasValue)`, `Select` e `OrderByDescending`.

---

### [QUESTÃO 40 — Média de distância por motorista]

Calcule a média de distância percorrida nas viagens concluídas por motorista.

**[DIRECIONAMENTO]**

Use `Where` para viagens concluídas, `GroupBy(v => v.Motorista.Cnh)` e `Average(v => v.DistanciaPercorrida().Value)`.

---

### [QUESTÃO 41 — Cargas acima da média geral de peso]

Liste cargas com peso acima da média geral de peso das cargas.

**[DIRECIONAMENTO]**

Calcule primeiro `mediaPeso = cargas.Average(c => c.PesoKg)`. Depois use `Where`, `OrderByDescending` e `Select`.

---

### [QUESTÃO 42 — Clientes acima da média de valor despachado]

Liste clientes cujo valor total despachado está acima da média dos totais por cliente.

**[DIRECIONAMENTO]**

Crie primeiro um agrupamento por cliente com total. Depois calcule a média desses totais e filtre com `Where`.

---

### [QUESTÃO 43 — Top 3 motoristas por peso transportado]

Liste os 3 motoristas que transportaram maior peso total em cargas.

**[DIRECIONAMENTO]**

Agrupe cargas por CNH do motorista da viagem, some `PesoKg`, ordene e use `Take(3)`.

---

### [QUESTÃO 44 — Top 3 clientes por quantidade de cargas]

Liste os 3 clientes com mais cargas cadastradas.

**[DIRECIONAMENTO]**

Use `GroupBy(c => c.Cliente.Documento)`, `Count()`, `OrderByDescending` e `Take(3)`.

---

### [QUESTÃO 45 — Cargas por mês de despacho]

Agrupe cargas por mês e ano da data de despacho, mostrando quantidade e valor total.

**[DIRECIONAMENTO]**

Use `GroupBy(c => new { c.DataDespacho.Year, c.DataDespacho.Month })`, `Count` e `Sum`.

---

## Nível 5 — Relatórios e análises

### [QUESTÃO 46 — Relatório operacional por status de viagem]

Agrupe viagens por status e mostre quantidade de viagens, quantidade de motoristas distintos e capacidade total.

**[DIRECIONAMENTO]**

Use `GroupBy(v => v.Status)`, `Count`, `Select(v => v.Motorista.Cnh).Distinct().Count()` e `Sum(v => v.CapacidadeKg)`.

---

### [QUESTÃO 47 — Relatório de risco por filial]

Agrupe cargas perigosas por filial de origem e mostre quantidade, peso total e valor total.

**[DIRECIONAMENTO]**

Use `Where(c => c.Tipo == Perigosa)`, `GroupBy(c => c.Viagem.FilialOrigem)`, `Sum` e `OrderByDescending`.

---

### [QUESTÃO 48 — Entregas pendentes por cidade de parada]

Agrupe cargas pendentes com destino em parada pela cidade da parada.

**[DIRECIONAMENTO]**

Use `Where` com status pendente e destino em parada, depois `GroupBy(c => c.CidadeParadaEntrega)`.

---

### [QUESTÃO 49 — Clientes com cargas em mais de uma filial]

Liste clientes que já despacharam cargas em viagens de mais de uma filial de origem.

**[DIRECIONAMENTO]**

Agrupe por cliente e use `g.Select(c => c.Viagem.FilialOrigem).Distinct().Count() > 1`.

---

### [QUESTÃO 50 — Motoristas com diversidade de clientes]

Liste motoristas e a quantidade de clientes distintos atendidos por eles.

**[DIRECIONAMENTO]**

Agrupe cargas por motorista, conte documentos distintos de clientes e ordene decrescente.

---

### [QUESTÃO 51 — Viagens com destino direto e parada]

Liste viagens que possuem cargas com os dois tipos de destino: parada de roteiro e endereço direto.

**[DIRECIONAMENTO]**

Use `Where` em viagens com dois `Any`: um para `ParadaRoteiro` e outro para `EnderecoDireto`.

---

### [QUESTÃO 52 — Segmentos atendidos por viagem]

Para cada viagem, liste os segmentos distintos dos clientes atendidos.

**[DIRECIONAMENTO]**

Use `viagens.Select(v => new { ..., Segmentos = cargas.Where(...).Select(...).Distinct().ToList() })`.

---

### [QUESTÃO 53 — Viagens sem cargas]

Liste viagens que não possuem cargas vinculadas.

**[DIRECIONAMENTO]**

Use `Where(v => !cargas.Any(c => c.Viagem.Codigo == v.Codigo))` e ordene por data.

---

### [QUESTÃO 54 — Clientes com todas as cargas entregues]

Liste clientes que possuem cargas e todas elas estão entregues.

**[DIRECIONAMENTO]**

Use `Where` com `Any` para ter carga e `All` para todas as cargas do cliente estarem `Entregue`.

---

### [QUESTÃO 55 — Índice de cancelamento por tipo de carga]

Agrupe cargas por tipo e calcule percentual de canceladas em cada tipo.

**[DIRECIONAMENTO]**

Use `GroupBy`, `Count`, `Count(c => c.Status == Cancelada)` e percentual com `(double)`.

---

### [QUESTÃO 56 — Aproveitamento de capacidade por viagem]

Liste todas as viagens não canceladas com percentual de ocupação, ordenadas da maior para a menor ocupação.

**[DIRECIONAMENTO]**

Use `Where`, `Select` calculando `PesoTotal` e `Percentual`, depois `OrderByDescending`.

---

### [QUESTÃO 57 — Cargas fora do roteiro]

Liste cargas com destino em parada cuja cidade de entrega não aparece no roteiro da viagem.

**[DIRECIONAMENTO]**

Use `Where` com `TipoDestino == ParadaRoteiro` e negação de `Viagem.RoteiroCidades.Contains(CidadeParadaEntrega)`.

---

### [QUESTÃO 58 — Ranking de rotas por valor transportado]

Agrupe viagens pelo par `FilialOrigem -> última cidade do roteiro` e some o valor declarado das cargas de cada rota.

**[DIRECIONAMENTO]**

Use `GroupBy(c => new { Origem = c.Viagem.FilialOrigem, DestinoFinal = c.Viagem.RoteiroCidades.Last() })`, `Sum` e `OrderByDescending`.

---

### [QUESTÃO 59 — Dashboard de cliente]

Receba parte do nome do cliente e gere um dashboard com total de cargas, peso total, valor total, tipos usados e última carga despachada.

**[DIRECIONAMENTO]**

Use `FirstOrDefault`, depois filtre as cargas do cliente com `Where` e materialize com `ToList()`. Use `Count`, `Sum`, `Select().Distinct()` e `MaxBy`.

---

### [QUESTÃO 60 — Dashboard de viagem]

Receba o código de uma viagem e gere um dashboard com motorista, status, quantidade de cargas, clientes distintos, peso total, ocupação, carga mais valiosa e tipos de carga presentes.

**[DIRECIONAMENTO]**

Use `FirstOrDefault`, `Where` nas cargas da viagem, `Count`, `Distinct`, `Sum`, `MaxBy` e `Select().Distinct()`.

---

# Gabarito

> Nos gabaritos, variáveis como `trecho`, `codigoViagem`, `tipoCarga`, `pesoMinimo` e `cidade` representam entradas do usuário.

## Gabarito — Questão 1
```csharp
var resultado = clientes
    .Where(c => c.Vip)
    .OrderBy(c => c.Nome)
    .Select(c => new { c.Nome, c.Cidade, c.Segmento })
    .ToList();
```

## Gabarito — Questão 2
```csharp
var resultado = motoristas
    .Where(m => m.Ativo)
    .OrderByDescending(m => m.AnosExperiencia)
    .Select(m => new { m.Nome, m.Categoria, m.AnosExperiencia })
    .ToList();
```

## Gabarito — Questão 3
```csharp
var resultado = viagens
    .Where(v => v.Status == StatusViagemEnum.Planejada)
    .OrderBy(v => v.DataSaida)
    .Select(v => new { v.Codigo, v.FilialOrigem, Motorista = v.Motorista.Nome, v.DataSaida })
    .ToList();
```

## Gabarito — Questão 4
```csharp
var resultado = cargas
    .Where(c => c.Status == StatusCargaEnum.Pendente)
    .OrderByDescending(c => c.ValorDeclarado)
    .Select(c => new { c.CodigoRastreio, Cliente = c.Cliente.Nome, c.Tipo, c.ValorDeclarado })
    .ToList();
```

## Gabarito — Questão 5
```csharp
var resultado = clientes
    .Where(c => c.Nome.Contains(trecho, StringComparison.OrdinalIgnoreCase))
    .OrderBy(c => c.Nome)
    .ToList();
```

## Gabarito — Questão 6
```csharp
var resultado = cargas
    .Where(c => c.Tipo == TipoCargaEnum.Fragil && c.Status == StatusCargaEnum.EmTransito)
    .OrderBy(c => c.PesoKg)
    .Select(c => new { c.CodigoRastreio, Cliente = c.Cliente.Nome, c.PesoKg })
    .ToList();
```

## Gabarito — Questão 7
```csharp
var resultado = viagens
    .GroupBy(v => v.FilialOrigem)
    .Select(g => new { Filial = g.Key, Quantidade = g.Count() })
    .OrderByDescending(g => g.Quantidade)
    .ToList();
```

## Gabarito — Questão 8
```csharp
var resultado = cargas
    .Select(c => c.Tipo)
    .Distinct()
    .OrderBy(t => t)
    .ToList();
```

## Gabarito — Questão 9
```csharp
var resultado = cargas
    .OrderByDescending(c => c.PesoKg)
    .Take(5)
    .Select(c => new { c.CodigoRastreio, Cliente = c.Cliente.Nome, Viagem = c.Viagem.Codigo, c.PesoKg })
    .ToList();
```

## Gabarito — Questão 10
```csharp
var resultado = clientes
    .GroupBy(c => c.Cidade)
    .Select(g => new { Cidade = g.Key, Quantidade = g.Count(), Vips = g.Count(c => c.Vip) })
    .OrderByDescending(g => g.Quantidade)
    .ToList();
```

## Gabarito — Questão 11
```csharp
var resultado = viagens
    .Where(v => v.Motorista.Nome.Contains(trecho, StringComparison.OrdinalIgnoreCase)
             && v.Status != StatusViagemEnum.Cancelada)
    .OrderByDescending(v => v.DataSaida)
    .ToList();
```

## Gabarito — Questão 12
```csharp
var resultado = cargas
    .Where(c => c.PesoKg >= pesoMinimo)
    .OrderByDescending(c => c.PesoKg)
    .ThenByDescending(c => c.ValorDeclarado)
    .ToList();
```

## Gabarito — Questão 13
```csharp
var resultado = viagens
    .Where(v => v.RoteiroCidades.Count >= 3)
    .Select(v => new { v.Codigo, Motorista = v.Motorista.Nome, Paradas = v.RoteiroCidades.Count })
    .OrderByDescending(v => v.Paradas)
    .ToList();
```

## Gabarito — Questão 14
```csharp
var resultado = clientes
    .Where(c => cargas.Any(cg => cg.Cliente.Documento == c.Documento))
    .OrderBy(c => c.Nome)
    .ToList();
```

## Gabarito — Questão 15
```csharp
var resultado = clientes
    .Where(c => !cargas.Any(cg => cg.Cliente.Documento == c.Documento))
    .OrderBy(c => c.Nome)
    .ToList();
```

## Gabarito — Questão 16
```csharp
var resultado = viagens
    .Where(v => cargas.Any(c => c.Viagem.Codigo == v.Codigo && c.Tipo == TipoCargaEnum.Perigosa))
    .OrderBy(v => v.DataSaida)
    .ToList();
```

## Gabarito — Questão 17
```csharp
var resultado = cargas
    .GroupBy(c => c.Status)
    .Select(g => new { Status = g.Key, Quantidade = g.Count(), PesoTotal = g.Sum(c => c.PesoKg) })
    .OrderByDescending(g => g.Quantidade)
    .ToList();
```

## Gabarito — Questão 18
```csharp
var resultado = cargas
    .GroupBy(c => c.Tipo)
    .Select(g => new { Tipo = g.Key, ValorTotal = g.Sum(c => c.ValorDeclarado) })
    .OrderByDescending(g => g.ValorTotal)
    .ToList();
```

## Gabarito — Questão 19
```csharp
var resultado = motoristas
    .Where(m => m.Ativo)
    .GroupBy(m => m.Categoria)
    .Select(g => new { Categoria = g.Key, Quantidade = g.Count(), MediaExperiencia = g.Average(m => m.AnosExperiencia) })
    .OrderBy(g => g.Categoria)
    .ToList();
```

## Gabarito — Questão 20
```csharp
var cliente = clientes.FirstOrDefault(c => c.Nome.Contains(trecho, StringComparison.OrdinalIgnoreCase));
var resultado = cliente == null
    ? new List<Carga>()
    : cargas.Where(c => c.Cliente.Documento == cliente.Documento)
            .OrderBy(c => c.Viagem.DataSaida)
            .ToList();
```

## Gabarito — Questão 21
```csharp
var viagem = viagens.FirstOrDefault(v => v.Codigo == codigoViagem);
var pesoTotal = cargas
    .Where(c => c.Viagem.Codigo == codigoViagem)
    .Sum(c => c.PesoKg);

var ocupacao = viagem == null ? 0 : pesoTotal / viagem.CapacidadeKg;
```

## Gabarito — Questão 22
```csharp
var resultado = viagens
    .Where(v => v.Status != StatusViagemEnum.Cancelada)
    .Select(v => new
    {
        Viagem = v,
        PesoTotal = cargas.Where(c => c.Viagem.Codigo == v.Codigo).Sum(c => c.PesoKg),
        Percentual = cargas.Where(c => c.Viagem.Codigo == v.Codigo).Sum(c => c.PesoKg) / v.CapacidadeKg
    })
    .Where(v => v.Percentual >= 0.8)
    .OrderByDescending(v => v.Percentual)
    .ToList();
```

## Gabarito — Questão 23
```csharp
var resultado = cargas
    .GroupBy(c => c.Viagem.Codigo)
    .Select(g => new { Viagem = g.Key, QuantidadeCargas = g.Count(), Motorista = g.First().Viagem.Motorista.Nome })
    .OrderByDescending(g => g.QuantidadeCargas)
    .ToList();
```

## Gabarito — Questão 24
```csharp
var resultado = cargas
    .GroupBy(c => c.Cliente.Documento)
    .Select(g => new { Cliente = g.First().Cliente, ValorTotal = g.Sum(c => c.ValorDeclarado) })
    .OrderByDescending(g => g.ValorTotal)
    .ToList();
```

## Gabarito — Questão 25
```csharp
var resultado = cargas
    .GroupBy(c => c.Tipo)
    .Select(g => new { Tipo = g.Key, Quantidade = g.Count(), MediaPeso = g.Average(c => c.PesoKg) })
    .Where(g => g.Quantidade >= 2)
    .OrderByDescending(g => g.MediaPeso)
    .ToList();
```

## Gabarito — Questão 26
```csharp
var resultado = cargas
    .GroupBy(c => c.Viagem.FilialOrigem)
    .Select(g => new { Filial = g.Key, PesoTotal = g.Sum(c => c.PesoKg) })
    .OrderByDescending(g => g.PesoTotal)
    .ToList();
```

## Gabarito — Questão 27
```csharp
var resultado = viagens
    .SelectMany(v => v.RoteiroCidades)
    .Distinct()
    .OrderBy(cidade => cidade)
    .ToList();
```

## Gabarito — Questão 28
```csharp
var resultado = viagens
    .SelectMany(v => v.RoteiroCidades)
    .GroupBy(cidade => cidade)
    .Select(g => new { Cidade = g.Key, Quantidade = g.Count() })
    .OrderByDescending(g => g.Quantidade)
    .ToList();
```

## Gabarito — Questão 29
```csharp
var resultado = cargas
    .Where(c => c.TipoDestino == TipoDestinoEnum.ParadaRoteiro
             && c.Status == StatusCargaEnum.Entregue)
    .GroupBy(c => c.CidadeParadaEntrega)
    .Select(g => new { Cidade = g.Key, Quantidade = g.Count(), PesoTotal = g.Sum(c => c.PesoKg) })
    .OrderByDescending(g => g.Quantidade)
    .ToList();
```

## Gabarito — Questão 30
```csharp
var resultado = cargas
    .Where(c => c.TipoDestino == TipoDestinoEnum.EnderecoDireto
             && c.EnderecoDireto != null
             && c.EnderecoDireto.Contains(cidade, StringComparison.OrdinalIgnoreCase))
    .OrderBy(c => c.Cliente.Nome)
    .ToList();
```

## Gabarito — Questão 31
```csharp
var resultado = motoristas
    .Where(m => m.Ativo
             && !viagens.Any(v => v.Motorista.Cnh == m.Cnh && v.Status == StatusViagemEnum.EmAndamento))
    .OrderBy(m => m.Nome)
    .ToList();
```

## Gabarito — Questão 32
```csharp
var resultado = viagens
    .GroupBy(v => v.PlacaVeiculo)
    .Select(g => new { Placa = g.Key, Quantidade = g.Count(), Modelos = g.Select(v => v.ModeloVeiculo).Distinct().ToList() })
    .Where(g => g.Quantidade > 1)
    .ToList();
```

## Gabarito — Questão 33
```csharp
var resultado = cargas
    .Where(c => c.Viagem.Codigo == codigoViagem && c.Tipo == tipoCarga)
    .Select(c => c.Cliente)
    .DistinctBy(c => c.Documento)
    .OrderBy(c => c.Nome)
    .ToList();
```

## Gabarito — Questão 34
```csharp
var viagem = viagens.FirstOrDefault(v => v.Codigo == codigoViagem);
var resultado = viagem?.RoteiroCidades
    .Select(cidade => new
    {
        Cidade = cidade,
        Cargas = cargas.Where(c => c.Viagem.Codigo == viagem.Codigo
                                && c.CidadeParadaEntrega == cidade)
                       .ToList()
    })
    .ToList();
```

## Gabarito — Questão 35
```csharp
var resultado = viagens
    .Where(v => cargas.Any(c => c.Viagem.Codigo == v.Codigo)
             && cargas.Where(c => c.Viagem.Codigo == v.Codigo)
                      .All(c => c.Status != StatusCargaEnum.Cancelada))
    .OrderBy(v => v.Codigo)
    .ToList();
```

## Gabarito — Questão 36
```csharp
var resultado = viagens
    .Where(v => cargas.Any(c => c.Viagem.Codigo == v.Codigo && c.Status == StatusCargaEnum.Cancelada))
    .OrderBy(v => v.DataSaida)
    .ToList();
```

## Gabarito — Questão 37
```csharp
var resultado = clientes
    .Where(c => c.Vip
             && cargas.Any(cg => cg.Cliente.Documento == c.Documento
                              && cg.Tipo == TipoCargaEnum.Perigosa))
    .OrderBy(c => c.Nome)
    .ToList();
```

## Gabarito — Questão 38
```csharp
var resultado = cargas
    .GroupBy(c => c.Cliente.Segmento)
    .Select(g => new
    {
        Segmento = g.Key,
        Quantidade = g.Count(),
        ValorTotal = g.Sum(c => c.ValorDeclarado),
        ValorMedio = g.Average(c => c.ValorDeclarado)
    })
    .OrderByDescending(g => g.ValorTotal)
    .ToList();
```

## Gabarito — Questão 39
```csharp
var resultado = viagens
    .Where(v => v.Status == StatusViagemEnum.Concluida && v.DistanciaPercorrida().HasValue)
    .Select(v => new { v.Codigo, Motorista = v.Motorista.Nome, Distancia = v.DistanciaPercorrida().Value })
    .OrderByDescending(v => v.Distancia)
    .ToList();
```

## Gabarito — Questão 40
```csharp
var resultado = viagens
    .Where(v => v.Status == StatusViagemEnum.Concluida && v.DistanciaPercorrida().HasValue)
    .GroupBy(v => v.Motorista.Cnh)
    .Select(g => new { Motorista = g.First().Motorista.Nome, MediaDistancia = g.Average(v => v.DistanciaPercorrida().Value) })
    .OrderByDescending(g => g.MediaDistancia)
    .ToList();
```

## Gabarito — Questão 41
```csharp
var mediaPeso = cargas.Average(c => c.PesoKg);
var resultado = cargas
    .Where(c => c.PesoKg > mediaPeso)
    .OrderByDescending(c => c.PesoKg)
    .ToList();
```

## Gabarito — Questão 42
```csharp
var totaisPorCliente = cargas
    .GroupBy(c => c.Cliente.Documento)
    .Select(g => new { Cliente = g.First().Cliente, Total = g.Sum(c => c.ValorDeclarado) })
    .ToList();

var mediaTotais = totaisPorCliente.Average(c => c.Total);

var resultado = totaisPorCliente
    .Where(c => c.Total > mediaTotais)
    .OrderByDescending(c => c.Total)
    .ToList();
```

## Gabarito — Questão 43
```csharp
var resultado = cargas
    .GroupBy(c => c.Viagem.Motorista.Cnh)
    .Select(g => new { Motorista = g.First().Viagem.Motorista.Nome, PesoTotal = g.Sum(c => c.PesoKg) })
    .OrderByDescending(g => g.PesoTotal)
    .Take(3)
    .ToList();
```

## Gabarito — Questão 44
```csharp
var resultado = cargas
    .GroupBy(c => c.Cliente.Documento)
    .Select(g => new { Cliente = g.First().Cliente.Nome, Quantidade = g.Count() })
    .OrderByDescending(g => g.Quantidade)
    .Take(3)
    .ToList();
```

## Gabarito — Questão 45
```csharp
var resultado = cargas
    .GroupBy(c => new { c.DataDespacho.Year, c.DataDespacho.Month })
    .Select(g => new { g.Key.Year, g.Key.Month, Quantidade = g.Count(), ValorTotal = g.Sum(c => c.ValorDeclarado) })
    .OrderBy(g => g.Year)
    .ThenBy(g => g.Month)
    .ToList();
```

## Gabarito — Questão 46
```csharp
var resultado = viagens
    .GroupBy(v => v.Status)
    .Select(g => new
    {
        Status = g.Key,
        Quantidade = g.Count(),
        MotoristasDistintos = g.Select(v => v.Motorista.Cnh).Distinct().Count(),
        CapacidadeTotal = g.Sum(v => v.CapacidadeKg)
    })
    .OrderByDescending(g => g.Quantidade)
    .ToList();
```

## Gabarito — Questão 47
```csharp
var resultado = cargas
    .Where(c => c.Tipo == TipoCargaEnum.Perigosa)
    .GroupBy(c => c.Viagem.FilialOrigem)
    .Select(g => new { Filial = g.Key, Quantidade = g.Count(), PesoTotal = g.Sum(c => c.PesoKg), ValorTotal = g.Sum(c => c.ValorDeclarado) })
    .OrderByDescending(g => g.ValorTotal)
    .ToList();
```

## Gabarito — Questão 48
```csharp
var resultado = cargas
    .Where(c => c.Status == StatusCargaEnum.Pendente
             && c.TipoDestino == TipoDestinoEnum.ParadaRoteiro)
    .GroupBy(c => c.CidadeParadaEntrega)
    .Select(g => new { Cidade = g.Key, Quantidade = g.Count(), PesoTotal = g.Sum(c => c.PesoKg) })
    .OrderByDescending(g => g.Quantidade)
    .ToList();
```

## Gabarito — Questão 49
```csharp
var resultado = cargas
    .GroupBy(c => c.Cliente.Documento)
    .Select(g => new
    {
        Cliente = g.First().Cliente,
        Filiais = g.Select(c => c.Viagem.FilialOrigem).Distinct().ToList()
    })
    .Where(g => g.Filiais.Count > 1)
    .OrderBy(g => g.Cliente.Nome)
    .ToList();
```

## Gabarito — Questão 50
```csharp
var resultado = cargas
    .GroupBy(c => c.Viagem.Motorista.Cnh)
    .Select(g => new
    {
        Motorista = g.First().Viagem.Motorista.Nome,
        ClientesDistintos = g.Select(c => c.Cliente.Documento).Distinct().Count()
    })
    .OrderByDescending(g => g.ClientesDistintos)
    .ToList();
```

## Gabarito — Questão 51
```csharp
var resultado = viagens
    .Where(v => cargas.Any(c => c.Viagem.Codigo == v.Codigo && c.TipoDestino == TipoDestinoEnum.ParadaRoteiro)
             && cargas.Any(c => c.Viagem.Codigo == v.Codigo && c.TipoDestino == TipoDestinoEnum.EnderecoDireto))
    .OrderBy(v => v.Codigo)
    .ToList();
```

## Gabarito — Questão 52
```csharp
var resultado = viagens
    .Select(v => new
    {
        v.Codigo,
        Segmentos = cargas.Where(c => c.Viagem.Codigo == v.Codigo)
                          .Select(c => c.Cliente.Segmento)
                          .Distinct()
                          .ToList()
    })
    .OrderBy(v => v.Codigo)
    .ToList();
```

## Gabarito — Questão 53
```csharp
var resultado = viagens
    .Where(v => !cargas.Any(c => c.Viagem.Codigo == v.Codigo))
    .OrderBy(v => v.DataSaida)
    .ToList();
```

## Gabarito — Questão 54
```csharp
var resultado = clientes
    .Where(c => cargas.Any(cg => cg.Cliente.Documento == c.Documento)
             && cargas.Where(cg => cg.Cliente.Documento == c.Documento)
                      .All(cg => cg.Status == StatusCargaEnum.Entregue))
    .OrderBy(c => c.Nome)
    .ToList();
```

## Gabarito — Questão 55
```csharp
var resultado = cargas
    .GroupBy(c => c.Tipo)
    .Select(g => new
    {
        Tipo = g.Key,
        Total = g.Count(),
        Canceladas = g.Count(c => c.Status == StatusCargaEnum.Cancelada),
        PercentualCancelamento = (double)g.Count(c => c.Status == StatusCargaEnum.Cancelada) / g.Count()
    })
    .OrderByDescending(g => g.PercentualCancelamento)
    .ToList();
```

## Gabarito — Questão 56
```csharp
var resultado = viagens
    .Where(v => v.Status != StatusViagemEnum.Cancelada)
    .Select(v => new
    {
        Viagem = v.Codigo,
        PesoTotal = cargas.Where(c => c.Viagem.Codigo == v.Codigo).Sum(c => c.PesoKg),
        Capacidade = v.CapacidadeKg,
        Percentual = cargas.Where(c => c.Viagem.Codigo == v.Codigo).Sum(c => c.PesoKg) / v.CapacidadeKg
    })
    .OrderByDescending(v => v.Percentual)
    .ToList();
```

## Gabarito — Questão 57
```csharp
var resultado = cargas
    .Where(c => c.TipoDestino == TipoDestinoEnum.ParadaRoteiro
             && c.CidadeParadaEntrega != null
             && !c.Viagem.RoteiroCidades.Contains(c.CidadeParadaEntrega))
    .OrderBy(c => c.CodigoRastreio)
    .ToList();
```

## Gabarito — Questão 58
```csharp
var resultado = cargas
    .GroupBy(c => new
    {
        Origem = c.Viagem.FilialOrigem,
        DestinoFinal = c.Viagem.RoteiroCidades.Last()
    })
    .Select(g => new { g.Key.Origem, g.Key.DestinoFinal, ValorTotal = g.Sum(c => c.ValorDeclarado) })
    .OrderByDescending(g => g.ValorTotal)
    .ToList();
```

## Gabarito — Questão 59
```csharp
var cliente = clientes.FirstOrDefault(c => c.Nome.Contains(trecho, StringComparison.OrdinalIgnoreCase));
if (cliente != null)
{
    var cargasCliente = cargas.Where(c => c.Cliente.Documento == cliente.Documento).ToList();

    var dashboard = new
    {
        Cliente = cliente.Nome,
        TotalCargas = cargasCliente.Count,
        PesoTotal = cargasCliente.Sum(c => c.PesoKg),
        ValorTotal = cargasCliente.Sum(c => c.ValorDeclarado),
        Tipos = cargasCliente.Select(c => c.Tipo).Distinct().ToList(),
        UltimaCarga = cargasCliente.MaxBy(c => c.DataDespacho)
    };
}
```

## Gabarito — Questão 60
```csharp
var viagem = viagens.FirstOrDefault(v => v.Codigo == codigoViagem);
if (viagem != null)
{
    var cargasViagem = cargas.Where(c => c.Viagem.Codigo == viagem.Codigo).ToList();

    var dashboard = new
    {
        viagem.Codigo,
        Motorista = viagem.Motorista.Nome,
        viagem.Status,
        QuantidadeCargas = cargasViagem.Count,
        ClientesDistintos = cargasViagem.Select(c => c.Cliente.Documento).Distinct().Count(),
        PesoTotal = cargasViagem.Sum(c => c.PesoKg),
        Ocupacao = cargasViagem.Sum(c => c.PesoKg) / viagem.CapacidadeKg,
        CargaMaisValiosa = cargasViagem.MaxBy(c => c.ValorDeclarado),
        Tipos = cargasViagem.Select(c => c.Tipo).Distinct().ToList()
    };
}
```

---

## Resumo dos Métodos por Questão

| Questões | Métodos trabalhados |
|---------|---------------------|
| 1 a 10 | `Where`, `OrderBy`, `OrderByDescending`, `Select`, `Distinct`, `Take`, `GroupBy`, `Count` |
| 11 a 20 | Filtros compostos, `Any`, negação com `!Any`, `ThenBy`, `FirstOrDefault`, histórico ordenado |
| 21 a 30 | `Sum`, cálculo percentual, ranking, `Average`, `SelectMany`, agrupamentos por cidade e destino |
| 31 a 40 | Consultas relacionadas, `All`, `DistinctBy`, agrupamento por motorista, distância e médias |
| 41 a 50 | Média geral, acima da média, top rankings, agrupamento por mês, filiais, segmentos e clientes distintos |
| 51 a 60 | Dashboards, múltiplos `Any`, `Distinct`, `MaxBy`, `Last`, validações de roteiro e ocupação |
