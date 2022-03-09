using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // Used by gun to keep look at the crosshair

    [SerializeField] private Transform target;

    void FixedUpdate() {
        Vector3 diff = target.position - transform.position;
        float rotz = Mathf.Atan2(diff.y,diff.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotz);
    }
}
