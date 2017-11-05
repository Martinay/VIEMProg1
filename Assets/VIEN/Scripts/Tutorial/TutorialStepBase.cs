using UnityEngine;

public abstract class TutorialStepBase : MonoBehaviour
{
    public InputBehaviour InputBehaviour;
    public AudioClip Voice;
    public string Text;
    public GameObject VoiceHud;
    private AudioSource _audioSource;

    public abstract bool HasFinished { get; }

    void OnEnable()
    {
        VoiceHud.SetActive(true);
        VoiceHud.SendMessage("SetText", Text);
        
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = Voice;
        _audioSource.loop = false;
        _audioSource.Play();
    }

    void OnDisable()
    {
        VoiceHud.SetActive(false);
        _audioSource.Stop();
    }
}