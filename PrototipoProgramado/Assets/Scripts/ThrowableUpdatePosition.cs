using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableUpdatePosition : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            EventManager.TriggerEventTransform("ThrowablePositionUpdated", transform);
        }
    }

    
}
