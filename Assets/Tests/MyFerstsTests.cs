using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.SceneManagement;

[TestFixture]
public class MyFerstsTests
{
    [Test]
    public void SetID_CorrectlyAssignsId()
    {
        // Arrange
        var item = new GameObject().AddComponent<MockItem>();

        // Act
        item.SetID(123);

        // Assert
        Assert.AreEqual(123, item.idItem);
    }

    [Test]
    public void SetPlayer_CorrectlyAssignsPlayerReference()
    {
        // Arrange
        var item = new GameObject().AddComponent<MockItem>();
        var player = new GameObject();

        // Act
        item.SetPlayer(player);

        // Assert
        Assert.AreEqual(player, item.playerObject);
    }

    // Mock класс для тестирования абстрактного ItemForPlayer
    private class MockItem : ItemForPlayer
    {
        public override void Using() { }
    }
}
