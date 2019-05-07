using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpdatePosition : MonoBehaviour
{
    public float updateTime = 1.0f;

    private float currentTime = 0.0f;

    private void Update() {
        
        if (currentTime < updateTime) {
            currentTime += Time.deltaTime;
        } else {
            EventManager.TriggerEvent("PlayerPositionUpdated");
            currentTime = 0f;
        }

    }
}
