using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    Camera cam;
    public WindowInfo windowInfo;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.aspect = (float)windowInfo.width / windowInfo.height;
        cam.orthographicSize = windowInfo.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
