using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ClickableBox : MonoBehaviour
{
    private List<IClickObserver> observers = new List<IClickObserver>();
    public WindowInfo windowInfo;
    BoxCollider2D clickCollider;

    void Start()
    {
		clickCollider = GetComponent<BoxCollider2D>();
		clickCollider.offset = new Vector2(0, 0);
		clickCollider.size = new Vector2(windowInfo.width, windowInfo.height);
		clickCollider.isTrigger = true;
    }

    public void register(IClickObserver observer)
    {
        observers.Add(observer);
    }

    public void OnMouseDown()
    {
        foreach (IClickObserver observer in observers)
        {
            observer.onClick();
        }
    }

}