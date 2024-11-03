using Film3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Film3.Controllers
{
    public class FilmController : Controller
    {

        private static List<Film> films = new List<Film>
        {
            new Film(){Id = 1, Name = "Film1", Description = "opis1", Price = 4},
            new Film(){Id = 2, Name = "Film2", Description = "opis2", Price = 5},
            new Film(){Id = 3, Name = "Film3", Description = "opis3", Price = 3}
        };
        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count +1;
            films.Add(film);
                return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            Film film = films.FirstOrDefault(x => x.Id == id);
            return View(film);
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film newfilm)
        {
            try
            {
                Film film = films.FirstOrDefault(x => x.Id == id);
                film.Name = newfilm.Name;
                film.Description = newfilm.Description;
                film.Price = newfilm.Price;
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();  
            }
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            Film film = films.FirstOrDefault(x => x.Id == id);
            return View(film);
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) 
        { 
            try
            {
                Film film = films.FirstOrDefault(x => x.Id == id);
                films.Remove(film);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
