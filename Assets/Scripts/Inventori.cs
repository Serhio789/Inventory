using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventori : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    public void DestroyObject(int slot)
    {
        for (int i = 0; i < isFull.Length; i++) 
            if (i == slot)
                isFull[i] = false;
    }
    public void SetSlots(GameObject[] slot) => slots = slot;
}
