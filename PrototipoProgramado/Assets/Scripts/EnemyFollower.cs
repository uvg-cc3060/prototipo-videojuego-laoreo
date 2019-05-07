using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollower : MonoBehaviour
{
    //empezar con followingPlayer = false
    private NavMeshAgent nvaEnemy;
    private bool followingPlayer=true;
    public int life = 100;
    // Start is called before the first frame update
    void Start()
    {
        nvaEnemy = GetComponent<NavMeshAgent>();
        EventManager.StartListening("PlayerPositionUpdated", UpdatePosition);
        EventManager.StartListeningTransform("ThrowablePositionUpdated", UpdateTargetPosition);

    }

    private void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void UpdatePosition() {
        if (followingPlayer)
        {
            nvaEnemy.SetDestination(PersonajeScript.instance.transform.position);
        }
    }

    private void UpdateTargetPosition(Transform t)
    {
        followingPlayer = false;
        nvaEnemy.SetDestination(t.position);
        EventManager.TriggerEvent("EnemyFollowingPlayer");
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Throwable"))
        {
            followingPlayer = true;
            nvaEnemy.SetDestination(PersonajeScript.instance.transform.position);
            EventManager.TriggerEvent("EnemyReachedThrowable");
        }
        if (other.gameObject.tag == "Weapon")
        {
            life -= 50;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            followingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        followingPlayer = false;
    }
}
