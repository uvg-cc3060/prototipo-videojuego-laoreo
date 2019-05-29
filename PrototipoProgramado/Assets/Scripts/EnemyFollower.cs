using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollower : MonoBehaviour
{
    //empezar con followingPlayer = false
    public Transform target;
    private NavMeshAgent nvaEnemy;
    private Transform  tran;
    private Vector3 position;
    private bool followingPlayer=false;
    public float life = 100.0f;
    // public int life = 100;
    // Start is called before the first frame update
    void Start()
    {
        nvaEnemy = GetComponent<NavMeshAgent>();
        tran = GetComponent<Transform>();
        position = tran.position;
        //EventManager.StartListening("PlayerPositionUpdated", UpdatePosition);
        //EventManager.StartListeningTransform("ThrowablePositionUpdated", UpdateTargetPosition);

    }
    /*
    private void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    */
    private void Update()
    {
    
    if (followingPlayer)
        {
           nvaEnemy.SetDestination(target.position);
        }
        else {
            if (!transform.position.Equals(position)) {
                nvaEnemy.SetDestination(position);
            }
        }

    if(life <= 0)
        {
            Destroy(gameObject);
        }
    }
    /*
    private void UpdateTargetPosition(Transform t)
    {
        followingPlayer = false;
        nvaEnemy.SetDestination(t.position);
        EventManager.TriggerEvent("EnemyFollowingPlayer");
    }

    /*
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
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Weapon")
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
        if (other.gameObject.tag.Equals("Player"))
        {
            followingPlayer = false;
        }
    }
}
