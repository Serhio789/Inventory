using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class InventoriTests
{
    private Inventori inventory;
    private GameObject[] testSlots;

    [SetUp]
    public void Setup()
    {
        inventory = new GameObject().AddComponent<Inventori>();
        testSlots = new GameObject[3];

        for (int i = 0; i < testSlots.Length; i++)
        {
            testSlots[i] = new GameObject();
        }

        inventory.SetSlots(testSlots);
        inventory.isFull = new bool[testSlots.Length];
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(inventory.gameObject);
        foreach (var slot in testSlots)
        {
            if (slot != null)
                Object.DestroyImmediate(slot);
        }
    }

    [Test]
    public void DestroyObject_MarksSlotAsEmpty()
    {
        inventory.isFull[1] = true;

        inventory.DestroyObject(1);

        Assert.IsFalse(inventory.isFull[1]);
    }

    [Test]
    public void DestroyObject_WithInvalidSlot_DoesNotThrowError()
    {
        inventory.isFull = new bool[] { true };

        Assert.DoesNotThrow(() => inventory.DestroyObject(100));
    }

    [Test]
    public void DestroyObject_WithNegativeIndex_DoesNotThrowError()
    {
        inventory.isFull = new bool[] { true };

        Assert.DoesNotThrow(() => inventory.DestroyObject(-1));
    }
}