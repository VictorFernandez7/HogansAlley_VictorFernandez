using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Scr_GameplayManager : MonoBehaviour
{
    [SerializeField] TextMeshPro textMesh;
    [SerializeField] float time = 60;

    [HideInInspector]
    public int points = 0;

    private static Scr_GameplayManager instance;

    Scr_GameManager gameManager;

    private void Start()
    {
        instance = this;

        gameManager = GameObject.Find("Game Manager").GetComponent<Scr_GameManager>();
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            gameManager.NewHighscore(points);

            SceneManager.LoadScene(0);
        }

        textMesh.text = "Time " + (int) time + "           " + "Points " + points;
    }

    public static Scr_GameplayManager GetInstance()
    {
        return instance;
    }
} 