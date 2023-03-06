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
      model.Add("artists", selectedArtist);
      model.Add("albums", artistAlbums);
      return View(model);
    }

    [HttpPost("artists/{artistsId}/albums")]
    public ActionResult Create(int artistsId, string albumsName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artists foundArtist = Artists.Find(artistsId);
      Albums newAlbums = new Albums(albumsName, artistsId);
      newAlbums.Save(); 
      foundArtist.AddAlbum(newAlbums);
      List<Albums> artistAlbums = foundArtist.Albums;
      model.Add("albums", artistAlbums);
      model.Add("artists", foundArtist);
      return View("Show", model);
    }

    [HttpGet("/artists/find")]
    public ActionResult Find()
    {
      return View();
    }

    [HttpPost("artists/search")]
    public ActionResult Search(string artistName)
    {
      int foundId = Artists.Search(artistName).Id;
      return RedirectToAction("Show", new { id = foundId });
    }
  }

}