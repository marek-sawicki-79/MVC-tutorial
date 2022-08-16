using CalculatorForTest;
using CalculatorForTest.Logs;

Calculator calculator = new();
LogManager logManager = new(new ReadWriteLog());
logManager.LoadLogs("logs.txt");

while (true)
{
    Console.Clear();
    Console.WriteLine("Witaj w kalkulatorze");
    Console.WriteLine("1. Dodaj");
    Console.WriteLine("2. Odejmij");
    Console.WriteLine("3. Pomnóż");
    Console.WriteLine("4. Podziel");
    Console.WriteLine("0. Wyjście");

    string input = Console.ReadLine();
    if (!int.TryParse(input, out int option))
    {
        Console.WriteLine("Wybrałęś nieprawidłową opcję");
        continue;
    }

    double first, second;
    double result;
    if (option == 0)
    {
        break;
    }

    Console.WriteLine("Podaj 1szą liczbę");
    string firstCandidate = Console.ReadLine();
    if (!double.TryParse(firstCandidate, out first))
    {
        Console.WriteLine("Nieprawidłowy format liczby");
        continue;
    }

    Console.WriteLine("Podaj 2gą liczbę");
    string secondCandidate = Console.ReadLine();
    if (!double.TryParse(secondCandidate, out second))
    {
        Console.WriteLine("Nieprawidłowy format liczby");
        continue;
    }

    switch (option)
    {
        case 1:
            result = calculator.Add(first, second);
            Console.WriteLine($"Wynik dodawania {first} oraz {second} wynosi {result}");
            break;
        case 2:
            result = calculator.Substract(first, second);
            Console.WriteLine($"Wynik odejmowania {second} od {first} wynosi {result}");
            break;
        case 3:
            result = calculator.Multiply(first, second);
            Console.WriteLine($"Wynik mnożenia {first} przez {second} wynosi {result}");
            break;
        case 4:
            try
            {
                result = calculator.Divide(first, second);
                Console.WriteLine($"Wynik to {result}");
                logManager.AddLog($"Wynik dzielenia {first} i {second} to {result}");
            }
            catch 
            {
                logManager.AddLog("Próba dzielenia przez 0");
            }
            break;
        default:
            break;
    }

    Console.ReadKey();
}
logManager.Save("logs.txt");
Console.WriteLine("Dzięki za liczenie");
Console.ReadKey();