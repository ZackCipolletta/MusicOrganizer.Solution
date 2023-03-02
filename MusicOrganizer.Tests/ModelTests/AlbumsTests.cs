using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class AlbumsTests : IDisposable
  {

    public void Dispose()
    {
      Albums.ClearAll();
    }

    [TestMethod]
    public void AlbumsConstructor_CreatesInstanceOfAlbums_Albums()
    {
      Albums newAlbum = new Albums("testAlbum");
      Assert.AreEqual(typeof(Albums), newAlbum.GetType());
    }

    [TestMethod]
    public void GetAlbumName_ReturnsAlbumsName_String()
    {
      // Arrange
      string albumName = "Dark Side of the Moon";
      Albums newAlbum = new Albums(albumName);

      // Act
      string updatedAlbumName = "The Wall";
      newAlbum.AlbumName = updatedAlbumName;
      string result = newAlbum.AlbumName;

      // Assert
      Assert.AreEqual(updatedAlbumName, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_AlbumList()
    {
      // Arrange
      List<Albums> newList = new List<Albums> { };

      // Act
      List<Albums> result = Albums.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_Returnsalbums_AlbumList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Albums newItem1 = new Albums(description01);
      Albums newItem2 = new Albums(description02);
      List<Albums> newList = new List<Albums> { newItem1, newItem2 };

      //Act
      List<Albums> result = Albums.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_ItemsInstatiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string description = "Walk the dog.";
      Albums newItem = new Albums(description);

      //Act
      int result = newItem.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Item()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Albums newAlbum1 = new Albums(description01);
      Albums newAlbum2 = new Albums(description02);

      // Act
      Albums result = Albums.Find(2);

      // Assert
      Assert.AreEqual(newAlbum2, result);
    }

          [TestMethod]
  public void Find_ReturnsCorrectCategory_Category()
  {
    //Arrange
    string name01 = "Work";
    string name02 = "School";
    Artists newArtists1 = new Artists(name01);
    Artists newArtists2 = new Artists(name02);

    //Act
    Artists result = Artists.Find(2);

    //Assert
    Assert.AreEqual(newArtists2, result);
  }


  }
}