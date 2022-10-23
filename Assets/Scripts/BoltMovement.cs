using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMovement : MonoBehaviour
{
    private float speed = 20f;

    private Vector3 verticalMovement;


    public void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        verticalMovement = transform.forward * speed * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(transform.position + verticalMovement);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
