using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {
    private Text livesText;

    private void Start()
    {
        livesText = GetComponent<Text>();
    }

    void Update () {
        livesText.text = "Lives: " + PlayerStats.Lives.ToString();
    }
}
