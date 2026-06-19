using TransportadoraTranslogica.Enums;
using TransportadoraTranslogica.Helpers;
using TransportadoraTranslogica.Interfaces;
using TransportadoraTranslogica.Models;

List<Cliente> clientes = [];
List<CargaPadrao> cargaPadroes = [];
List<CargaFragil> cargasFrageis = [];
List<CargaPerigosa> cargaPerigosas = [];

Console.WriteLine("#### - Transportadora Translogica - ####");

while (true)
{
    MenuPrincipal();

    var opcao = Helper.ValidadorMenuPrincipal();

    switch (opcao)
    {
        case 1:
            MenuCliente();
            break;
        case 2:
            MenuCarga();
            break;
        case 3:
            MenuFuncionalidades();
            break;
        default:
            Console.WriteLine("\nSistema encerrado.");
            ReduzirTempo();
            Environment.Exit(0);
            break;
    }
    continue;
}

void MenuPrincipal()
{
    Console.Clear();

    Console.WriteLine("#### - Transportadora Translogica - ####");

    Console.WriteLine("\nEscolha uma opção: \n\n1 - Clientes \n2 - Cargas \n3 - Funcionalidades \n\n0 - Sair");

    Console.Write("\nDigite a opção desejada: ");
}

void MenuCliente()
{
    Console.Clear();

    Console.WriteLine("\n#### - Menu Cliente - ####");

    Console.WriteLine("\nEscolha uma opção: \n1 - Cadastro de Clientes \n2 - Listar Clientes \n3 - Alterar dados do Cliente \n4 - Alterar do Documento Cliente \n5 - Deletar Cliente \n\n0 - Voltar");

    Console.Write("\nDigite a opção desejada: ");

    var opcao = Helper.ValidadorMenuCliente();

    switch (opcao)
    {
        case 1:
            var opcaoCliente = TipoCliente();

            Console.Write("\nInforme o nome do cliente: ");
            var nomeCliente = Helper.ValidadorTexto();

            Console.Write($"\nInforme o {(opcaoCliente == 1 ? "CPF" : "CPNJ")} do cliente: ");
            var documentoCliente = opcaoCliente == 1 ? Helper.ValidadorCpf() : Helper.ValidadorCnpj();

            if (clientes.Any(x => x.Documento == documentoCliente))
            {
                Console.WriteLine("\nO documento informado já consta cadastrado no sistema.");
                ReduzirTempo();
                return;
            }

            Console.Write("\nInforme o telefone do cliente (11 dígitos e com o 9): ");
            var telefoneCliente = Helper.ValidadorTelefone();

            Cliente cliente = new(nomeCliente, telefoneCliente, documentoCliente);

            clientes.Add(cliente);

            MensagemSucesso("Cadastro");
            return;
        case 2:
            var resultadoContinuo = true;

            while (resultadoContinuo)
            {
                opcaoCliente = TipoCliente();

                switch (opcaoCliente)
                {
                    case 1:
                        var listaPessoasFisicas = clientes.Where(x => x.Documento.Length == 11).ToList();

                        if (Helper.ValidadorListaVazia(listaPessoasFisicas, "clientes como pessoa(s) física(s)"))
                            return;

                        ImprimirLista(listaPessoasFisicas, "clientes como pessoa(s) física(s)");
                        break;
                    default:
                        var listaEmpresas = clientes.Where(x => x.Documento.Length == 14).ToList();

                        if (Helper.ValidadorListaVazia(listaEmpresas, "clientes como empresa(s)"))
                            return;

                        ImprimirLista(listaEmpresas, "clientes como empresa(s)");
                        break;
                }

                Console.Write("\nDigite qualquer tecla para sair: ");
                var teclaSaida = Console.ReadLine();

                if (teclaSaida != null)
                    resultadoContinuo = false;
            }
            return;
        case 3:
            cliente = ValidadorCliente();

            if (Helper.ValidadorObjetoNulo(cliente))
                return;

            Console.Write("\nInforme o nome do cliente: ");
            nomeCliente = Helper.ValidadorTexto();

            Console.Write("\nInforme o telefone do cliente (11 dígitos e com o 9): ");
            telefoneCliente = Helper.ValidadorTelefone();

            cliente.AlterarDados(nomeCliente, telefoneCliente);

            MensagemSucesso("Alteração");
            return;
        case 4:
            cliente = ValidadorCliente();

            if (Helper.ValidadorObjetoNulo(cliente))
                return;

            Console.Write($"\nInforme o {(cliente.Documento.Length == 11 ? "CPF" : "CPNJ")} do cliente: ");
            documentoCliente = cliente.Documento.Length == 11 ? Helper.ValidadorCpf() : Helper.ValidadorCnpj();

            if (clientes.Any(x => x.Documento == documentoCliente))
            {
                Console.WriteLine("\nO documento informado já consta cadastrado no sistema.");
                ReduzirTempo();
                return;
            }

            cliente.AlterarDocumento(documentoCliente);

            MensagemSucesso("Alteração de documento");
            return;
        case 5:
            cliente = ValidadorCliente();

            if (Helper.ValidadorObjetoNulo(cliente))
                return;

            if (cargaPadroes.Any(x => x.ClienteDestinatario == cliente) || cargasFrageis.Any(x => x.ClienteDestinatario == cliente) || cargaPerigosas.Any(x => x.ClienteDestinatario == cliente))
            {
                Console.WriteLine("O cliente não pode ser exluído porque possuí uma carga cadastrada no sistema");
                ReduzirTempo();
                return;
            }

            var posicao = clientes.IndexOf(cliente);

            clientes.RemoveAt(posicao);

            MensagemSucesso("Exclusão");
            return;
        default:
            Console.WriteLine("\nVoltando ao menu principal.");
            ReduzirTempo();
            return;
    }
}

void MenuCarga()
{
    Console.Clear();

    if (Helper.ValidadorListaVazia(clientes, "clientes"))
        return;

    Console.WriteLine("\n#### - Menu Carga - ####");

    Console.WriteLine("\nEscolha uma opção: \n1 - Cadastro de Carga \n2 - Listar Cargas \n3 - Alterar dados de Carga \n4 - Alterar Código da Carga \n5 - Deletar Carga \n\n0 - Voltar");

    Console.Write("\nDigite a opção desejada: ");

    var opcao = Helper.ValidadorMenuCarga();

    switch (opcao)
    {
        case 1:
            var cliente = ValidadorCliente();

            if (Helper.ValidadorObjetoNulo(cliente))
                return;

            opcao = EscolhaCarga();

            Console.Write("\nInforme o código de identificação da carga: ");
            var codigoIdentificacao = Helper.ValidadorCodigoIdentificacao();

            if (cargaPadroes.Any(x => x.CodigoIdentificacao == codigoIdentificacao) || cargasFrageis.Any(x => x.CodigoIdentificacao == codigoIdentificacao) || cargaPerigosas.Any(x => x.CodigoIdentificacao == codigoIdentificacao))
            {
                Console.WriteLine("\nO Código de Identificação já consta cadastrado no sistema.");
                ReduzirTempo();
                return;
            }

            Console.Write("\nInforme o peso da carga: ");
            var pesoCarga = Helper.ValidadorDouble();

            Console.Write("\nInforme valor da carga: ");
            var valorCarga = Helper.ValidadorDecimal();

            if (opcao == 1)
            {
                CargaPadrao cargaPadrao = new(codigoIdentificacao, pesoCarga, valorCarga, cliente);
                cargaPadroes.Add(cargaPadrao);
            }

            if (opcao == 2)
            {
                Console.Write("\nInforme o material da embalagem: ");
                var materialEmbalagemCarga = Helper.ValidadorTexto();

                CargaFragil cargaFragil = new(codigoIdentificacao, pesoCarga, valorCarga, cliente, materialEmbalagemCarga);
                cargasFrageis.Add(cargaFragil);
            }

            if (opcao == 3)
            {
                Console.Write("\nInforme o número ONU da carga: ");
                var numeroOnu = Helper.ValidadorNumeroOnu();

                Console.Write("\nInforme o tipo de carga: \n\n1 - Mercadorias Inflamáveis \n2 - Químicas \n3 - Radioativas \n\nDigite a opção: ");
                var opcaoMenuTipoCarga = Helper.ValidadorTipoCargaPerigosa();

                var tipoCarga = opcaoMenuTipoCarga switch
                {
                    1 => TipoCargaPerigosaEnum.MercadoriasInflamaveis,
                    2 => TipoCargaPerigosaEnum.Quimicas,
                    _ => TipoCargaPerigosaEnum.Radioativas,
                };

                Console.Write("\nInforme a classe risco da carga: \n\n1 - Inflamável \n2 - Corrosiva \n3 - Radioativa \n\nDigite a opção: ");
                var opcaoMenuClasse = Helper.ValidadorClasseRiscoCarga();

                var classeRiscoCarga = opcaoMenuTipoCarga switch
                {
                    1 => ClasseRiscoEnum.Inflamavel,
                    2 => ClasseRiscoEnum.Corrosiva,
                    _ => ClasseRiscoEnum.Radioativa,
                };

                CargaPerigosa cargaPerigosa = new(codigoIdentificacao, pesoCarga, valorCarga, cliente, tipoCarga, classeRiscoCarga, numeroOnu);
                cargaPerigosas.Add(cargaPerigosa);
            }

            MensagemSucesso("Casdastro");
            return;
        case 2:
            opcao = EscolhaCarga();

            if (opcao == 1)
            {
                if (Helper.ValidadorListaVazia(cargaPadroes, "cargas padrões"))
                    return;

                var resultadoContinuo = true;

                while (resultadoContinuo)
                {
                    ImprimirLista(cargaPadroes, "cargas padrões");

                    Console.Write("\nDigite qualquer tecla para sair: ");
                    var teclaSaida = Helper.ValidadorTexto();

                    if (teclaSaida != null)
                        resultadoContinuo = false;
                }
            }

            if (opcao == 2)
            {
                if (Helper.ValidadorListaVazia(cargasFrageis, "cargas frágeis"))
                    return;

                var resultadoContinuo = true;

                while (resultadoContinuo)
                {
                    ImprimirLista(cargasFrageis, "cargas frágeis");

                    Console.Write("\nDigite qualquer tecla para sair: ");
                    var teclaSaida = Helper.ValidadorTexto();

                    if (teclaSaida != null)
                        resultadoContinuo = false;
                }
            }

            if (opcao == 3)
            {
                if (Helper.ValidadorListaVazia(cargaPerigosas, "cargas perigosas"))
                    return;

                var resultadoContinuo = true;

                while (resultadoContinuo)
                {
                    ImprimirLista(cargaPerigosas, "cargas perigosas");

                    Console.Write("\nDigite qualquer tecla para sair: ");
                    var teclaSaida = Helper.ValidadorTexto();

                    if (teclaSaida != null)
                        resultadoContinuo = false;
                }
            }
            return;
        case 3:
            opcao = EscolhaCarga();

            if (opcao == 1)
            {
                var carga = ValidadorCargaPadrao();

                if (Helper.ValidadorObjetoNulo(carga))
                    return;

                cliente = ValidadorCliente();

                if (Helper.ValidadorObjetoNulo(cliente))
                    return;

                Console.Write("\nInforme o peso da carga: ");
                pesoCarga = Helper.ValidadorDouble();

                Console.Write("\nInforme valor da carga: ");
                valorCarga = Helper.ValidadorDecimal();

                Console.Write("\nInforme o tipo do Status Operacional: \n\n1 - Pendente \n2 - Em Trânsito \n3 - Entregue \n4 - Cancelado \n\nDigite a opção: ");
                var opcaoMenuStatusOperacional = Helper.ValidadorStatusOperacionalCarga();

                var statusOperacional = opcaoMenuStatusOperacional switch
                {
                    1 => StatusOperacionalEnum.Pendente,
                    2 => StatusOperacionalEnum.EmTransito,
                    3 => StatusOperacionalEnum.Entregue,
                    _ => StatusOperacionalEnum.Cancelado,
                };

                carga.AlterarDados(pesoCarga, valorCarga, cliente, statusOperacional);

                MensagemSucesso("Alteração");
            }

            if (opcao == 2)
            {
                var carga = ValidadorCargaFragil();

                if (Helper.ValidadorObjetoNulo(carga))
                    return;

                cliente = ValidadorCliente();

                if (Helper.ValidadorObjetoNulo(cliente))
                    return;

                Console.Write("\nInforme o peso da carga: ");
                pesoCarga = Helper.ValidadorDouble();

                Console.Write("\nInforme valor da carga: ");
                valorCarga = Helper.ValidadorDecimal();

                Console.Write("\nInforme o tipo do Status Operacional: \n\n1 - Pendente \n2 - Em Trânsito \n3 - Entregue \n4 - Cancelado \n\nDigite a opção: ");
                var opcaoMenuStatusOperacional = Helper.ValidadorStatusOperacionalCarga();

                var statusOperacional = opcaoMenuStatusOperacional switch
                {
                    1 => StatusOperacionalEnum.Pendente,
                    2 => StatusOperacionalEnum.EmTransito,
                    3 => StatusOperacionalEnum.Entregue,
                    _ => StatusOperacionalEnum.Cancelado,
                };

                Console.Write("\nInforme o material da embalagem: ");
                var materialEmbalagemCarga = Helper.ValidadorTexto();

                carga.AlterarDados(pesoCarga, valorCarga, cliente, statusOperacional);
                carga.AlterarMaterialEmbalagem(materialEmbalagemCarga);

                MensagemSucesso("Alteração");
            }

            if (opcao == 3)
            {
                var carga = ValidadorCargaPerigosa();

                if (Helper.ValidadorObjetoNulo(carga))
                    return;

                cliente = ValidadorCliente();

                if (Helper.ValidadorObjetoNulo(cliente))
                    return;

                Console.Write("\nInforme o peso da carga: ");
                pesoCarga = Helper.ValidadorDouble();

                Console.Write("\nInforme valor da carga: ");
                valorCarga = Helper.ValidadorDecimal();

                Console.Write("\nInforme o tipo do Status Operacional: \n\n1 - Pendente \n2 - Em Trânsito \n3 - Entregue \n4 - Cancelado \n\nDigite a opção: ");
                var opcaoMenuStatusOperacional = Helper.ValidadorStatusOperacionalCarga();

                var statusOperacional = opcaoMenuStatusOperacional switch
                {
                    1 => StatusOperacionalEnum.Pendente,
                    2 => StatusOperacionalEnum.EmTransito,
                    3 => StatusOperacionalEnum.Entregue,
                    _ => StatusOperacionalEnum.Cancelado,
                };

                Console.Write("\nInforme o tipo de carga: \n\n1 - Mercadorias Inflamáveis \n2 - Químicas \n3 - Radioativas \n\nDigite a opção: ");
                var opcaoMenuTipoCarga = Helper.ValidadorTipoCargaPerigosa();

                var tipoCarga = opcaoMenuTipoCarga switch
                {
                    1 => TipoCargaPerigosaEnum.MercadoriasInflamaveis,
                    2 => TipoCargaPerigosaEnum.Quimicas,
                    _ => TipoCargaPerigosaEnum.Radioativas,
                };

                Console.Write("\nInforme a classe risco da carga: \n\n1 - Inflamável \n2 - Corrosiva \n3 - Radioativa \n\nDigite a opção: ");
                var opcaoMenuClasse = Helper.ValidadorClasseRiscoCarga();

                var classeRiscoCarga = opcaoMenuTipoCarga switch
                {
                    1 => ClasseRiscoEnum.Inflamavel,
                    2 => ClasseRiscoEnum.Corrosiva,
                    _ => ClasseRiscoEnum.Radioativa,
                };

                carga.AlterarDados(pesoCarga, valorCarga, cliente, statusOperacional);

                carga.AlterarTipoCarga(tipoCarga);
                carga.AlterarClasseRisco(classeRiscoCarga);

                MensagemSucesso("Alteração");
            }
            return;
        case 4:
            opcao = EscolhaCarga();

            if (opcao == 1)
            {
                var carga = ValidadorCargaPadrao();

                if (Helper.ValidadorObjetoNulo(carga))
                    return;

                Console.Write("\nInforme o código de identificação da carga: ");
                codigoIdentificacao = Helper.ValidadorCodigoIdentificacao();

                if (cargaPadroes.Any(x => x.CodigoIdentificacao == codigoIdentificacao) || cargasFrageis.Any(x => x.CodigoIdentificacao == codigoIdentificacao) || cargaPerigosas.Any(x => x.CodigoIdentificacao == codigoIdentificacao))
                {
                    Console.WriteLine("\nO Código de Identificação já consta cadastrado no sistema.");
                    ReduzirTempo();
                    return;
                }

                carga.AlterarCodigoIdentificacao(codigoIdentificacao);

                MensagemSucesso("Alteração");
            }

            if (opcao == 2)
            {
                var carga = ValidadorCargaFragil();

                if (Helper.ValidadorObjetoNulo(carga))
                    return;

                Console.Write("\nInforme o código de identificação da carga: ");
                codigoIdentificacao = Helper.ValidadorCodigoIdentificacao();

                if (cargaPadroes.Any(x => x.CodigoIdentificacao == codigoIdentificacao) || cargasFrageis.Any(x => x.CodigoIdentificacao == codigoIdentificacao) || cargaPerigosas.Any(x => x.CodigoIdentificacao == codigoIdentificacao))
                {
                    Console.WriteLine("\nO Código de Identificação já consta cadastrado no sistema.");
                    ReduzirTempo();
                    return;
                }

                carga.AlterarCodigoIdentificacao(codigoIdentificacao);

                MensagemSucesso("Alteração");
            }

            if (opcao == 3)
            {
                var carga = ValidadorCargaPerigosa();

                if (Helper.ValidadorObjetoNulo(carga))
                    return;

                Console.Write("\nInforme o código de identificação da carga: ");
                codigoIdentificacao = Helper.ValidadorCodigoIdentificacao();

                if (cargaPadroes.Any(x => x.CodigoIdentificacao == codigoIdentificacao) || cargasFrageis.Any(x => x.CodigoIdentificacao == codigoIdentificacao) || cargaPerigosas.Any(x => x.CodigoIdentificacao == codigoIdentificacao))
                {
                    Console.WriteLine("\nO Código de Identificação já consta cadastrado no sistema.");
                    ReduzirTempo();
                    return;
                }

                carga.AlterarCodigoIdentificacao(codigoIdentificacao);

                MensagemSucesso("Alteração");
            }
            return;
        case 5:
            opcao = EscolhaCarga();

            if (opcao == 1)
            {
                var carga = ValidadorCargaPadrao();

                if (Helper.ValidadorObjetoNulo(carga))
                    return;

                var posicao = cargaPadroes.IndexOf(carga);

                cargaPadroes.RemoveAt(posicao);
            }

            if (opcao == 2)
            {
                var carga = ValidadorCargaFragil();

                if (Helper.ValidadorObjetoNulo(carga))
                    return;

                var posicao = cargasFrageis.IndexOf(carga);

                cargaPadroes.RemoveAt(posicao);
            }

            if (opcao == 3)
            {
                var carga = ValidadorCargaPerigosa();

                if (Helper.ValidadorObjetoNulo(carga))
                    return;

                var posicao = cargaPerigosas.IndexOf(carga);

                cargaPerigosas.RemoveAt(posicao);
            }
            MensagemSucesso("Exclusão");
            return;
        default:
            Console.WriteLine("\nVoltando ao menu principal.");
            ReduzirTempo();
            return;
    }
}

void MenuFuncionalidades()
{
    Console.Clear();

    Console.WriteLine("\n#### - Menu Funcionalidades - ####");

    Console.WriteLine("\nEscolha uma opção: \n1 - Busca geral de clientes (parcial) \n2 - Busca exata de clientes (case-insensitive) \n3 - Relatório Geral de Cargas \n4 - Busca de Cargas por Cliente \n5 - Painel de Rastreamento de Encomendas \n\n0 - Voltar");

    Console.Write("\nDigite a opção desejada: ");

    var opcao = Helper.ValidadorMenuFuncionalidade();

    switch (opcao)
    {
        case 1:
            if (Helper.ValidadorListaVazia(clientes, "clientes"))
                return;

            Console.Write("\nDigite o nome do cliente para busca: ");
            var nomeCliente = Helper.ValidadorTexto().ToLower();

            var resultadoBusca = clientes.Where(x => x.Nome.ToLower().Contains(nomeCliente)).ToList();

            if (resultadoBusca.Count == 0)
            {
                Console.WriteLine("\nNenhum cliente encontrado.");
                ReduzirTempo();
                return;
            }

            var resultadoContinuo = true;

            while (resultadoContinuo)
            {
                Console.WriteLine($"\nClientes encontrados com o nome \"{nomeCliente}\": \n");
                resultadoBusca.ForEach(x => Console.WriteLine($"# - {x}"));

                Console.Write("\nDigite qualquer tecla para sair: ");
                var teclaSaida = Helper.ValidadorTexto();

                if (teclaSaida != null)
                    resultadoContinuo = false;
            }
            return;
        case 2:
            if (Helper.ValidadorListaVazia(clientes, "clientes"))
                return;

            Console.Write("\nDigite o nome do cliente para busca: ");
            nomeCliente = Helper.ValidadorTexto();

            resultadoBusca = clientes.Where(x => x.Nome.Contains(nomeCliente)).ToList();

            if (resultadoBusca.Count == 0)
            {
                Console.WriteLine("\nNenhum cliente encontrado.");
                ReduzirTempo();
                return;
            }

            resultadoContinuo = true;

            while (resultadoContinuo)
            {
                Console.WriteLine($"\nClientes encontrados com o nome \"{nomeCliente}\": \n");
                resultadoBusca.ForEach(x => Console.WriteLine($"# - {x}"));

                Console.Write("\nDigite qualquer tecla para sair: ");
                var teclaSaida = Helper.ValidadorTexto();

                if (teclaSaida != null)
                    resultadoContinuo = false;
            }
            return;
        case 3:
            if (Helper.ValidadorListaVazia(cargaPadroes, "cargas padrões") && Helper.ValidadorListaVazia(cargasFrageis, "cargas fragéis") && Helper.ValidadorListaVazia(cargaPerigosas, "cargas perigosas"))
                return;

            var todasAsCargas = cargaPadroes.Cast<Carga>()
                .Concat(cargasFrageis)
                .Concat(cargaPerigosas)
                .ToList();

            todasAsCargas.ForEach(x => x.CalcularFrete());

            var relatorioCargas = todasAsCargas
                .Select(x => new { x.CodigoIdentificacao, Cliente = x.ClienteDestinatario.Nome, x.Frete })
                .ToList();

            resultadoContinuo = true;

            while (resultadoContinuo)
            {
                Console.WriteLine("\nRelatório Geral de Cargas: \n");
                relatorioCargas.ForEach(y => Console.WriteLine($"# - Código: {y.CodigoIdentificacao} | Tipo Carga: {(cargaPadroes.Any(x => x.CodigoIdentificacao == y.CodigoIdentificacao) ? "Carga Padrão" : (cargasFrageis.Any(x => x.CodigoIdentificacao == y.CodigoIdentificacao) ? "Carga Frágil" : (cargaPerigosas.Any(x => x.CodigoIdentificacao == y.CodigoIdentificacao) ? "Carga Perigoso" : "")))}| Cliente: {y.Cliente} | Frete: {y.Frete:c}"));

                Console.Write("\nDigite qualquer tecla para sair: ");
                var teclaSaida = Helper.ValidadorTexto();

                if (teclaSaida != null)
                    resultadoContinuo = false;
            }
            break;
        case 4:
            if (Helper.ValidadorListaVazia(clientes, "clientes"))
                return;

            if (Helper.ValidadorListaVazia(cargaPadroes, "cargas padrões") && Helper.ValidadorListaVazia(cargasFrageis, "cargas fragéis") && Helper.ValidadorListaVazia(cargaPerigosas, "cargas perigosas"))
                return;

            var cliente = ValidadorCliente();

            if (Helper.ValidadorObjetoNulo(cliente))
                return;

            Console.Write($"\nInforme o {(cliente.Documento.Length == 11 ? "CPF" : "CPNJ")} do cliente: ");
            var documentoCliente = cliente.Documento.Length == 11 ? Helper.ValidadorCpf() : Helper.ValidadorCnpj();

            if (!clientes.Any(x => x.Documento == documentoCliente))
            {
                Console.WriteLine("\nDocumento não encontrado.");
                ReduzirTempo();
                return;
            }

            var listasConcatenadas = cargaPadroes.Cast<Carga>()
                .Concat(cargasFrageis)
                .Concat(cargaPerigosas)
                .ToList();

            var resultadoBuscaCarCliente = listasConcatenadas
                .Where(x => x.ClienteDestinatario.Documento == documentoCliente)
                .ToList();

            if (resultadoBuscaCarCliente.Count == 0)
            {
                Console.WriteLine($"\nNenhuma carga vinculada ao documento {documentoCliente}.");
                ReduzirTempo();
                return;
            }

            resultadoContinuo = true;

            while (resultadoContinuo)
            {
                Console.WriteLine($"\nCargas relacionadas ao documento {documentoCliente}: \n");

                resultadoBuscaCarCliente.ForEach(x => Console.Write($"# - {x} \n\n"));

                Console.Write("\nDigite qualquer tecla para sair: ");
                var teclaSaida = Helper.ValidadorTexto();

                if (teclaSaida != null)
                    resultadoContinuo = false;
            }
            return;
        case 5:
            if (Helper.ValidadorListaVazia(clientes, "clientes"))
                return;

            if (Helper.ValidadorListaVazia(cargaPadroes, "cargas padrões") && Helper.ValidadorListaVazia(cargasFrageis, "cargas fragéis") && Helper.ValidadorListaVazia(cargaPerigosas, "cargas perigosas"))
                return;

            listasConcatenadas = cargaPadroes.Cast<Carga>().Concat(cargasFrageis).Concat(cargaPerigosas).ToList();

            var resultadoRastreamento = listasConcatenadas
                .OfType<IRastreavel>()
                .Select(x => new
                {
                    ((Carga)x).CodigoIdentificacao,
                    x.CodigoRastreio,
                    Instrucoes = x.ObterInstrucoesSeguranca()
                })
                .ToList();

            if (resultadoRastreamento.Count == 0)
            {
                Console.WriteLine("\nNenhuma carga rastreável cadastrada.");
                ReduzirTempo();
                return;
            }

            resultadoContinuo = true;

            while (resultadoContinuo)
            {
                Console.WriteLine("\nPainel de Rastreamento de Encomendas: \n");
                resultadoRastreamento.ForEach(x => Console.Write($"# - Código: {x.CodigoIdentificacao} | Rastreio: {x.CodigoRastreio} | {x.Instrucoes} \n\n"));

                Console.Write("\nDigite qualquer tecla para sair: ");
                var teclaSaida = Helper.ValidadorTexto();

                if (teclaSaida != null)
                    resultadoContinuo = false;
            }
            break;
        default:
            Console.WriteLine("\nVoltando ao menu principal.");
            ReduzirTempo();
            return;
    }

}

Cliente ValidadorCliente()
{
    if (Helper.ValidadorListaVazia(clientes, "clientes"))
        return null;

    var opcaoCliente = TipoCliente();

    switch (opcaoCliente)
    {
        case 1:
            var listaPessoasFisicas = clientes.Where(x => x.Documento.Length == 11).ToList();

            if (Helper.ValidadorListaVazia(listaPessoasFisicas, "clientes como pessoa(s) física(s)"))
                return null;

            ImprimirLista(listaPessoasFisicas, "clientes como pessoa(s) física(s)");
            break;
        default:
            var listaEmpresas = clientes.Where(x => x.Documento.Length == 14).ToList();

            if (Helper.ValidadorListaVazia(listaEmpresas, "clientes como empresa(s)"))
                return null;

            ImprimirLista(listaEmpresas, "clientes como empresa(s)");
            break;
    }

    Console.Write("\nInforme o Id da cliente desejado: ");
    var idCliente = Helper.ValidadorGuid();

    var cliente = clientes.FirstOrDefault(x => x.Id.Equals(idCliente));

    return cliente;
}

CargaFragil ValidadorCargaFragil()
{
    if (Helper.ValidadorListaVazia(cargasFrageis, "cargas frágeis"))
        return null;

    ImprimirLista(cargasFrageis, "cargas frágeis");

    Console.Write("\nInforme o Id da carga desejada: ");
    var idCarga = Helper.ValidadorGuid();

    var carga = cargasFrageis.FirstOrDefault(x => x.Id.Equals(idCarga));

    return carga;
}

CargaPadrao ValidadorCargaPadrao()
{
    if (Helper.ValidadorListaVazia(cargaPadroes, "cargas padrões"))
        return null;

    ImprimirLista(cargaPadroes, "cargas padrões");

    Console.Write("\nInforme o Id da carga desejada: ");
    var idCarga = Helper.ValidadorGuid();

    var carga = cargaPadroes.FirstOrDefault(x => x.Id.Equals(idCarga));

    return carga;
}

CargaPerigosa ValidadorCargaPerigosa()
{
    if (Helper.ValidadorListaVazia(cargaPerigosas, "cargas perigosa"))
        return null;

    ImprimirLista(cargaPerigosas, "cargas perigosa");

    Console.Write("\nInforme o Id da carga desejada: ");
    var idCarga = Helper.ValidadorGuid();

    var carga = cargaPerigosas.FirstOrDefault(x => x.Id.Equals(idCarga));

    return carga;
}

int EscolhaCarga()
{
    int opcao;

    Console.Write("\nEscolha o tipo da Carga: \n\n1 - Carga Padrão \n2 - Carga Frágil \n3 - Carga Pereigosa \n\nEscolha uma opção: ");

    while (!int.TryParse(Console.ReadLine().Trim(), out opcao) || opcao < 0 || opcao > 3)
        Console.Write("\nOpção inválida, digite novamente: ");

    return opcao;
}

void ImprimirLista<T>(List<T> lista, string texto)
{
    Console.WriteLine($"\nItens cadastrados na lista de {texto}: \n");
    lista.ForEach(x => Console.WriteLine(x));
}

int TipoCliente()
{
    Console.Write("\nSelecione uma opção: \n\n1 - Cliente Pessoa Física \n2 - Empresas \n\nDigite a opção desejada: ");

    int opcaoMenu;

    while (!int.TryParse(Console.ReadLine().Trim(), out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > 2)
        Console.Write("Opção inválida, digite novamente: ");

    return opcaoMenu;
}

void MensagemSucesso(string acao)
{
    Console.WriteLine($"\n{acao} realizado(a) com sucesso.");
    ReduzirTempo();
}

void ReduzirTempo() => Thread.Sleep(1500);
