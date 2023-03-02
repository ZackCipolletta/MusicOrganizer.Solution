using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artists> allArtists = Artists.GetAll();
      return View(allArtists);
    }


    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }

        [HttpPost("/artists")]
    public ActionResult Create(string artistName)
    {
      Artists newArtist = new Artists(artistName);
      return RedirectToAction("Index");
    }

        [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artists selectedArtist = Artists.Find(id);
      List<Albums> artistAlbums = selectedArtist.Albums;
      model.Add("artist", selectedArtist);
      model.Add("albums", artistAlbums);
      return View(model);
    }
  }
}