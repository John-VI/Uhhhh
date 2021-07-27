using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movlink : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    public scrollingbg scrspd;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
	Vector2 pos = character.transform.position;
        scrspd.hspeed = (float)pos.x;
        scrspd.vspeed = (float)pos.y;
    }
}
