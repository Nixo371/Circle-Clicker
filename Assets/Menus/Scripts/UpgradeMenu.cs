using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour, IMenu
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool checkOpen()
    {
        return (Input.GetKeyDown(KeyCode.U));
    }

    public void open()
    {

    }

    public void close()
    {

    }
}
