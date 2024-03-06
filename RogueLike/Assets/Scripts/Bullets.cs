using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public GameObject prefBullet;
    public float fireRate = 0.5f;                // Tiempo entre instancias

    private float nextFireTime = 0f;

    void Update()
    {
         // Si el bot�n del mouse est� presionado y ha pasado el tiempo de espera
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            InstantiateBullet();
            nextFireTime = Time.time + fireRate;            // Establecer el pr�ximo tiempo de instanciaci�n
        }
    }

    // Instancia una bala
    void InstantiateBullet()
    {
        if (prefBullet != null)
        {
            Instantiate(prefBullet, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab not assigned!");
        }
    }
}
