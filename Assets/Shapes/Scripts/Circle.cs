using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

public class Circle : MonoBehaviour, IPointerClickHandler, IItem, ISpawnable
{
	public Player player;
	float timer = 0;
	float maxTime = 3;
	float fadeTimeStart = 2;
    private SpriteRenderer spriteRenderer;

	private static int rarity = 50;

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

	public void spawn(int x, int y, int scale)
	{
		GameObject newShape = Instantiate(getGameObject(), new Vector3(x, y, 0), Quaternion.identity);
		newShape.transform.localScale = new Vector3(scale, scale, 0);
	}

	public int getItemID() { return 1; }
	public int getRarity() { return rarity; }
	public GameObject getGameObject() { return (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Shapes/Circle.prefab", typeof(GameObject)); }
	public void OnPointerClick(PointerEventData eventData)
    {
		player.inventory.addItem(getItemID());
		Object.Destroy(this.gameObject);
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

	private void addPhysics2DRaycaster()
	{
		Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
		if (physicsRaycaster == null)
		{
			Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
		}
	}
}
