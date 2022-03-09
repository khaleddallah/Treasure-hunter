using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;

    Rigidbody2D rb;

    Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        moveVelocity = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity.x = Input.GetAxis("Horizontal")*moveSpeed;
        moveVelocity.y = Input.GetAxis("Vertical")*moveSpeed;
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + moveVelocity*Time.fixedDeltaTime);
    }
}
