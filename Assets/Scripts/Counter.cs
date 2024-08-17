using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Counter : MonoBehaviour, ClickObserver
{
    public int clickCount;
    public Text clickText;
    public Click click;
    public delegate void OnCounterIncremented();
    public static event OnCounterIncremented CounterIncremented;
    void Start()
    {
        clickCount = 0;
        clickText.text = "0";

        click.register(this);
    }

    [ContextMenu("Click")]
    public void onClick()
    {


        clickCount++;
        clickText.text = clickCount.ToString();
        CounterIncremented?.Invoke();
    }
}