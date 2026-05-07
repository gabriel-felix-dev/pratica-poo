using AeroportoCeuAzul.Enums;
using AeroportoCeuAzul.Helpers;
using AeroportoCeuAzul.Models;

List<CompanhiaAerea> companhiaAereas = [];
List<Embarque> embarques = [];
List<Voo> voos = [];
List<Passageiro> passageiros = [];

Console.WriteLine("\n### - Aeroporto Céu Azul - ###");

while (true)
{
    Console.WriteLine("\n### - Passageiros - ###\n");
    Console.WriteLine("1 - Cadastrar Passageiro");
    Console.WriteLine("2 - Listar Passageiros");
    Console.WriteLine("3 - Busca parical de Passageiro por Nome");
    Console.WriteLine("4 - Busca exata de Passageiro por Nome");
    Console.WriteLine("5 - Editar Passageiro");
    Console.WriteLine("6 - Excluir Passageiro");

    Console.WriteLine("\n### - Companhia Aérea - ###\n");
    Console.WriteLine("7 - Cadastrar Companhia Aérea");
    Console.WriteLine("8 - Listar Companhia Aéreas");
    Console.WriteLine("9 - Editar Companhia Aérea");
    Console.WriteLine("10 - Excluir Companhia Aérea");

    Console.WriteLine("\n### - Voo - ###\n");
    Console.WriteLine("11 - Cadastrar Voo");
    Console.WriteLine("12 - Listar Voo");

    Console.WriteLine("\n### - Embarque - ###\n");
    Console.WriteLine("13 - Cadastrar Embarque");
    Console.WriteLine("14 - Listar Embarques");

    Console.WriteLine("\n0 - Sair\n");

    Console.Write("Digite a opção desejada: ");

    int opcao = Helper.ValidadorNumeroInteiro();

    switch (opcao)
    {
        case 1:
            Console.Write("\nDigite o nome do passageiro: ");
            string nomePassageiro = Helper.ValidadorTexto();

            Console.Write("\nDigite a data de nascimento do passageiro (formato: dd/MM/yyyy): ");
            DateTime dataNascimento = Helper.ValidadorData();

            Console.Write("\nDigite o CPF do passageiro (apenas números, 11 dígitos): ");
            string cpfPassageiro = Helper.ValidadorCpf();

            Console.Write("\nDigite o número do passaporte do passageiro (Máximo de 9 caracteres e mínimo 6 de caracteres): ");
            string numeroPassaporte = Helper.ValidadorNumeroPassaporte();

            Passageiro passageiro = new Passageiro(nomePassageiro, dataNascimento, cpfPassageiro, numeroPassaporte);
            passageiros.Add(passageiro);

            Console.WriteLine("\nPassageiro cadastrado com sucesso!");
            break;

        case 2:
            if (Helper.ValidaQuantidadeLista(passageiros))
                return;

            ImprimirLista(passageiros);
            break;

        case 3:
            if (Helper.ValidaQuantidadeLista(passageiros))
                continue;

            Console.Write("\nDigite o nome ou parte do nome do passageiro para busca: ");
            string nomeParcial = Helper.ValidadorTexto().ToLower();

            var resultadosParciais = passageiros.Where(p => p.Nome.ToLower().Contains(nomeParcial)).ToList();

            Console.WriteLine($"\nPassageiros encontrados com '{nomeParcial}':");
            resultadosParciais.ForEach(p => Console.WriteLine($"# - {p}"));

            break;

        case 4:
            if (Helper.ValidaQuantidadeLista(passageiros))
                continue;

            Console.Write("\nDigite o nome ou parte do nome do passageiro para busca: ");
            string nomeExato = Helper.ValidadorTexto();

            var resultadosExatos = passageiros.Where(p => p.Nome.Contains(nomeExato)).ToList();

            Console.WriteLine($"\nPassageiros encontrados com '{nomeExato}':");
            resultadosExatos.ForEach(p => Console.WriteLine($"# - {p}"));

            break;

        case 5:
            ImprimirLista(passageiros);

            Console.Write("\nDigite o Id do passageiro: ");
            Guid idPassageiro = Helper.ValidadorGuid();

            passageiro = passageiros.FirstOrDefault(p => p.Id.Equals(idPassageiro));

            if (passageiro == null)
            {
                Console.WriteLine("\nPassageiro não encontrado");
                continue;
            }

            Console.Write("\nDigite o nome do passageiro: ");
            string novoNomePassageiro = Helper.ValidadorTexto();

            Console.Write("\nDigite a data de nascimento do passageiro (formato: dd/MM/yyyy): ");
            DateTime novaDataNascimento = Helper.ValidadorData();

            Console.Write("\nDigite o CPF do passageiro (apenas números, 11 dígitos): ");
            string novoCpfPassageiro = Helper.ValidadorCpf();

            Console.Write("\nDigite o número do passaporte do passageiro (Máximo de 9 caracteres e mínimo 6 de caracteres): ");
            string novoNumeroPassaporte = Helper.ValidadorNumeroPassaporte();

            passageiro.AlterarDados(novoNomePassageiro, novaDataNascimento, novoCpfPassageiro, novoNumeroPassaporte);

            break;

        case 6:
            if (Helper.ValidaQuantidadeLista(passageiros))
                continue;

            ImprimirLista(passageiros);

            Console.Write("\nDigite o Id do passageiro: ");
            idPassageiro = Helper.ValidadorGuid();

            passageiro = passageiros.FirstOrDefault(p => p.Id.Equals(idPassageiro));

            if (passageiro == null)
            {
                Console.WriteLine("\nPassageiro não encontrado");
                continue;
            }

            passageiro.AlterarStatusCadastro();

            break;

        case 7:
            Console.Write("\nDigite o código IATA (2 caracteres - A1): ");
            string codigoIata = Helper.ValidadorIATA();

            Console.Write("\nDigite o nome da Companhia Aéreas: ");
            string nomeCompanhiaAerea = Helper.ValidadorTexto();

            Console.Write("\nDigite o País de Origem da Companhia Aérea: ");
            string paisOrigemCompanhiaAerea = Helper.ValidadorTexto();

            CompanhiaAerea companhiaAerea = new CompanhiaAerea(codigoIata, nomeCompanhiaAerea, paisOrigemCompanhiaAerea);

            companhiaAereas.Add(companhiaAerea);

            Console.WriteLine("\nCompanhia Aérea cadastrada com sucesso!");
            break;

        case 8:
            if (Helper.ValidaQuantidadeLista(companhiaAereas))
                continue;

            ImprimirLista(companhiaAereas);
            break;

        case 9:
            if (Helper.ValidaQuantidadeLista(companhiaAereas))
                continue;

            ImprimirLista(companhiaAereas);

            Console.Write("\nDigite o Id do companhiaAerea: ");
            Guid idCompanhiaAerea = Helper.ValidadorGuid();

            companhiaAerea = companhiaAereas.FirstOrDefault(p => p.Id.Equals(idCompanhiaAerea));

            if (companhiaAerea == null)
            {
                Console.WriteLine("\nCompanhia Aérea não encontrada");
                continue;
            }

            Console.Write("\nDigite o novo código IATA da Companhia Aérea: ");
            string novoIataCompanhiaAerea = Helper.ValidadorIATA();

            Console.Write("\nDigite o novo nome da Companhia Aérea: ");
            string novoNomeCompanhiaAerea = Helper.ValidadorTexto();

            Console.Write("\nDigite o novo país de origem da Companhia Aérea: ");
            string novoPaisOrigemCompanhiaAerea = Helper.ValidadorTexto();

            companhiaAerea.AlterarDados(novoIataCompanhiaAerea, novoNomeCompanhiaAerea, novoPaisOrigemCompanhiaAerea);

            break;

        case 10:
            ImprimirLista(companhiaAereas);

            Console.Write("\nDigite o Id da Companhia Aérea: ");
            idCompanhiaAerea = Helper.ValidadorGuid();

            companhiaAerea = companhiaAereas.FirstOrDefault(p => p.Id.Equals(idCompanhiaAerea));

            if (companhiaAerea == null)
            {
                Console.WriteLine("\nPassageiro não encontrado");
                continue;
            }

            companhiaAerea.AlterarStatusCadastro();

            break;

        case 11:
            var companhiaAereasCadastroVoo = companhiaAereas.Where(c => c.StatusCadastro != StatusCadastroEnum.Inativo).ToList();

            if (Helper.ValidaQuantidadeLista(companhiaAereasCadastroVoo))
                continue;

            ImprimirLista(companhiaAereasCadastroVoo);

            Console.Write("\nDigite o Id da Companhia Aérea: ");
            idCompanhiaAerea = Helper.ValidadorGuid();

            companhiaAerea = companhiaAereas.FirstOrDefault(c => c.Id.Equals(idCompanhiaAerea));

            if (companhiaAerea == null)
            {
                Console.WriteLine("\nCompanhia não encontrada");
                continue;
            }

            Console.Write("\nDigite o código do voo (formato: AB1234): ");
            string codigoUnicoVoo = Helper.ValidadorCodigoUnicoVoo();

            Console.Write("\nDigite o Aereporto de Origem do voo: ");
            string nomeAeroportoOrigem = Helper.ValidadorTexto();

            Console.Write("\nDigite o Aereporto de Destino do voo: ");
            string nomeAeroportoDestino = Helper.ValidadorTexto();

            Console.Write("\nDigite a datata e a hora de partida do voo (formato: dd/MM/yyyy HH:mm): ");
            DateTime dataHoraPartidaVoo = Helper.ValidadorData();

            Console.Write("\nDigite a duração estimado do voo: ");
            int duracaoEstimadaVoo = Helper.ValidadorDuracaoVoo();

            Console.Write("\nSelecione o status: \n\n1. No Horário \n2. Atrasado \n3. Cancelado \n\nDigite a opção: ");
            int opcaoMenu = Helper.ValidadorNumeroInteiro();

            var statusOperacionalVoo = opcaoMenu switch
            {
                1 => StatusOperacionalVooEnum.NoHorario,
                2 => StatusOperacionalVooEnum.Atrasado,
                _ => StatusOperacionalVooEnum.Cancelado,
            };

            Voo voo = new Voo(companhiaAerea, codigoUnicoVoo, nomeAeroportoOrigem, nomeAeroportoDestino, dataHoraPartidaVoo, duracaoEstimadaVoo, statusOperacionalVoo);

            voos.Add(voo);

            Console.WriteLine("\nVoo cadastrado com sucesso!");
            break;

        case 12:
            if (Helper.ValidaQuantidadeLista(voos))
                continue;

            ImprimirLista(voos);
            break;

        case 13:
            var passageiroCadastroEmbarque = passageiros.Where(c => c.StatusCadastro != StatusCadastroEnum.Inativo).ToList();

            if (Helper.ValidaQuantidadeLista(passageiroCadastroEmbarque))
                continue;

            ImprimirLista(passageiroCadastroEmbarque);

            Console.Write("\nDigite o Id do Passageiro para embarque: ");
            idPassageiro = Helper.ValidadorGuid();

            passageiro = passageiroCadastroEmbarque.FirstOrDefault(c => c.Id.Equals(idPassageiro));

            if (passageiro == null)
            {
                Console.WriteLine("\nPassageiro não encontrado");
                continue;
            }

            var vooCadastroEmbarque = voos.Where(c => c.StatusOperacional != StatusOperacionalVooEnum.Cancelado).ToList();

            if (Helper.ValidaQuantidadeLista(vooCadastroEmbarque))
                continue;

            ImprimirLista(vooCadastroEmbarque);

            Console.Write("\nDigite o Id do Voo para embarque: ");
            Guid idVoo = Helper.ValidadorGuid();

            voo = vooCadastroEmbarque.FirstOrDefault(c => c.Id.Equals(idVoo));

            if (voo == null)
            {
                Console.WriteLine("\nVoo não encontrado");
                continue;
            }

            Console.Write("\nSelecione a classe de viagem: \n\n1. Econômica \n2. Executiva \n3. Primeira Classe \n\nDigite a opção: ");
            opcaoMenu = Helper.ValidadorClasseViagem();

            var classeViagem = opcaoMenu switch
            {
                1 => ClasseViagemEnum.Economica,
                2 => ClasseViagemEnum.Executiva,
                _ => ClasseViagemEnum.PrimeiraClasse,
            };

            Console.Write("\nDigite o número da poltrona: ");
            int numeroPoltrona = Helper.ValidadorNumeroPoltrona();

            Embarque embarque = new Embarque(passageiro, voo, classeViagem, numeroPoltrona);

            embarques.Add(embarque);

            Console.WriteLine("\nEmbarque cadastrado com sucesso!");

            break;

        case 14:
            if (Helper.ValidaQuantidadeLista(embarques))
                continue;

            ImprimirLista(embarques);
            break;

        case 0:
            Console.WriteLine("\nSistema encerrado.");
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("\nOpção inválida, tente novamente.\n");
            break;
    }
}

void ImprimirLista<T>(List<T> lista)
{
    Console.WriteLine($"\nLista de {typeof(T).Name}s: \n");
    lista.ForEach(x => Console.WriteLine($"# - {x}"));
}

