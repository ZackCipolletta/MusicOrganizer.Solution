using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artists
  {
    private static List<Artists> _instances = new List<Artists> { };
    public string ArtistName { get; set; }
    public int Id { get; }
    public List<Albums> Albums { get; set; }

    public Artists(string artistName)
    {
      ArtistName = artistName;
      _instances.Add(this);
      Id = _instances.Count;
      Albums = new List<Albums> { };
    }

    public static List<Artists> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Artists Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public void AddAlbum(Albums album)
    {
      Albums.Add(album);
    }

    // public static void Search(string artistName)
    // {
    //   foreach (Artists artists in _instances)
    //   {
    //     if (artists.ArtistName.Equals(artistName))
    //     {
    //       Find(artists.Id);
    //     }
    //   }
    // }
  }
}
