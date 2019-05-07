using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookNFollow : MonoBehaviour
{

    public Transform mTarget;
    public Transform m2Target;

    float movementSpeed = 5.0f;

    const float EPSILON = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - mTarget.position).magnitude > (transform.position - m2Target.position).magnitude)
        {
            transform.LookAt(m2Target.position);

            if ((transform.position - m2Target.position).magnitude > EPSILON)
            {
                transform.Translate(0.0f, 0.0f, movementSpeed * Time.deltaTime);
            }
        }
        else if ((transform.position - m2Target.position).magnitude > (transform.position - mTarget.position).magnitude)
        {
            transform.LookAt(mTarget.position);

            if ((transform.position - mTarget.position).magnitude > EPSILON)
            {
                transform.Translate(0.0f, 0.0f, movementSpeed * Time.deltaTime);
            }
        }
    }
}
