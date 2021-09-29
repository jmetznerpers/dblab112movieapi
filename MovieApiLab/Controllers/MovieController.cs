using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApiLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApiLab.Controllers
{
    [ApiController]
    [Route("api/Movies")]
    public class MovieController : ControllerBase
    {

        //CREATE
        [HttpPost("add")]
        public Movie addMovie(Movie newMovie)
        {
            return DAL.AddMovie(newMovie);
        }
        //CREATE

        //READ

        [HttpGet("random")] //doesn't seem to work, its not passsing the id like I am expecting it to.
        public Movie randomMovie()
        {
            int id = DAL.RandomMovie();
            return DAL.GetMovie(id);
        }
        [HttpGet()]
        public List<Movie> getAll()
        {
            return DAL.GetAllMovies();
        }

        [HttpGet("{id}")]
        public Movie getOne(int id)
        {
            return DAL.GetMovie(id);
        }

        [HttpGet("category/{cat}")]
        public List<Movie> getAllCat(string cat)
        {
            return DAL.GetMoviesByCategory(cat);
        }

        [HttpGet("director/{dir}")]
        public List<Movie> getAllDir(string dir)
        {
            return DAL.GetMoviesByDirector(dir);
        }

        [HttpGet("actor/{act}")]
        public List<Movie> getAllAct(string act)
        {
            return DAL.GetMoviesByActor(act);
        }

        [HttpGet("title/{title}")]
        public List<Movie> getAllTitle(string title)
        {
            return DAL.GetMoviesByTitle(title);
        }

        [HttpGet("rating/{rat}")]
        public List<Movie> getAllRating(string rat)
        {
            return DAL.GetMoviesByRating(rat);
        }

        [HttpGet("description/{desc}")]
        public List<Movie> getAllDesc(string desc)
        {
            return DAL.GetMoviesByDesc(desc);
        }
        //READ




        //UPDATE
        [HttpPut("update")]
        public Movie updateMovie(Movie movie)
        {
            return DAL.UpdateMovie(movie);
        }
        //UPDATE




        //DELETE
        [HttpDelete("delete")]
        public bool deleteMovie(int id)
        {
            return DAL.DeleteMovie(id);
        }
        //DELETE
    }
}
