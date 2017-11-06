using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour {

    public Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;
    public AudioClip Dead_sound;
    AudioSource audioSource;
    Vector3 startstate;
    public GameObject StartPosition;
    bool newround;



    void Start()
    {
        startstate = gameObject.transform.position;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        newround = false;
    }

    private void Update()
    {

        agent.destination = goal.position;
        if (audioSource.isPlaying == false && newround == true)
        {   
            transform.position = startstate;
            audioSource.loop = true;
            StartPosition.SendMessage("newPosition");
            newround = false;
            audioSource.Play();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.loop = false;
            audioSource.PlayOneShot(Dead_sound, 0.7F);
            newround = true;
        }
    }
}
