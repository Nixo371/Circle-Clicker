using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;     // Reference to the AudioSource component
    public AudioClip[] musicClips;      // Array to hold the music clips
    public Button playButton;           // Button to play or resume the music
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
        nextButton.onClick.AddListener(PlayNextClip);
        previousButton.onClick.AddListener(PlayPreviousClip);

        // Start playing the first song
        PlayClip(currentClipIndex);
    }
    void OnApplicationFocus(bool hasFocus)
    {
        // This is called when the app gains or loses focus
        if (!hasFocus)
        {
            // App lost focus, save the current playback time
            SavePlaybackPosition();
            audioSource.Pause(); // Pause the music
        }
        else if (isPaused == false)
        {
            // App gained focus, resume playback from saved position
            ResumePlayback();
        }
    }

    void SavePlaybackPosition()
    {
        // Save the current time of the track
        PlayerPrefs.SetFloat("MusicPlaybackTime", audioSource.time);
    }

    void ResumePlayback()
    {
        // Retrieve the saved playback time
        float savedTime = PlayerPrefs.GetFloat("MusicPlaybackTime", 0f);
        audioSource.time = savedTime;
        audioSource.Play(); // Resume playback from the saved time
    }
    void Update()
    {
        // Check if the current audio clip has finished playing
        if (!audioSource.isPlaying && !isPaused && audioSource.time >= audioSource.clip.length)
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
        Text playButtonText = playButton.GetComponentInChildren<Text>();
        if (isPaused)
        {
            audioSource.UnPause();
            isPaused = false;
            playButtonText.text = "Pause";
        }
        else if (audioSource.isPlaying)
        {
            audioSource.Pause();
            isPaused = true;
            playButtonText.text = "Play";
        }
        else
        {
            PlayClip(currentClipIndex);
        }
        ResetButtonState(playButton);
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
