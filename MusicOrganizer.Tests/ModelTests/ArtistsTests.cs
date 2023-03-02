using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class ArtistsTests : IDisposable
  {
    public void Dispose()
    {
      Artists.ClearAll();
    }

    [TestMethod]
    public void ArtistsConstructor_CreatesArtistsObject_Artists()
    {
      Artists newArtist = new Artists("Mike");
      Assert.AreEqual(typeof(Artists), newArtist.GetType());
    }

    [TestMethod]
    public void GetArtistName_ReturnsArtistName_String()
    {
      // Arrange
      string name = "WeinerMan";
      Artists newArtist = new Artists(name);

      // Act
      string result = newArtist.ArtistName;

      // Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllArtistsObjects_ArtistsList()
    {
      //Arrange
      string artistName01 = "StrongMan";
      string artistName02 = "Metallica";
      Artists newArtist1 = new Artists(artistName01);
      Artists newArtist2 = new Artists(artistName02);
      List<Artists> newList = new List<Artists> { newArtist1, newArtist2 };

      // Act
      List<Artists> result = Artists.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void AddArtist_AssosiatesArtistWtihAlbum_ArtistList()
    {
      string albumName = "StrongMan";
      Albums newAlbum = new Albums(albumName);
      List<Albums> newArtistList = new List<Albums> { newAlbum };
      string artistName = "socks";
      Artists newArtist = new Artists(artistName);
      newArtist.AddAlbum(newAlbum);

      List<Albums> result = newArtist.Albums;

      CollectionAssert.AreEqual(newArtistList, result);

    }

  }
}