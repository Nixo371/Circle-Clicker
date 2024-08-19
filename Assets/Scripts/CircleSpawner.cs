using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class CircleSpawner : MonoBehaviour, ClickObserver
{
    public ClickableBox clickableBox;
    public GameObject clickableCircle;
    public WindowInfo windowInfo;

	int scale;
	int notSpawnableBorder;
	int w;
	int h;
	float rarity;

	void Start()
    {
        clickableBox.register(this);

		scale = 8;
		notSpawnableBorder = (int) (clickableCircle.GetComponent<CircleCollider2D>().radius * scale * 1.05);
		w = windowInfo.width - (2 * notSpawnableBorder);
		h = windowInfo.height - (2 * notSpawnableBorder);

		rarity = 1f / 10;
	}

    [ContextMenu("Click")]
    public void onClick()
    {
        UnityEngine.Debug.Log("Clicked");

		if (Random.value < rarity)
		{
			int x = (int) Mathf.Floor(Random.value * w) - (w / 2);
			int y = (int) Mathf.Floor(Random.value * h) - (h / 2);
			GameObject newCircle = Instantiate(clickableCircle, new Vector3(x, y, 0), Quaternion.identity);
			newCircle.transform.localScale = new Vector3(scale, scale, 0);
		}
    }
}