using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class CircleSpawner : MonoBehaviour, ClickObserver
{
    public Click click;
    public GameObject clickableCircle;

    void Start()
    {
        click.register(this);
    }

    [ContextMenu("Click")]
    public void onClick()
    {
        UnityEngine.Debug.Log("Clicked");
        GameObject newCircle = Instantiate(clickableCircle, new Vector3(100, 100, 0), Quaternion.identity);
        newCircle.transform.localScale = new Vector3(3, 3, 3);
    }
}