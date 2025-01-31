using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : ItemForPlayer
{
    public float healPoint;
    public void HealingPlayer()
    {
        playerObject.GetComponent<PlayerHealth>().Healing(healPoint);
        playerObject.GetComponent<Inventori>().DestroyObject(idItem);
        PhotonView.Destroy(gameObject);
    }

    public override void Using()
    {
        HealingPlayer();
    }
}
