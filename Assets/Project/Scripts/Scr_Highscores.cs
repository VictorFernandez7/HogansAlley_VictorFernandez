using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scr_Highscores : MonoBehaviour
{
    Scr_GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<Scr_GameManager>();
    }

    void Update()
    {
        if (gameObject.name == "Highscore1")
            GetComponent<TextMeshPro>().text = "1st     " + gameManager.highscore1;
        if (gameObject.name == "Highscore2")
            GetComponent<TextMeshPro>().text = "2nd    " + gameManager.highscore2;
        if (gameObject.name == "Highscore3")
            GetComponent<TextMeshPro>().text = "3rd     " + gameManager.highscore3;
    }
}