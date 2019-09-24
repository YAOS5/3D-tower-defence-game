using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    public float spinSpeed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        this.transform.localRotation *= Quaternion.AngleAxis(spinSpeed*Time.deltaTime*0.1f, Vector3.right);
    }
}
