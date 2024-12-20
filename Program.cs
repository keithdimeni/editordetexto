namespace EditorDeTexto;
//using System.IO;

class Program
{
    static void Main()
    {
        Menu();
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("O que voce deseja fazer?");
        Console.WriteLine("1 - Abrir arquivo");
        Console.WriteLine("2 - Criar novo arquivo");
        Console.WriteLine("0 - Sair");

        short option = short.Parse(Console.ReadLine());

        switch (option)
        {
            case 0: Environment.Exit(0); break;
            case 1: Open(); break;
            case 2: Edit(); break;
            default: Menu(); break;
        }
    }

    static void Open()
    {
        Console.Clear();
        Console.WriteLine("Digite o caminho do arquivo: ");
        string path = Console.ReadLine();

        using (var file = new StreamReader(path))
        {
            Console.WriteLine(file.ReadToEnd());
        }
        Console.WriteLine();
        Console.ReadLine();
        Menu();
    }

    static void Edit()
    {
        Console.Clear();
        Console.WriteLine("Digite abaixo (ESC para sair)");
        Console.WriteLine("--------------------");

        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;
        } while (Console.ReadKey().Key != ConsoleKey.Escape);

        Save(text);

    }

    static void Save(string text)
    {
        Console.Clear();
        Console.WriteLine(" Qual caminho para salvar o arquivo?");
        string? path = Console.ReadLine();

        using (var file = new StreamWriter(path))
        {
            file.Write(text);
        }

        Console.WriteLine($"Arquivo {path} salvo com sucesso!");
        Console.ReadLine();
        Menu();
    }
}