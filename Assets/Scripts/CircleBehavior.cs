using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;

public class CircleBehavior : MonoBehaviour, IPointerClickHandler
{

	private void Start()
	{
		addPhysics2DRaycaster();
	}
	public void OnPointerClick(PointerEventData eventData)
    {
		UnityEngine.Debug.Log("Circle Clicked");
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
