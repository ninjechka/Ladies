using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public int Cost;

    void OnTriggerEnter2D(Collider2D col) { 
        CoinsPlayer.money += Cost; 
        GameObject.FindGameObjectWithTag ("Player").GetComponent<CoinsPlayer> ().TextMoney.text = CoinsPlayer.money.ToString(); 
        Destroy (gameObject); 
    }
}
