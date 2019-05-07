using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FearMeter : MonoBehaviour
{
    public int initialFear = 0;
    public bool regen = false, controlAudio = false, inSight = false;
    public float fearGain = 0.06f;
    public float currentFear=0;
    public float currentTime;
    public Image fearMeterImg;
    public static FearMeter instance;
    
    AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        fearMeterImg.fillAmount = 0;
        currentTime = 0;
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (regen && !inSight)
        {
            Audio.Stop();
            controlAudio = false;
            currentFear -= fearGain * Time.deltaTime;
            fearMeterImg.fillAmount -= Time.deltaTime * fearGain;

            if(currentFear <= 0)
            {                
                regen = false;                
            } else if (currentFear > 0)
            {
                regen = true;
            }
        }
    }

    public void gainFear()
    {
        //Mientras no este comenzando y el jugador este vivo
        if(currentFear <= 1)
        {
            currentFear += Time.deltaTime*fearGain;
            fearMeterImg.fillAmount = currentFear;

            //cuando controlAudio es true se reproduce el sonido y se para
            if (!controlAudio)
            {
                Audio.Play();
                controlAudio = true;
            }
        }
        else
        {
            GameController.instance.gameOver = true;
        }

    }

}
