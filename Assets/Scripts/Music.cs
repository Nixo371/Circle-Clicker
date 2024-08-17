using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;     // Reference to the AudioSource component
    public AudioClip[] musicClips;      // Array to hold the music clips
    public Button playButton;           // Button to play or resume the music
    public Button pauseButton;          // Button to pause the music
    public Button nextButton;           // Button to play the next song
    public Button previousButton;       // Button to play the previous song

    private int currentClipIndex = 0;   // Index to track the current playing clip
    private bool isPaused = false;      // Flag to track if the music is paused

    void Start()
    {
        // Ensure AudioSource is assigned
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned.");
            return;
        }

        // Ensure musicClips array is not empty
        if (musicClips.Length == 0)
        {
            Debug.LogError("No music clips assigned.");
            return;
        }

        // Assign button click listeners
        playButton.onClick.AddListener(PlayOrResumeMusic);
        pauseButton.onClick.AddListener(PauseMusic);
        nextButton.onClick.AddListener(PlayNextClip);
        previousButton.onClick.AddListener(PlayPreviousClip);

        // Start playing the first song
        PlayClip(currentClipIndex);
    }

    void Update()
    {
        // Check if the current audio clip has finished playing
        if (!audioSource.isPlaying && !isPaused && musicClips.Length > 0)
        {
            PlayNextClip();
        }
    }

    void PlayClip(int index)
    {
        if (index < 0 || index >= musicClips.Length)
        {
            Debug.LogError("Invalid clip index.");
            return;
        }

        audioSource.Stop();
        audioSource.clip = musicClips[index];
        audioSource.Play();
        isPaused = false;
        currentClipIndex = index;
    }

    public void PlayOrResumeMusic()
    {
        if (isPaused)
        {
            audioSource.UnPause();
            isPaused = false;
        }
        else
        {
            PlayClip(currentClipIndex);
        }
        ResetButtonState(playButton);
    }

    public void PauseMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            isPaused = true;
        }
        ResetButtonState(pauseButton);
    }

    public void PlayNextClip()
    {
        // Move to the next clip index
        currentClipIndex = (currentClipIndex + 1) % musicClips.Length;
        PlayClip(currentClipIndex);
        ResetButtonState(nextButton);
    }

    public void PlayPreviousClip()
    {
        // Move to the previous clip index
        currentClipIndex = (currentClipIndex - 1 + musicClips.Length) % musicClips.Length;
        PlayClip(currentClipIndex);
        ResetButtonState(previousButton);
    }
    void ResetButtonState(Button button)
    {
        button.interactable = false;  // Temporarily disable the button
        button.interactable = true;   // Re-enable the button, resetting its state
    }
}
