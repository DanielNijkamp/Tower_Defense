using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public float killDelay = 3f;
    void Start()
    {
        Debug.Log("hit");
        Destroy(this, killDelay);
        
    }
    
}
