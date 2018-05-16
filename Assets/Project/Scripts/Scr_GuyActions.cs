using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GuyActions : MonoBehaviour
{
    Animator animator;

    public float minTime = 4f;
    public float maxTime = 8f;

    public int pointsBye = 0;
    public int pointsDie = 0;

    private void Start()
    {
        animator.GetComponent<Animator>();

        if (animator == null)
            Debug.Log("No esxiste animator");
    }

    IEnumerator KillThisGuy()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        Scr_GameplayManager.GetInstance().points += pointsBye;
        animator.SetTrigger("EndNow");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Scr_GameplayManager.GetInstance().points += pointsDie;
            animator.SetTrigger("EndNow");
        }
    }
}