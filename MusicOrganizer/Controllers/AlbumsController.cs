using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class AlbumsController : Controller
  {

    [HttpGet("/artists/{artistsId}/albums/new")]
    public ActionResult New(int artistsId)
    {
      Artists artists = Artists.Find(artistsId);
      return View(artists);
    }

    [HttpGet("/artists/{artistsId}/albums/{albumsID}")]
    public ActionResult Show(int artistsId, int albumsId)
    {
      Albums album = Albums.Find(albumsId);
      Artists artists = Artists.Find(artistsId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("album", album);
      model.Add("artists", artists);
      return View(model);
    }


  }
}