using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;



public class Enemymen : MonoBehaviour
{
    int health = 100;
    Material col;
    Rigidbody rb;
    void Start()
    {
        MeshRenderer mashhh = GetComponent<MeshRenderer>();
        col = mashhh.material;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider collision)
    {
        col.color = Color.green;
        if (collision.gameObject.tag == "Bullet")
        {
            rb.AddForce(transform.forward);
            health -= 10;
        }
        if (health <= 75)
        {
            print("green");
            col.color = new Color(1f, 0f, 0f);
        }
        if(health <= 50)
        {
            print("yellow");
            col.color = Color.red;
        }
        if(health <= 25)
        {
            print("orange");
            col.color = Color.black;
        }
        if(health <= 0)
        {
            print("Destroy");
            Destroy(gameObject);
        }
        
    }

}
