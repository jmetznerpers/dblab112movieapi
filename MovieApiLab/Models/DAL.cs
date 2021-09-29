using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;

namespace MovieApiLab.Models
{

    public class DAL
    {
        public static MySqlConnection DB;
        //CREATE
        public static Movie AddMovie(Movie movie)
        {
            DB.Insert<Movie>(movie);
            return movie;
        }
        //READ
        public static List<Movie> GetAllMovies()
        {
            return DB.GetAll<Movie>().ToList();
        }

        public static Movie GetMovie(int id)
        {
            return DB.Get<Movie>(id);
        }

        public static List<Movie> GetMoviesByCategory(string theCat)
        {
            string sql = "select * from movies where category Like @theCat;";
            return DB.Query<Movie>(sql, new { theCat = "%" +theCat+ "%"}).ToList(); ;
        }

        public static List<Movie> GetMoviesByActor(string theAct)
        {
            string sql = "select * from movies where mainactor Like @theAct;";
            return DB.Query<Movie>(sql, new { theAct = "%" + theAct + "%" }).ToList(); ;
        }

        public static List<Movie> GetMoviesByDirector(string theDir)
        {
            string sql = "select * from movies where director Like @theDir;";
            return DB.Query<Movie>(sql, new { theDir = "%" + theDir + "%" }).ToList(); ;
        }

        public static List<Movie> GetMoviesByRating(string theRating)
        {
            string sql = "select * from movies where rating Like @theRating;";
            return DB.Query<Movie>(sql, new { theRating = "%" + theRating + "%" }).ToList(); ;
        }

        public static List<Movie> GetMoviesByTitle(string theTitle)
        {
            string sql = "select * from movies where title Like @theTitle;";
            return DB.Query<Movie>(sql, new { theTitle = "%" + theTitle + "%" }).ToList(); ;
        }

        public static List<Movie> GetMoviesByDesc(string theDesc)
        {
            string sql = "select * from movies where descript Like @theDesc;";
            return DB.Query<Movie>(sql, new { theDesc = "%" + theDesc + "%" }).ToList(); ;
        }

        public static int RandomMovie()
        {
            string sql = "select id from movies order by rand() limit 1;";
            Movie mov = DB.Get<Movie>(sql);
            //int id = mov.id;
            return mov.id;           
        }

        //UPDATE
        public static Movie UpdateMovie(Movie movie)
        {
            DB.Update<Movie>(movie);
            return movie;
        }
        //DELETE
        public static bool DeleteMovie(int _id)
        {
            Movie temp = new Movie() { id = _id };
            DB.Delete<Movie>(temp);
            return true;
        }
    }
}
