using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_BulletHandler : MonoBehaviour
{
    private ParticleSystem hitPs;
    private Rigidbody rb;
    private AudioSource bulletAs;
    public AudioClip shootSound;
    public AudioClip hitSound;
    public float impulseMagnitude = 10f;

    private void Start()
    {
        hitPs = GetComponent<ParticleSystem>();

        if (hitPs == null)
            Debug.Log("No se encuentra el ParticleSystem del bullet");

        rb = GetComponent<Rigidbody>();

        if (rb == null)
            Debug.Log("No se encuentra el Rigidbody del bullet");

        bulletAs = GetComponent<AudioSource>();

        if (bulletAs == null)
            Debug.Log("No se encuentra el AudioSource del bullet");
    }

    public void Shoot(Vector3 direction)
    {
        Start();

        bulletAs.PlayOneShot(shootSound);
        rb.AddForce(direction.normalized * impulseMagnitude, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitPs.Play();
        bulletAs.PlayOneShot(hitSound);
    }
}