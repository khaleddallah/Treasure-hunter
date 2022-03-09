using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 40.0f;
    public float randspeed = 5.0f;
    
    private Vector2 moveVelocity;
    private Vector2 randmoveVelocity;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rb=GetComponent<Rigidbody2D>();
        // StartCoroutine(RandomMove());
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));

    }


    void FixedUpdate() {
        // rb.MovePosition(moveVelocity+ (randmoveVelocity) * Time.fixedDeltaTime);
        rb.MovePosition(moveVelocity);
    }

    // IEnumerator RandomMove(){
    //     while(true){
    //         yield return new WaitForSeconds(0.01f);
    //         //random shacking
    //         Vector2 randmove = new Vector2(Random.Range(-0.1f, 0.1f),Random.Range(-0.1f, 0.1f));
    //         randmoveVelocity = randmove.normalized * randspeed;
    //     }
    // }


}
