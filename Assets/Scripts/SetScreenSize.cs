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
		RectTransform rectTransform = GetComponent<RectTransform>();
		rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, windowInfo.width);
		rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, windowInfo.height);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
