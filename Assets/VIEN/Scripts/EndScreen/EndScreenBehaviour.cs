using UnityEngine;

public class EndScreenBehaviour : MonoBehaviour
{
    public AudioClip Voice;
    public Camera Camera;
    public GameObject EndOfWalk;
    public GameObject Character;
    public GameObject FpsController;
    public GameObject EndScreenHud;

    private AudioSource _audioSource;
    private bool _hudIsActive;

    void OnEnable()
    {
        FpsController.SetActive(false);
        Camera.enabled = true;
        _hudIsActive = false;
        
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = Voice;
        _audioSource.loop = false;
        _audioSource.Play();

        var agent = Character.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = EndOfWalk.transform.position;
    }

    void Update()
    {
        if (_audioSource.isPlaying)
            return;

        if(_hudIsActive)
            return;
        
        EndScreenHud.SetActive(true);
        _hudIsActive = true;
    }
}