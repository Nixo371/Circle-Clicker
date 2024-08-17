using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public GameObject uiImage;  // Assign your UI Image GameObject here
    public BoxCollider2D boxCollider;  // Reference to the BoxCollider2D

    void Update()
    {
        if (uiImage.activeInHierarchy) // If the UI Image is active
        {
            boxCollider.enabled = false;  // Disable the collider
        }
        else
        {
            boxCollider.enabled = true;  // Enable the collider
        }
    }
}
