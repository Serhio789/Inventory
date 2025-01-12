using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LiftingObject : MonoBehaviour
{
    private Inventori inventory;
    public GameObject slotButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventori>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    Destroy(gameObject);
                    GameObject Clon = Instantiate(slotButton, inventory.slots[i].transform);
                    Clon.GetComponent<Healing>().SetPlayer(other.GameObject());
                    Clon.GetComponent<Healing>().SetID(i);
                    inventory.isFull[i] = true;
                    break;
                }
            }
        }
    }
}
