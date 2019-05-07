using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{

    private void Start()
    {
        EventManager.StartListening("GameOver", GameOver);
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
