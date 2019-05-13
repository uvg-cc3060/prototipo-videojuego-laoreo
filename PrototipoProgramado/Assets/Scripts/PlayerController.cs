using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Component camara;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        Vector3 vector = new Vector3(0, camara.transform.eulerAngles.y, 0);

        if (Input.GetKey(KeyCode.W))
            rb.AddForce(camara.transform.forward * speed);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(-camara.transform.forward * speed);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(camara.transform.right * speed);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-camara.transform.right * speed);
        
        rb.AddForce(0,1 * speed, 0);
    }
}
