using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour {
    private TextMeshPro livesText;

    private void Start()
    {
        livesText = GetComponent<TextMeshPro>();
    }

    void Update () {
        livesText.text = "Lives: " + PlayerState.Lives.ToString();
    }
}
