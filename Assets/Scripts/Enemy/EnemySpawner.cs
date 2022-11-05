using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject mover = null;

    [Tooltip("The Prefab to be spawned into the scene.")]
    public int forward = 1;

    private float moveSpeed = 0.95f;

    public void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.name+"111");
        if (collision)
        {
            switch (forward)
            {
                case 1: mover.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);  break;
                case 2: mover.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime); break;
                case 3: mover.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); break;
                case 4: mover.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); break;
                default: break;
            }
        }
    }
}
