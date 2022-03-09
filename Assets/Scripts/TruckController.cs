using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float rotSpeed = 40.0f;

    Rigidbody2D rb;

    float rotInput;
    float moveInput;

    Vector2 moveVelocity;
    // float RotVelocity=0f;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        moveVelocity = new Vector2(0f, 0f);

        rotInput = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Vertical")*moveSpeed;
        rotInput = Input.GetAxisRaw("Horizontal")*rotSpeed;
    }

    void FixedUpdate(){
        moveVelocity.x = Mathf.Cos((transform.rotation.eulerAngles.z+90)*Mathf.Deg2Rad);
        moveVelocity.y = Mathf.Sin((transform.rotation.eulerAngles.z+90)*Mathf.Deg2Rad);


        rb.MovePosition(rb.position + moveVelocity*moveInput*Time.fixedDeltaTime);
        transform.Rotate(0f, 0f, -rotInput*Time.fixedDeltaTime);
    }
}
