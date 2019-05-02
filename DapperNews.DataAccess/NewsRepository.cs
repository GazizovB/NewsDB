using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperNews.Models;

namespace DapperNews.DataAccess
{
    public class NewsRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\бауыржан\мой документы\visual studio 2015\Projects\DapperNews.ConsoleApp\DapperNews.DataAccess\NewsDB.mdf;Integrated Security=True";

        //Method InsertNews
        public string InsertNews(string query, News news)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                var result = sql.Execute(query, news);
                if (result < 1) throw new Exception("Ошибка при вставке записи новостей");
            }
            return "Вставка произошла успешно";
        }

        //Method Delete
        public void DeleteNews(string query, int id)
        {
            using (var sql = new SqlConnection(connectionString))
            {

                sql.Execute(query, new { Id = id });
            }
            //return "Удаление произошла успешно";
        }


        //Create method GetAllNews
        public List<News> GetAllNews(string query)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                return sql.Query<News>(query).ToList();
            }
        }

        public int Insert<T>(string query, T data)
        {
            using (var sql = new SqlConnection(connectionString))
            {
                return sql.Execute(query, data);
            }
        }

    }
}
