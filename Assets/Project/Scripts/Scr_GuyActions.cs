using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GuyActions : MonoBehaviour
{
    [SerializeField] Animator animator;          // Animator personaje
    [SerializeField] Animator animatorBang;      // Animator bang de cada personaje (hijo)
    [SerializeField] int minTime = 1;            // Tiempo mínimo disparo enemigo
    [SerializeField] int maxTime = 4;            // Tiempo máximo disparo enemigo
    [SerializeField] int pointsDie = 0;          // Puntos por muerte del personaje (Negativo si resta)
    [SerializeField] int bangPoints;             // Puntos que quita al jugador al dispararlo
    [SerializeField] bool isEnemy;               // Si se trata de un enemigo o un personaje inofensivo
    [SerializeField] float maxTimeToBye = 5f;    // Tiempo máximo que tarda en morir

    float timeToShoot;      // Tiempo que tarda el personaje en disparar en caso de ser enemigo
    bool isHit;             // True si el enemigo ha recibido daño
    bool playerDamaged;     // True si el jugador ha recibido daño
    bool pointsGiven;       // True si el enemigo ha disparado al jugador y le ha quitado puntos

    void Start()
    {
        maxTimeToBye = Random.Range(5, maxTimeToBye);

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
            playerDamaged = true;
            Scr_GameplayManager.GetInstance().points -= bangPoints;
        }            
    }

    IEnumerator KillThisGuy()
    {
        yield return new WaitForSeconds(maxTimeToBye);
        animator.SetTrigger("EndNow");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" && !isHit && !pointsGiven)
        {
            isHit = true;
            pointsGiven = true;

            if (!playerDamaged)
                Scr_GameplayManager.GetInstance().points += pointsDie;

            animator.SetTrigger("EndNow");
        }
    }
}