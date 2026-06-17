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

Console.Write("Digite o número da questão: ");
int.TryParse(Console.ReadLine(), out int opcao);

switch (opcao)
{
    case 1:
        var clientesVip = clientes.Where(x => x.Vip == true).Select(x => new { x.Nome, x.Cidade, x.Segmento }).OrderBy(x => x.Nome).ToList();

        var teste = from c in clientes
                    where c.Vip.Equals(true)
                    orderby c.Nome
                    select new { c.Nome, c.Cidade, c.Segmento };

        Console.WriteLine();
        foreach (var item in teste)
            Console.WriteLine($"Cliente: {item.Nome} | Cidade: {item.Cidade} | Segmento: {item.Segmento}");

        // foreach (var item in clientesVip)
        //     Console.WriteLine($"Cliente: {item.Nome} | Cidade: {item.Cidade} | Segmento: {item.Segmento}");
        break;
    case 2:
        var motoristasExperientes = motoristas.Where(x => x.Ativo)
                                              .OrderByDescending(x => x.AnosExperiencia)
                                              .Select(x => new { x.Nome, x.Categoria, x.AnosExperiencia }).ToList();

        Console.WriteLine();
        foreach (var item in motoristasExperientes)
            Console.WriteLine($"Motorista: {item.Nome} | Categoria: {item.Categoria} | Anos de Experiência: {item.AnosExperiencia}");
        break;
    case 3:
        var viagensPlanejadas = viagens.Where(x => x.Status == StatusViagemEnum.Planejada)
                                       .OrderBy(x => x.DataSaida)
                                       .Select(x => new { x.Codigo, x.FilialOrigem, x.Motorista, x.DataSaida })
                                       .ToList();

        Console.WriteLine();
        foreach (var item in viagensPlanejadas)
            Console.WriteLine($"Código Viagem: {item.Codigo} | Filial de Origem: {item.FilialOrigem} | Motorista: {item.Motorista.Nome} | Data de Saída: {item.DataSaida:d}");
        break;
    case 4:
        var cargasPendentes = cargas.Where(x => x.Status == StatusCargaEnum.Pendente)
                                    .OrderByDescending(x => x.ValorDeclarado)
                                    .Select(x => new { x.CodigoRastreio, x.Cliente.Nome, x.Tipo, x.ValorDeclarado })
                                    .ToList();

        Console.WriteLine();

        foreach (var item in cargasPendentes)
            Console.WriteLine($"Código da Carga: {item.CodigoRastreio} | Cliente: {item.Nome} | Tipo: {item.Tipo} | Valor: {item.ValorDeclarado:c}");
        break;
    default:
        break;
}
