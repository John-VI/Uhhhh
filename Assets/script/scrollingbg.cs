using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingbg : MonoBehaviour
{
    // Start is called before the first frame update
    public float hspeed;
    public float vspeed;
    float hoffset;
    float voffset;
    Renderer ren;

    void Start() {
        ren = GetComponent<Renderer>();
        hoffset = 0;
        voffset = 0;
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
        print(hoffset);
        print(voffset);
    }
}
