using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Scr_GameManager : MonoBehaviour
{
    public int highscore1;
    public int highscore2;
    public int highscore3;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void NewHighscore(int points)
    {     
        if (points > highscore1)
        {
            highscore2 = highscore1;
            highscore3 = highscore2;

            highscore1 = points;
        }
            
        else if (points > highscore2)
        {
            highscore3 = highscore2;

            highscore2 = points;
        }

        else if (points > highscore3)
        {
            highscore3 = points;
        }
    }
}