using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYoBodyPuebly : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D body; //Yo Body
    float hori;
    float vert;

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); //Move it pueblay
    }

    // Update is called once per frame
    void Update()
    {
        hori = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
	Vector2 pos = body.position;
        pos.x = pos.x + 5f * hori * Time.deltaTime;
        pos.y = pos.y + 5f * vert * Time.deltaTime;
        body.MovePosition(pos);
    }
}
