using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Counter counter;
    BoxCollider2D collider;

	void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = new Vector3 (1, 1, 1);
        collider = GetComponent<BoxCollider2D>();
        collider.offset = new Vector2(0, 0);
        collider.size = new Vector2(Screen.width, Screen.height);
        collider.isTrigger = true;
    }

	public void OnMouseDown()
	{
		counter.addClicks();
	}

}
