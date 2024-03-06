using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocidad = 5f;  // Velocidad del proyectil
    public Transform objetivo;  // Objetivo al que se dirige el proyectil


    private void Start()
    {
        BuscarEnemigos();
    }

    public void BuscarEnemigos()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemigos.Length > 0)
        {
            Transform enemigoMasCercano = EncontrarEnemigoMasCercano(enemigos);
            EstablecerObjetivo(enemigoMasCercano);
        }
        else
        {
            objetivo= null;
        }
    }

    private Transform EncontrarEnemigoMasCercano(GameObject[] enemigos)
    {
        Transform EnemigoMasCercano = null;
        float DistanciaMasCercana = Mathf.Infinity;
        Vector3 posicionActual = transform.position;

        foreach(GameObject enemigo in enemigos)
        {
            float distancia = Vector3.Distance(posicionActual, enemigo.transform.position);
            if(distancia < DistanciaMasCercana)
            {
                DistanciaMasCercana = distancia;
                EnemigoMasCercano = enemigo.transform;

            }
        }

        return EnemigoMasCercano;
    }


    public void EstablecerObjetivo(Transform nuevoObjetivo)
    {
        objetivo = nuevoObjetivo;
    }

    void Update()
    {
        if (objetivo != null)
        {
            BuscarEnemigos();
            Vector2 direccion = (objetivo.position - transform.position).normalized;

            transform.Translate(direccion * velocidad * Time.deltaTime);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}