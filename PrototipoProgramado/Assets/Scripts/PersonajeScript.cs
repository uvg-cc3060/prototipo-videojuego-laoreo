using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeScript : MonoBehaviour
{
    // Singleton
    public static PersonajeScript instance;

    private void Awake()
    {
        if (instance == null) instance = this;

    }
}
