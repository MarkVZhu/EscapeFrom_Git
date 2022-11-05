using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinieJumpSpace : MonoBehaviour
{
    private float OrginalPower;

    private int OrginalJumps;

    //private GameObject player = GameObject.Find("Player");

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            OrginalPower = collision.GetComponent<PlayerController>().jumpPower;
            OrginalJumps = collision.GetComponent<PlayerController>().allowedJumps;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" )
        {
            collision.GetComponent<PlayerController>().jumpPower = 15;
            collision.GetComponent<PlayerController>().allowedJumps = 999 ;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.GetComponent<PlayerController>().jumpPower = OrginalPower;
            collision.GetComponent<PlayerController>().allowedJumps = OrginalJumps;
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
