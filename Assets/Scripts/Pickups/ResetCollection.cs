using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCollection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("CollectionsCount").GetComponent<CollectionsCount>().reset();
    }
}
