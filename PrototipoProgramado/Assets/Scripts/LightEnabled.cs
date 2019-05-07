using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnabled : MonoBehaviour
{
    private Light light;
    public float interval = 1f;

    // Update is called once per frame
    void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        while (true)
        {
            Debug.Log("Hola");
            light.enabled = !light.enabled;
            yield return new WaitForSeconds(interval);
        }
    }
}
