using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemForPlayer : MonoBehaviour
{
    public GameObject playerObject;
    public int idItem;
    public abstract void Using();
    public void SetID(int id) => idItem = id;
    public void SetPlayer(GameObject playerObject) => this.playerObject = playerObject;
}
