using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderGenerator : MonoBehaviour
{
    public GameObject thunder;
    float next_spawn_time;

    // Start is called before the first frame update
    void Start()
    {
        next_spawn_time += Time.time + 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_spawn_time)
        {
            //do stuff here (like instantiate)
            //pero aparte de instantiate podes poner lo que querras en realidad....
            Instantiate(thunder);
            

            //increment next_spawn_time
            next_spawn_time += 15.0f;
        }
    }
}
