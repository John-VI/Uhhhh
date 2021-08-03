using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingbg : MonoBehaviour
{
    // Start is called before the first frame update
    public float hspeed;
    public float vspeed;
    public Color tint = new Color(255, 255, 255, 255);
    public Camera cam;
    float hoffset;
    float voffset;
    Renderer ren;

    void Start() {
        ren = GetComponent<Renderer>();
        Transform trans = GetComponent<Transform>();
        trans.position = new Vector3(0, 0, 1);
        float height = 2.0f * cam.orthographicSize;
        trans.localScale = new Vector3(height * cam.aspect, height, 1);// does
        hoffset = 0;
        voffset = 0;
        ren.material.SetColor("_Color", tint);
    }

    // Update is called once per frame
    void Update() {
        hoffset += Time.deltaTime * hspeed;
        voffset += Time.deltaTime * vspeed;
        if (Mathf.Abs(voffset) > ren.material.mainTexture.height)
	    voffset -= ren.material.mainTexture.height * (voffset/Mathf.Abs(voffset));
	if (Mathf.Abs(hoffset) > ren.material.mainTexture.width)
	    hoffset -= ren.material.mainTexture.width * (hoffset/Mathf.Abs(hoffset));
        ren.material.mainTextureOffset = new Vector2(hoffset, voffset);
    }
}
