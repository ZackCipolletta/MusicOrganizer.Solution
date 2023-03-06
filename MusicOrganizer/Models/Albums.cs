using System.Collections.Generic;
using MySqlConnector;

namespace MusicOrganizer.Models
{
  public class Albums
  {
    public string AlbumName { get; set; }
    public int Id { get; set; }

    public Albums(string albumName, int id)
    {
      AlbumName = albumName;
      Id = id;
    }

      public override bool Equals(System.Object otherAlbum)
  {
    if (!(otherAlbum is Albums))
    {
      return false;
    }
    else
    {
      Albums newItem = (Albums) otherAlbum;
      bool idEquality = (this.Id == newItem.Id);
      bool albumEquality = (this.AlbumName == newItem.AlbumName);
      return (idEquality && albumEquality);
    }
  }

    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }

    public static List<Albums> GetAll()
    {
      {
        List<Albums> allItems = new List<Albums> { };

        MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
        conn.Open();

        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = "SELECT * FROM albums;";

        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while (rdr.Read())
        {
          int albumId = rdr.GetInt32(0);
          string albumName = rdr.GetString(1);
          Albums newAlbum = new Albums(albumName, albumId);
          allItems.Add(newAlbum);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allItems;
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM albums;";
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Albums Find(int id)
{
  // We open a connection.
  MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
  conn.Open();

  // We create MySqlCommand object and add a query to its CommandText property. 
  // We always need to do this to make a SQL query.
  MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
  cmd.CommandText = "SELECT * FROM albums WHERE id = @ThisId;";

  // We have to use parameter placeholders @ThisId and a `MySqlParameter` object to prevent SQL injection attacks. 
  // This is only necessary when we are passing parameters into a query. 
  // We also did this with our Save() method.
  MySqlParameter param = new MySqlParameter();
  param.ParameterName = "@ThisId";
  param.Value = id;
  cmd.Parameters.Add(param);

  // We use the ExecuteReader() method because our query will be returning results and we need this method to read these results. 
  // This is in contrast to the ExecuteNonQuery() method, which 
  // we use for SQL commands that don't return results like our Save() method.
  MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
  int albumId = 0;
  string albumName = "";
  while (rdr.Read())
  {
    albumId = rdr.GetInt32(0);
    albumName = rdr.GetString(1);
  }
  Albums foundAlbum = new Albums(albumName, albumId);

  // We close the connection.
  conn.Close();
  if (conn != null)
  {
    conn.Dispose();
  }
  return foundAlbum;
}

    public void Save()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO albums (albumName) Values (@albumName);";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@albumName";
      param.Value = this.AlbumName;
      cmd.Parameters.Add(param);
      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
