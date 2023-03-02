using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Albums
  {
    public string AlbumName { get; set; }
    public int Id { get; }
    private static List<Albums> _instances = new List<Albums> { };

    public Albums(string albumName)
    {
      AlbumName = albumName;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Albums> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Albums Find(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}
