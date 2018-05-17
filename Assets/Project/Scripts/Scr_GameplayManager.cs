using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scr_GameplayManager : MonoBehaviour
{
    private static Scr_GameplayManager instance;

    private float timeZero;
    public float playingTime = 60f;
    public TextMeshPro textMesh;

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
        textMesh.text = "Time " + (int)(playingTime - (Time.realtimeSinceStartup - timeZero)) + "\nScore " + points;
    }

    public static Scr_GameplayManager GetInstance()
    {
        return instance;
    }
}