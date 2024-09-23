using UnityEngine;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour, IMenu
{
    public bool isPaused = false;
    public BoxCollider2D boxCollider;

    void Start()
    {
        // Ensure the collider is enabled at the start
        if (boxCollider != null)
        {
            boxCollider.enabled = true;
        }
    }

    public bool checkOpen()
    {
        return (Input.GetKeyDown(KeyCode.Escape));
    }

    public void open()
    {
        isPaused = true;
    }

    public void close()
    {
		isPaused = false;
	}

    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        
        // Disable the collider when the game is paused
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;  // Unfreeze the game
        isPaused = false;
        // Re-enable the collider when the game is resumed
        if (boxCollider != null)
        {
            boxCollider.enabled = true;
        }
    }

    public void QuitGame()
    {
        //player.save();
        Application.Quit();  // Quit the game
	}
}
