using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

public class CircleBehavior : MonoBehaviour, IPointerClickHandler, Item
{
	public Inventory inventory;
	public float timer = 0;
	public float maxTime = 3;
	public float fadeTimeStart = 2;
    private SpriteRenderer spriteRenderer;

    private void Start()
	{
		addPhysics2DRaycaster();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

	private void Update()
	{
		// Increment timer irregardless of FPS
		timer += Time.deltaTime;

		checkExpired();
		updateFade();
	}

	public int getItemID() { return 1; }
	public void OnPointerClick(PointerEventData eventData)
    {
		inventory.addItem(getItemID());
		Object.Destroy(this.gameObject);
    }

	private void addPhysics2DRaycaster()
	{
		Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
			Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

	private void checkExpired()
	{
		if (timer > maxTime)
		{
			Object.Destroy(this.gameObject);
		}
	}

	public void setTransparency(float newTransparency)
	{
        Color color = spriteRenderer.color;
        color.a = newTransparency;
        spriteRenderer.color = color;
    }

	private void updateFade()
	{
        if (timer > fadeTimeStart)
        {
            float timeSinceStart = timer - fadeTimeStart;
            float fadeDuration = maxTime - fadeTimeStart;
			// Transparency determined automatically based on how long the fade should be
            float newTransparency = 1 - (timeSinceStart / fadeDuration);
            setTransparency(newTransparency);
        }
    }
}
