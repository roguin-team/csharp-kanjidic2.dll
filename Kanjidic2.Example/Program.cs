using Kanjidic2;
using Kanjidic2.Example;
using Kanjidic2.Models;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;
ConsoleSettings.SetConsoleFont("MS Mincho", 20);

Console.WriteLine("KANJIDIC2");
Console.WriteLine("===================================================================\n\n");

using Kanjidic2DataAccess kanjidic2 = new Kanjidic2DataAccess();
while (true)
{
    Console.WriteLine("MENU");
    Console.WriteLine("1. GetAll");
    Console.WriteLine("2. JLPT Kanji");
    Console.WriteLine("3. Get by On'yomi");
    Console.WriteLine("4. Get by Kun'yomi");
    Console.WriteLine("0: Exit");

    Console.Write("\nSelect: ");
    string? selected = Console.ReadLine();
    Console.Clear();

    switch (selected)
    {
        case "0":
            Environment.Exit(0); break;
        case "1":
            Console.WriteLine("ALL KANJI\n\n");
            IEnumerable<Kanjidic2Model> allKanji = kanjidic2.GetAll();
            foreach (var model in allKanji.Select(s => new { Literal = s.Literal }))
            {
                Console.WriteLine($"Literal: {model.Literal}");
               
            }
            break;

        case "2":
            Console.WriteLine("JLPT KANJI\n\n");
            Console.Write("Select Jlpt Level: ");
            string? jlptLevel = Console.ReadLine();
            IEnumerable<Kanjidic2Model> jlptKanji = kanjidic2.GetJLPTKanji(int.Parse(jlptLevel!));
            foreach (var model in jlptKanji.Select(s => new { Literal = s.Literal }))
            {
                Console.WriteLine($"Literal: {model.Literal}");
            }
            break;

        case "3":
            Console.WriteLine("GET BY ON'YOMI\n\n");
            Console.Write("On'yomi (Kana): ");
            string? onReading = Console.ReadLine();
            IEnumerable<Kanjidic2Model> kanji_ByOnyomi = kanjidic2.GetByOnyomi(onReading!);
            foreach (var model in kanji_ByOnyomi.Select(s => new { Literal = s.Literal }))
            {
                Console.WriteLine($"Literal: {model.Literal}");
            }
            break;

        case "4":
            Console.WriteLine("GET BY KUN'YOMI\n\n");
            Console.Write("Kun'yomi (Kana): ");
            string? kunReading = Console.ReadLine();
            IEnumerable<Kanjidic2Model> kanji_ByKunyomi = kanjidic2.GetByOnyomi(kunReading!);
            foreach (var model in kanji_ByKunyomi.Select(s => new { Literal = s.Literal }))
            {
                Console.WriteLine($"Literal: {model.Literal}");
            }
            break;
        default:
            break;
    }
    Console.ReadKey();
    Console.Clear();
    GC.Collect();
}