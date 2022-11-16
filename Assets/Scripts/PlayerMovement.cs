using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float xSpeed = 10f;
    private float ySpeed = 10f;

    private Vector3 verticalMovement;
    private Vector3 horizontalMovement;
    private Vector3 lastPosition;

    private float xMin = -5f, xMax = 5f, yMin = -8f, yMax = 0f;
    private float zRotation;
    private float xVelocity;

    public bool IsFire;

    public Rigidbody Shot;

    private float nextShot = 0.0f;
    private float fireRate = 1.0f;

    void Start()
    {
        lastPosition = transform.position;
    }

    public void FixedUpdate()
    {
        Move();   
        lastPosition = transform.position;
    }

    void Update()
    {
        Fire();
    }

    void OnFire(InputValue value)
    {
        IsFire = true;
    }

    void Move()
    {
        verticalMovement = transform.forward * Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;
        horizontalMovement = transform.right * Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;

        Vector3 Position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), 0f, Mathf.Clamp(transform.position.z, yMin, yMax));
        
        xVelocity = (Position.x - lastPosition.x) / Time.deltaTime;
        zRotation = xVelocity * -5;


        transform.localRotation = Quaternion.Euler(0f, 0f, zRotation);
        GetComponent<Rigidbody>().MovePosition(Position + verticalMovement + horizontalMovement);
    }

    void Fire()
    {
        if (IsFire)
        {
            if (Time.time > nextShot)
            {
                nextShot = Time.time + fireRate;
                Instantiate(Shot, transform.Find("Gun").gameObject.transform.position, transform.rotation);
            }
        }
        IsFire = false;
    }
}
