using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] Balls;
    public float time = 20.0f;
    public int range = 10;

    // Start is called before the first frame update
    void Start()
    {
        generateBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateBall()
    {

        while (true)
        {
            int random = Random.Range(0, Balls.GetLength(0));
            int a = Random.Range(range, range * 2);
            int b = Random.Range(range, range * 2);

            int n = Random.Range(0, 1);
            if (n == 0)
            {
                a = a * (-1);
            }
            else if (n == 1)
            {
                b = b * (-1);
            }
            Vector3 ballPosition = new Vector3(GameObject.Find("player").transform.position.x + a, GameObject.Find("player").transform.position.y+5, GameObject.Find("player").transform.position.z + b);

            GameObject ball = Instantiate(Balls[random], ballPosition, Quaternion.identity);
            Invoke("generateBall", time);
            break;
        }
    }
}
