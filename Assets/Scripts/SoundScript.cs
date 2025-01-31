using UnityEngine;

public class SoundScript : MonoBehaviour
{
    private AudioClip audioFile;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioFile = audioSource.clip;
    }

    public void Shoot()
    {
        audioSource.PlayOneShot(audioFile);
    }

}
