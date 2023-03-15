using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 15.0f;
    private float turnSpeed = 15.0f;
    private float horizontalInput;
    private float forwardInput;
    public GameObject player;
    public float xRange = 22.0f;
    public float zRange = 22.0f;
    public float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);
        transform.Translate(Vector3.right * turnSpeed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 20.0f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 15.0f;
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }    

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        } 
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }    

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
    if(other.gameObject.CompareTag("Heal"))
    {
        Destroy(other.gameObject);
        health = health + 25;
    }
    
    if(other.gameObject.CompareTag("Enemy"))
    {
        health = health -= 5;
        transform.position = new Vector3(0, transform.position.y, 0);
    }
    if(health == 0)
    {
        Destroy(gameObject);
    }
    }
}
