using DapperNews.Models;
using DapperNews.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNews.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tГлавное меню");
            Console.WriteLine("Выберите:");
            Console.WriteLine("Добавление (нажмите 1)");
            Console.WriteLine("Удаление (нажмите 2)");

            NewsRepository _newsRep = new NewsRepository();

            int choise = int.Parse(Console.ReadLine());
            if (choise == 1)
            {
                do
                {
                    Console.Write("Новости: ");
                    var news = Console.ReadLine();
                    Console.Write("Комментарий: ");
                    var comment = Console.ReadLine();

                    _newsRep.InsertNews(@"INSERT INTO News (NewsNews, Comment)
                                        VALUES(@NewsNews, @Comment)",
                new News()
                {
                    NewsNews = news,
                    Comment = comment
                });

                    var newsN = _newsRep.GetAllNews("SELECT * FROM News");

                    newsN.ForEach(f =>
                    {
                        Console.WriteLine($"{f.Id}\t\t{f.NewsNews}\t\t{f.Comment}");
                    });
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }

            else if (choise == 2)
            {
                do
                {
                    _newsRep.GetAllNews("SELECT * FROM News").ForEach(f =>
                    {
                        Console.WriteLine($"{f.Id}\t\t{f.NewsNews}\t\t{f.Comment}");
                    });
                    Console.WriteLine("Введите идентификатор для удаления:");
                    var tmp = Console.ReadLine();
                    int IdSt;
                    int.TryParse(tmp, out IdSt);

                    _newsRep.DeleteNews(@"DELETE News WHERE Id = @Id", IdSt);

                    var newsN = _newsRep.GetAllNews("SELECT * FROM News");
                    newsN.ForEach(f =>
                    {
                        Console.WriteLine($"{f.Id}\t\t{f.NewsNews}\t\t{f.Comment}");
                    });

                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }

        }
    }
}
