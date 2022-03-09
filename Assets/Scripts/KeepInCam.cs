using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInCam : MonoBehaviour
{
    // Used with PLCrosshair to keep it inside the view screen
    Camera camm;

    void Start(){
        camm = Camera.main;
    }


    void Update() {
        Vector3 pos = camm.WorldToViewportPoint(transform.position);
        if(pos.x>0.99f){
            pos.x = 0.99f;
            transform.position = camm.ViewportToWorldPoint(pos);
        } 
        if(pos.x<0.01f){
            pos.x = 0.01f;
            transform.position = camm.ViewportToWorldPoint(pos);
        }
        if(pos.y>0.98f){
            pos.y = 0.98f;
            transform.position = camm.ViewportToWorldPoint(pos);
        } 
        if(pos.y<0.01f){
            pos.y = 0.01f;
            transform.position = camm.ViewportToWorldPoint(pos);
        }
    }
    
}
