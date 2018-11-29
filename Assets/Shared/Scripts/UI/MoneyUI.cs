using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour {
    private TextMeshPro moneyText;

	void Start () {
        moneyText = GetComponent<TextMeshPro>();
	}
	
	void Update () {
        moneyText.text = "Money: $" + PlayerStats.Money.ToString();
	}
}
