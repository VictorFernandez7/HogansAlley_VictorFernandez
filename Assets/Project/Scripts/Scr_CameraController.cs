﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

public class Scr_CameraController : MonoBehaviour
{
    public float camSens = 0.50f; // Sensibilidad con el uso de ratón
    Vector3 lastMouse = new Vector3(255, 255, 255);
    [SerializeField] GameObject bullet;

    public float FireRate;
    float fireRate;
    bool canShoot = true;

    public float distance;
    bool key;
    bool keyStop;

    private void Awake()
    {
        fireRate = FireRate;
    }

    private void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if (hit.collider.tag == "Menu")
            {
                key = true;

                hit.transform.gameObject.GetComponent<Animator>().SetBool("Target", true);
            }

            else if (keyStop == false)
            {
                key = false;
            }                
        }

        else if ((key == true) && (keyStop == false))
        {
            hit.transform.gameObject.GetComponent<Animator>().SetBool("Target", false);

            key = false;
        }

        if (!UnityEngine.XR.XRSettings.enabled)
            CameraPosition();

        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            ShootABullet();
            FireRate = fireRate;
            canShoot = false;
        }
            
        if (!canShoot)
        {
            FireRate -= Time.deltaTime;

            if (FireRate <= 0)
                canShoot = true;
        }
    }

    void CameraPosition()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
    }

    void ShootABullet()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);
            Scr_BulletHandler bh = bulletInstance.GetComponent<Scr_BulletHandler>();

            if (bh != null)
                bh.Shoot(transform.forward);
            else
                Debug.Log("La bullet no tiene adjunto el script bulletHandler");
        }
    }
}