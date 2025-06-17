//Screen Sound
string mensagemBoasVindas = "Boas vindas ao screen sound!";
//List<string> listaDasBandas = new List<string> {"U2", "The Beatles", "Calypso"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 5, 7, 2 });
bandasRegistradas.Add("The Beatles", new List<int>()); 

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemBoasVindas);
}

void ExibirMenuPrincipal()
{
    Console.WriteLine("\nDigite 1 para resgistrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair do programa");

    Console.Write("\nDigite uma opção: ");
    string opcao = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcao);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            Console.WriteLine("Você escolheu registrar uma banda.");
            RegistrarBandas();
            break;
        case 2:
            Console.WriteLine("Você escolheu mostrar todas as bandas.");
            ExibirBandasRegistradas();
            break;
        case 3:
            Console.WriteLine("Você escolheu avaliar uma banda");
            AvaliarUmaBanda();
            break;
        case 4:
            Console.WriteLine("Você escolheu exibir a média de uma banda.");
            ExibirMediaDeBanda();
            break;
        case -1:
            Console.WriteLine("Saindo do programa...");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida. Por favor, digite novamete uma opção válida.");
            break;
    }

}

void RegistrarBandas() 
{
    Console.Clear();
    ExibirTituloDaOpcao("Registrar Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"\nA banda {nomeBanda} foi registrada!");

    Thread.Sleep(4000);
    Console.Clear();
    ExibirMenuPrincipal();
}

void ExibirBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Mostar bandas registradas");

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal:");
    Console.ReadKey();
    Console.Clear();
    ExibirMenuPrincipal();
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar uma banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirMenuPrincipal();
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal:");
        Console.ReadKey();
        Console.Clear();
        ExibirMenuPrincipal();
    }
}

void ExibirMediaDeBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média da banda");

    Console.Write("Qual banda você deseja visualizar a média? ");
    string nomeBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        if (bandasRegistradas[nomeBanda].Count > 0)
        {
            double media = bandasRegistradas[nomeBanda].Average();
            Console.WriteLine($"\nA média da banda {nomeBanda} é {media:F2}");

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal:");
            Console.ReadKey();
            Console.Clear();
            ExibirMenuPrincipal();
        }
        else
        {
            Console.WriteLine($"A banda {nomeBanda} está registrada, porém, ainda não possui nenhuma avaliação.");
            Thread.Sleep(3000);
            Console.Clear();
            ExibirMenuPrincipal();
        }
    }
    else
    {
        Console.WriteLine($"A banda {nomeBanda} não foi encontrada!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal:");
        Console.ReadKey();
        Console.Clear();
        ExibirMenuPrincipal();
    }
}

void ExibirTituloDaOpcao(string titulo)
{
    int qtnLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtnLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}



ExibirLogo();
ExibirMenuPrincipal();