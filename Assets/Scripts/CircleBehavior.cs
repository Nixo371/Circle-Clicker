using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

public class CircleBehavior : MonoBehaviour, IPointerClickHandler, Item
{
	public Inventory inventory;

	private void Start()
	{
		addPhysics2DRaycaster();
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
}
