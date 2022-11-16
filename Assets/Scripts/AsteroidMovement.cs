using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Vector3 spin;
    private float speed = 1f;
    private Vector3 verticalMovement;
    private Vector3 targetPos;



    void Start()
    {
        spin = new Vector3(0, Random.Range(1, 5), Random.Range(1, 5));
        targetPos = new Vector3(transform.position.x, 0, -8);
    }

    void Update()
    {
        Move();
        GetComponent<Rigidbody>().angularVelocity = spin;

    }


    void Move()
    { 

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }


}
