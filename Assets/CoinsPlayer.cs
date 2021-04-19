using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinsPlayer : MonoBehaviour
{

    static public int money;

    [SerializeField]
    public Text TextMoney;

    void Start()
    {
        money = 0;
    }
}
