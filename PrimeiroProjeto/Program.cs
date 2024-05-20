// Screen sound


using System.Xml;

string mensagem = "Bem vindo ao Sreen Sound! \n";
//List<string> bandas = new List<string> { "AC/DC","Metallica","SouLuna"};

Dictionary<string,List<int>> bandas = new Dictionary<string,List<int>>();
bandas.Add("AC/DC",new List<int>());
bandas.Add("Linkin Park", new List<int> { 8,6,10});
bandas.Add("U2", new List<int> { 8, 6, 10 ,4});

void ExibirMensagem()
{
    Console.WriteLine(@"

█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀
");
    Console.WriteLine(mensagem);
    
}

void ExibirOpcoesMenu()
{
    ExibirMensagem();
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para listar as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média dee uma banda");
    Console.WriteLine("Digite -1 para sair");
    int opcao = int.Parse(Console.ReadLine()!);
    switch(opcao)
    {
        case 1:
            RegistrarBandas();
            break;
        case 2:
            MostrarBandas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            CalcularMediaBanda();
            break;
        case -1:
            Console.WriteLine("Tchau.");
            break;
        default: Console.WriteLine("Opção inválida");break; 

    }

}


void RegistrarBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registrar bandas");
    Console.Write("Digite o nome da banda: ");
    string banda = Console.ReadLine()!;
    bandas.Add(banda, new List<int>()); //adiciona a banda ao dicionario
    Console.WriteLine($"A banda {banda} foi registrada com sucesso."); //interpolação de string
    Thread.Sleep(2000);//esperar
    Console.Clear();
    ExibirOpcoesMenu();
}

void MostrarBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Listagem de bandas registradas");
    //for (int i = 0; i < bandas.Count;i++)
    //{
    //    Console.WriteLine($"Banda: {bandas[i]}");
    //}

    foreach (string banda in bandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesMenu();
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome  da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandas.ContainsKey(nomeBanda))
    {
        Console.Write($"Qual a nota para a banda{nomeBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandas[nomeBanda].Add(nota);// coloca a nota referenciando ao index correto da banda
        Console.WriteLine($"\nA nota {nota} foi registrada para a banda {nomeBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesMenu();
    } else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada.");
        Console.WriteLine("Digite uma tecla para voltar.");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesMenu();
    }

}

void CalcularMediaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média da Banda");
    Console.Write("Digite o nome da banda que deseja ver a média: ");
    string nomeBanda = Console.ReadLine()!;

    if (bandas.ContainsKey(nomeBanda))
    {
        Console.WriteLine($" a média da banda {nomeBanda} é {bandas[nomeBanda].Average()}");

    }else
    {
        Console.WriteLine("\nNão contém esta banda cadastrada");
    }
    Console.WriteLine("Digite uma tecla para voltar.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeLetras = titulo.Length; // pega quantas letras tem 
    string asteriscos = string.Empty.PadLeft(quantidadeLetras,'*'); // adicionar o * de acordo com o numero de letras
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

ExibirOpcoesMenu();

