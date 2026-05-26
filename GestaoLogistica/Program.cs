using GestaoLogistica.Enums;
using GestaoLogistica.Helpers;
using GestaoLogistica.Models;

// Transportadora transportadora = new("123", "Trans Miau", "RN", GestaoLogistica.Enums.ModalidadeTransporteEnum.Terrestre);

// Cliente cliente = new("Jão", "email@email.com", "13212312312", "84992268147");

// Pedido pedido = new("PED-123", 12.50m, 1.0, DateTime.Now, cliente);

// Entrega entrega = new(DateTime.Now, 10, "R. piroca da silva, 69, bairro dos cus, cidade das rolas", transportadora, pedido);

// Console.WriteLine(transportadora.ToString());
// Console.WriteLine();
// Console.WriteLine(cliente.ToString());
// Console.WriteLine();
// Console.WriteLine(pedido.ToString());
// Console.WriteLine();
// Console.WriteLine(entrega.ToString());

List<Transportadora> transportadoras = new List<Transportadora>();
List<Cliente> clientes = new List<Cliente>();
List<Pedido> pedidos = new List<Pedido>();
List<Entrega> entregas = new List<Entrega>();

Console.WriteLine("#### --- Gestão Logística EntregaJá---- ####");

while (true)
{
    Console.WriteLine("\nMenu de Opções");

    Console.WriteLine("\n##### Transportadoras #####");

    Console.WriteLine("\n1 - Cadastrar Transportadora");
    Console.WriteLine("2 - Listar Transportadora");
    Console.WriteLine("3 - Alterar dados de uma Transportadora");
    Console.WriteLine("4 - Excluir uma Transportadora");

    Console.WriteLine("\n0 - Sair");

    Console.Write("\nDigite uma opção: ");
    int opcaoMenu = Helper.ValidadorOpcaoMenu();

    switch (opcaoMenu)
    {
        case 1:
            System.Console.Write("Digite o código da Transportadora: ");
            string codigo = Helper.ValidadorTexto();

            var validaTransportadora = transportadoras.FirstOrDefault(t => t.CodigoUnico.Equals(codigo));

            if (validaTransportadora != null)
            {
                System.Console.WriteLine("Transportadora já cadastrada com o código informado!");
                continue;
            }

            System.Console.Write("Digite o nome da Transportadora: ");
            string nome = Helper.ValidadorTexto();

            System.Console.Write("Digite o Estado de operação da Transportadora: ");
            string estado = Helper.ValidadorTexto();

            System.Console.Write("Modalidades de opeção: \n1. Terrestre \n2. Aéreo \n3. Fluvial \nDigite modalidade da transportadora: ");
            int opcaoModalidade = Helper.ValidadorNumeroInterio();
            ModalidadeTransporteEnum modalidadeTransporte;

            switch (opcaoModalidade)
            {
                case 1:
                    modalidadeTransporte = ModalidadeTransporteEnum.Terrestre;
                    break;
                case 2:
                    modalidadeTransporte = ModalidadeTransporteEnum.Aereo;
                    break;
                default:
                    modalidadeTransporte = ModalidadeTransporteEnum.Fluvial;
                    break;
            }

            Transportadora transportadora = new(codigo, nome, estado, modalidadeTransporte);

            transportadoras.Add(transportadora);
            System.Console.WriteLine("Transportadora cadastrada");

            break;

        case 2:
            transportadoras.ForEach(t => System.Console.WriteLine(t.ToString()));
            break;

        default:
            Console.WriteLine("\nSistema encerrado");
            Environment.Exit(0);
            break;
    }
    continue;
}
;
