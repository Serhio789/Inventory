using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LiftingObject : MonoBehaviour
{
    private Inventori inventory;
    public GameObject slotButton;


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {

            if (other.GetComponent<Inventori>() != null)
            {
                if (PhotonView.Get(other).IsMine)
                {
                    inventory = other.GetComponent<Inventori>();
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        if (inventory.isFull[i] == false)
                        {
                            GameObject Clon = Instantiate(slotButton, inventory.slots[i].transform);
                            Clon.GetComponent<ItemForPlayer>().SetID(i);
                            Clon.GetComponent<ItemForPlayer>().SetPlayer(other.gameObject);
                            inventory.isFull[i] = true;
                            break;
                        }
                    }
                }
            }
            PhotonView.Destroy(gameObject);
        }
    }
}
