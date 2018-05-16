using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GameplayManager : MonoBehaviour
{
    private static Scr_GameplayManager instance;

    private float timeZero;
    public float playingTime = 60f;
    public TextMesh textMesh;

    public float points = 0f;

    private void Start()
    {
        timeZero = Time.realtimeSinceStartup;
        instance = this;
    }

    private void Update()
    {
        if (Time.realtimeSinceStartup > (playingTime + timeZero))
            Application.Quit();
        textMesh.text = "Time: " + (int)(Time.realtimeSinceStartup - timeZero) + "\nScore: " + points;
    }

    public static Scr_GameplayManager GetInstance()
    {
        return instance;
    }
}