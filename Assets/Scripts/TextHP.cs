using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHP : MonoBehaviour
{
    private GameObject player;
    private Text textHP;
    private void Start()
    {
        textHP = GetComponent<Text>();
    }
    private void Update() { 
        if (player != null) 
        textHP.text = player.GetComponent<PlayerHealth>().CurrentHealth().ToString(); 
    }
    public void SetPlayer(GameObject player) => this.player = player;
}
