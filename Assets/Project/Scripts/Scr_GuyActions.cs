using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GuyActions : MonoBehaviour
{
    Animator animator;
    Animator animatorBang;

    public int minTime = 1;
    public int maxTime = 4;

    public int pointsDie = 0;

    private float timeToShoot;
    public float timeToBye = 5f;

    public bool isEnemy;
    private bool isHit;

    bool pointsGiven;

    void Start()
    {
        animator = GetComponent<Animator>();
        animatorBang = GetComponentInChildren<Animator>();

        timeToBye = Random.Range(3, timeToBye);

        if (animator == null)
            Debug.Log("Animator missing");
        if (animatorBang == null)
            Debug.Log("AnimatorBang missing");
        StartCoroutine(KillThisGuy());

        if (isEnemy)
        {
            timeToShoot = Random.Range(minTime, maxTime);
            Invoke("BANG", timeToShoot);
        }
    }

    void BANG()
    {
        if (!isHit)
        {
            animatorBang.SetBool("Bang", true);
            Debug.Log("BANG");
        }            
    }

    IEnumerator KillThisGuy()
    {
        yield return new WaitForSeconds(timeToBye);
        animator.SetTrigger("EndNow");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" && !isHit && !pointsGiven)
        {
            isHit = true;
            Scr_GameplayManager.GetInstance().points += pointsDie;
            animator.SetTrigger("EndNow");
            pointsGiven = true;
        }
    }
}