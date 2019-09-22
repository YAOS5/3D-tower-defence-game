using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour{
    public float xcoor;
    public float ycoor;
    public float zcoor;

    public GameObject projectilePrefab;


    void Start()
    {
        // for testing purpose just going to set
        // xyz to the origin
        // delete this later
        xcoor = ycoor = zcoor = 0;
        this.gameObject.transform.position = new Vector3(xcoor, ycoor, zcoor);
    }

    // Update is called once per frame
    void Update()
    {
        // code from workshop
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.position = this.gameObject.transform.position;
        }
    }


    //public static void initializeTowerPosition(float x, float y, float z)
    //{
    //}
}
