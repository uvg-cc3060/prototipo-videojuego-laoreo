using UnityEngine;
using System.Collections;

public class Throwing : MonoBehaviour {

    float time;
    private bool touch = false;
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            time = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!GetComponent<Rigidbody>().useGravity)
            {
                Vector3 myVector = transform.parent.transform.forward;
                transform.SetParent(null);
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;
                float finalTime = Time.time;
                float force;
                

                if ((finalTime - time) < 1)
                {
                    force = 100f;
                }
                else if ((finalTime - time) < 2)
                {
                    force = 150f;
                }
                else
                {
                    force = 250f;
                }
                gameObject.tag = "Weapon";
                GetComponent<Rigidbody>().AddForce(myVector * force);
            }
        }
    }
    
    

    private void OnCollisionEnter(Collision collision)
    {
        try
        {
            if (collision.rigidbody.name == "player")
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.isKinematic = true;
                transform.parent = collision.transform;
                transform.parent = transform.parent.GetChild(0);
                transform.localPosition = new Vector3(0.2f, 0.1f, 1);
            }
            if (collision.rigidbody.tag == "Ground")
            {
                gameObject.tag = "Throwable";
            }
        }
        catch {
        }
        
    }

}
