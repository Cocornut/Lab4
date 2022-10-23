using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Vector3 spin;
    private float speed = 5f;
    private Vector3 verticalMovement;

    void Start()
    {
        spin = new Vector3(0, Random.Range(1, 5), Random.Range(1, 5));
    }

    void Update()
    {
        Move();
        GetComponent<Rigidbody>().angularVelocity = spin;

    }


    void Move()
    {
        verticalMovement = transform.forward * speed * Time.deltaTime * -1;
        GetComponent<Rigidbody>().MovePosition(transform.position + verticalMovement);
    }


}
