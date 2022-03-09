using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController3 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private LineRenderer lr;


    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 moveTemp;
    Vector2 moveVelocity;

    Vector3 InitPos;
    const float maxDist = 12.0f;
    float relationSpeed;
    bool getBackTrig = false;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        moveInput = new Vector2(0f, 0f);
        InitPos = transform.position;
        lr.SetPosition(0, InitPos);

    }

    // Update is called once per frame
    void Update()
    {
        moveTemp = moveInput;
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        if( (moveInput.x==0 && moveInput.y<moveTemp.y) ||
            (moveInput.x<moveTemp.x && moveInput.y==0) || 
            (moveInput.x<moveTemp.x && moveInput.y<moveTemp.y) ){
            getBackTrig = true;
        }
    }

    void FixedUpdate(){
        relationSpeed =  1-((transform.position-InitPos).magnitude / maxDist);

        lr.SetPosition(1, transform.position);
        lr.startWidth=relationSpeed*0.3f;
        lr.endWidth=relationSpeed*0.3f;
        
        // get truck back
        if(moveInput.magnitude==0 || getBackTrig){
            getBackTrig = false;
            Vector3 temp = InitPos - transform.position;
            moveVelocity = 3.5f * moveSpeed * new Vector2(temp.normalized.x, temp.normalized.y);
            Debug.Log("moveVelocity: "+moveVelocity);
            rb.MovePosition(rb.position + moveVelocity*Time.fixedDeltaTime);
            if((transform.position-InitPos).magnitude<0.5f){
                transform.position = InitPos;
            }
        }
        // user input
        else{
            moveVelocity = moveInput * moveSpeed;
            rb.MovePosition(rb.position + moveVelocity*relationSpeed*Time.fixedDeltaTime);
        }
    }
}
