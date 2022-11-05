using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsCount : MonoBehaviour
{
    private  int collection = 6;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this);
    }

    public int getCollection()
    {
        return collection;
    }
    public void  reset()
    {
        this.collection  = 6;
    }


    public void minusCollection()
    {
        collection--;
    }
   /* private void Update()
    {
       Debug.Log("current: " + this.collection);
    }*/
}
