using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public bool canRotate = false;

    [Tooltip("How long to wait when gravity change")]
    public float waitTime = 2f;

    public bool flip = true; 

    // The time at which change is resumed
    private float timeToChange = 0f;

    private bool resetTime;

    private float OrginalGravity;

    //private GameObject player = GameObject.Find("Player");

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
            OrginalGravity = collision.GetComponent<Rigidbody2D>().gravityScale;
        resetTime = true;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("in area");
        if (resetTime)
        {
            timeToChange = Time.time + waitTime;
            resetTime = false;
        }

        if (collision.transform.tag == "Player" && Time.time > timeToChange)
        {
            collision.GetComponent<Rigidbody2D>().gravityScale *= -1;
            collision.transform.RotateAround(collision.transform.position, Vector3.right, 180);
            resetTime = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" && collision.GetComponent<Rigidbody2D>().gravityScale != OrginalGravity && flip)
        {
           // GameObject.Find("Main Camera").transform.RotateAround(collision.transform.position, Vector3.forward, 180);
            collision.transform.RotateAround(collision.transform.position, Vector3.up, 180);
            collision.GetComponent<PlayerController>().movementSpeed = 0;
            canRotate = true;
        }
    }

    /* public void OnTriggerEnter2D(Collider2D collision)
     {

         if (collision.transform.tag == "Player")
         {
             collision.GetComponent<Rigidbody2D>().gravityScale *= -1;
             collision.transform.RotateAround(collision.transform.position, Vector3.right, 180);
         }
     }*/
}
