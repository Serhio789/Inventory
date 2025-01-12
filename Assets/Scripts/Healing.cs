using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public GameObject player;
    public float healPoint;
    private int id;
    public void SetID(int id) => this.id = id;
    public void SetPlayer(GameObject player) => this.player = player;
    public void HealingPlayer()
    {
        player.GetComponent<PlayerHealth>().Healing(healPoint);
        player.GetComponent<Inventori>().DestroyObject(id);
        Destroy(gameObject);
    }
}
