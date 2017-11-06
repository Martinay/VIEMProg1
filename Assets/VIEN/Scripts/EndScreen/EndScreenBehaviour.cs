using UnityEngine;

public class EndScreenBehaviour : MonoBehaviour
{
    public AudioClip Voice;
    public Camera Camera;
    private AudioSource _audioSource;

    void OnEnable()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = Voice;
        _audioSource.loop = false;
        _audioSource.Play();

        //StartWalking
        //SetCameraMain
    }

    void Update()
    {
        if (_audioSource.isPlaying)
            return;
        
    }
}