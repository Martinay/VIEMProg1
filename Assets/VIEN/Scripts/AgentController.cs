using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour {

    public Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;
    public AudioClip dead;
    AudioSource audioSource;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        agent.destination = goal.position;
    }

    void OnDisable()
    {
        agent.isStopped = true;
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.loop = false;
            audioSource.PlayOneShot(dead, 0.7F);
            
        }
    }
}
