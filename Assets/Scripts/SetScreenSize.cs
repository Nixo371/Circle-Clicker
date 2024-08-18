using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenSize : MonoBehaviour
{
	public WindowInfo windowInfo;
	// Start is called before the first frame update
	void Start()
	{
		transform.position = new Vector3(0, 0, 0);
		transform.localScale = new Vector3(windowInfo.width, windowInfo.height, 0);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
