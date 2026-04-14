using LojaVirtual.UI;

while (true)
{
    int opcaoMenu = Menu.MostrarMenu();

    switch (opcaoMenu)
    {
        case 1:
            Menu.CadastrarCategoria();
            break;
        case 2:
            Menu.VerificaCategoriasCadastradas();
            break;
        default:
            Console.WriteLine("Sistema encerrado");
            Thread.Sleep(1000);
            Environment.Exit(0);
            break;
    }

    continue;
}