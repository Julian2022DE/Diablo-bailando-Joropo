using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_PJ : MonoBehaviour
{
    public float speed;
    public Animator animator;


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0f) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (horizontal != 0f || vertical != 0f)
        {
           // animator.SetBool("Run", true);
           // animator.SetBool("Idle", false);
            // Debug.Log("animation");
        }
        else
        {
           // animator.SetBool("Run", false);
           // animator.SetBool("Idle", true);
        }
    }
}