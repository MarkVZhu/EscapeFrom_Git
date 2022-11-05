using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class to make projectiles move
/// </summary>
public class Projectile : MonoBehaviour
{
    
    [Tooltip("The distance this projectile will move each second in meters.")]
    public float projectileSpeed = 3.0f;

    [Tooltip("How far away from the main camera before destroying the projectile gameobject in meters.")]
    public float destroyDistance = 20.0f;

    public float orginPositionY = 0f;

    private void Start()
    {
        orginPositionY = this.transform.position.y;
    }

    /// <summary>
    /// Description:
    /// Standard Unity function called once per frame
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void Update()
    {
        MoveProjectile();
    }

    /// <summary>
    /// Description:
    /// Move the projectile in the direction it is heading
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void MoveProjectile()
    {
        // move the transform
        transform.position = transform.position - transform.up * projectileSpeed * Time.deltaTime;

        // calculate the distance from the main camera
        float dist = orginPositionY - transform.position.y;
        //Debug.Log("dist " + dist);
        // if the distance is greater than the destroyDistance
        if (dist>destroyDistance)
        {
            Destroy(this.gameObject); // destroy the gameObject
        }
    }
}