using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad;
    public Transform jugador;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        jugador = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
     
          Vector2 direccion = transform.position - jugador.position;

            // Mueve al enemigo hacia el jugador de manera suave
         transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
