using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleCounter : MonoBehaviour
{
    public CircleBehavior circle;
    public Inventory inventory;
	public Text circleText;

    private int circleCount;
	void Start()
    {
        circleCount = inventory.getItemCount(circle.getItemID());
        circleText.text = circleCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int newCount = inventory.getItemCount(circle.getItemID());
		if (circleCount != newCount)
        {
            circleCount = newCount;
            circleText.text = circleCount.ToString();
        }
    }
}
