using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
