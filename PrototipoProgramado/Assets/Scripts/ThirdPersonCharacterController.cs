using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float speed = 6;
    //Animator anim;

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    void playerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 12;
        }
        else
        {
            speed = 6;
        }

        //anim.SetFloat("velocity", speed);
        Vector3 movement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }
}
