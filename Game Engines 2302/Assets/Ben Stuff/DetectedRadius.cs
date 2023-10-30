using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedRadius : MonoBehaviour
{
    public GameObject otherGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(this.transform.position.x);
       
        if (otherGameObject.transform.position.x >= (this.transform.position.x - 2) & otherGameObject.transform.position.z >= (this.transform.position.z - 2))
        {
            Debug.Log("pog");
        }
       
    }
}
