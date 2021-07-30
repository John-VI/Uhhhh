using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceAspect : MonoBehaviour
{
    // SCREW 16:9, ALL MY HOMIES USE 4:3
    // This was mostly lifted from https://forum.unity.com/threads/aspect-ratio-issue-on-build.543722/
    
    public Vector2 ratio;
    
    void Start()
    {
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / ((float)ratio.x / (float)ratio.y);
        Camera cam = GetComponent<Camera>();

        if (scaleheight < 1f) {
            Rect rect = cam.rect;

            rect.width = 1f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1f - scaleheight) / 2f;

            cam.rect = rect;
        } else if (scaleheight > 1f) {
	    Rect rect = cam.rect;
            scaleheight = 1f / scaleheight;

            rect.height = 1f;
            rect.width = scaleheight;
            rect.y = 0;
            rect.x = (1f - scaleheight) / 2f;

            cam.rect = rect;
	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
