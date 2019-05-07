using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustFollow : MonoBehaviour
{
    public Transform mTarget;
    public Transform m2Target;

    float movementSpeed = 5.0f;
    Vector3 mLookDirection;

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
            mLookDirection = (m2Target.position - transform.position).normalized;

            if ((transform.position - m2Target.position).magnitude > EPSILON)
            {
                transform.Translate(mLookDirection * movementSpeed * Time.deltaTime);
            }
        }
        else if ((transform.position - m2Target.position).magnitude > (transform.position - mTarget.position).magnitude)
        {
            mLookDirection = (mTarget.position - transform.position).normalized;

            if ((transform.position - mTarget.position).magnitude > EPSILON)
            {
                transform.Translate(mLookDirection * movementSpeed * Time.deltaTime);
            }
        }
        else  if ((transform.position - m2Target.position).magnitude == (transform.position - mTarget.position).magnitude)
        {
            mLookDirection = (mTarget.position - transform.position).normalized;

            if ((transform.position - mTarget.position).magnitude > EPSILON)
            {
                transform.Translate(mLookDirection * movementSpeed * Time.deltaTime);
            }
        }
    }
}
