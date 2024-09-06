using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Counter : MonoBehaviour, IClickObserver
{
    public PlayerSave save;
    public Text clickText;
    public ClickableBox click;
    public delegate void OnCounterIncremented();
    public static event OnCounterIncremented CounterIncremented;
    void Start()
    {
        clickText.text = save.clickCount.ToString();

        click.register(this);
    }

    [ContextMenu("Click")]
    public void onClick()
    {
        save.clickCount++;
        clickText.text = save.clickCount.ToString();
        CounterIncremented?.Invoke();
    }

	public void refresh()
	{
        clickText.text = save.clickCount.ToString();
	}
}