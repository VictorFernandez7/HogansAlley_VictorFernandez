using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GuyActions : MonoBehaviour
{
    Animator animator;

    private int pointsShoot = -100;
    public int pointsDie = 0;

    private float timeToShoot;
    public float timeToBye = 7f;

    public bool isEnemy = false;
    private bool isHit = false;
    private bool hasShot = false;

    //public Transform bang;

    void Start()
    {
        animator = GetComponent<Animator>();

        timeToBye = Random.Range(3, timeToBye);
        timeToShoot = timeToBye - 1.5f;

        if (animator == null)
            Debug.Log("Animator missing");
        StartCoroutine(KillThisGuy());
        if (isEnemy)
            StartCoroutine(ShootMe());

        //bang = transform.GetChild(0);

    }

    IEnumerator ShootMe()
    {
        yield return new WaitForSeconds(timeToShoot);
        if (!isHit)
        {
            Scr_GameplayManager.GetInstance().points += pointsShoot;
            //bang.gameObject.SetActive(true);
            hasShot = true;
        }
    }

    IEnumerator KillThisGuy()
    {
        yield return new WaitForSeconds(timeToBye);
        animator.SetTrigger("EndNow");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "tag_bullet" && !isHit)
        {
            isHit = true;
            Scr_GameplayManager.GetInstance().points += pointsDie;
            animator.SetTrigger("EndNow");
        }
    }
}