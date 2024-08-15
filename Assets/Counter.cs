using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int clickCount;
    public Text clickText;

    void Start()
    {
        clickCount = 0;
        clickText.text = "0";
    }

    [ContextMenu("Click")]
    public void addClicks()
    {
        clickCount += 1;
        clickText.text = clickCount.ToString();
    }
}