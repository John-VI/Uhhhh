using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYoBodyPuebly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        Vector2 pos = transform.position;
        pos.x = pos.x + 1f * hori * Time.deltaTime;
        pos.y = pos.y + 1f * vert * Time.deltaTime;
        transform.position = pos;
    }
}
