using UnityEngine;

public class BulletSound : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // Lazer spawn olunca sesi çal
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}