using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFactory : MonoBehaviour
{
    public GameObject enemy;
    float next_spawn_time;

    /*void OnTriggerEnter(Collider other) {
        next_spawn_time += Time.time + 15.0f;
        Instantiate(enemy);
    }*/
    
    //Start is called before the first frame update
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
            Instantiate(enemy);

            //increment next_spawn_time
            next_spawn_time += 15.0f;
        }
    }
}
