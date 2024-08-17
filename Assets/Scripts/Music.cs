using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] musicTracks;

    void Start()
    {
        PlayMusicTrack(1); // Play the first track by default
    }

    public void PlayMusicTrack(int trackNumber)
    {
        if (trackNumber < 1 || trackNumber > musicTracks.Length)
        {
            Debug.LogWarning("Track number out of range!");
            return;
        }

        AudioClip clip = musicTracks[trackNumber - 1];
        audioSource.clip = clip;
        audioSource.Play();
    }

    void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayMusicTrack(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayMusicTrack(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayMusicTrack(3);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            StopMusic();
        }
    }
}
