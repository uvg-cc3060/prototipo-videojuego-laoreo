using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public FearMeter fearMeter;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider collider)
    {
        //Si el jugador entra el en area del monstruo
        if (collider.gameObject.tag.Equals("monster"))
        {
            FearMeter.instance.gainFear();
            fearMeter.inSight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        fearMeter.regen = true;
        fearMeter.inSight = false;
    }

}