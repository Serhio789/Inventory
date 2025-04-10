using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class MyFerstsTests
{
    [Test]
    public void SetID_CorrectlyAssignsId()
    {
        var item = new GameObject().AddComponent<MockItem>();

        item.SetID(123);

        Assert.AreEqual(123, item.idItem);
    }

    [Test]
    public void SetPlayer_CorrectlyAssignsPlayerReference()
    {
        var item = new GameObject().AddComponent<MockItem>();
        var player = new GameObject();

        item.SetPlayer(player);

        Assert.AreEqual(player, item.playerObject);
    }

    private class MockItem : ItemForPlayer
    {
        public override void Using() { }
    }
}
