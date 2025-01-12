using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHP : MonoBehaviour
{
    public GameObject player;
    private Text textHP;
    private void Start()
    {
        textHP = GetComponent<Text>();
    }
    private void Update() => textHP.text = player.GetComponent<PlayerHealth>().CurrentHealth().ToString();
}
