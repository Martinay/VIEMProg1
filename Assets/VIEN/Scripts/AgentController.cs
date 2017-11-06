using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour {

    public Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;
    public AudioClip Dead_sound;
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

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.loop = false;
            audioSource.PlayOneShot(Dead_sound, 0.7F);
            
        }
    }
}
