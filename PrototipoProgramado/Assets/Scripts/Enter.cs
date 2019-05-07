using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enter : MonoBehaviour
{
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        monster.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        monster.SetActive(true);
    }
}
