using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float mSize;
    public float mHeight;
    public float spinSpeed;
    public float moveSpeed;
    Vector3 initialPosition;

    private Vector3 initialViewPosition = Vector3.zero;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        initialPosition = new Vector3(0.4f * mSize, 2.0f * mHeight, 0.4f * mSize);
        InitialiseCameraPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            CheckRelease();
        }
        
        CameraMovement();
        
        if (Input.GetKey(KeyCode.R))
        {
            InitialiseCameraPosition();
        }
    }

    //when the camera collides with the terrain, the game moves the camera 5 units in the opposite
    //direction that it is currently moving (more if it is moving in both allowed axes), and stops
    //it from moving further until all movement keys aren't being held down during one update()
    void OnCollisionEnter (Collision collision)
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.localPosition += (-5.0f) * this.transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.localPosition -= (-5.0f) * this.transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.localPosition -= (-5.0f) * this.transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.localPosition += (-5.0f) * this.transform.right;
        }
        canMove = false;
    }

    //checks that no keys are being held down and allows the camera to move if so
    void CheckRelease()
    {
        if (!((Input.GetKey(KeyCode.W))||
            (Input.GetKey(KeyCode.A))||
            (Input.GetKey(KeyCode.S))||
            (Input.GetKey(KeyCode.D))))
        {
            canMove = true;
        }
    }

    void CameraMovement()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.localPosition += this.transform.forward * moveSpeed * Time.deltaTime;
                if (CheckOutOfBounds())
                {
                    this.transform.localPosition -= this.transform.forward * moveSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.localPosition -= this.transform.right * moveSpeed * Time.deltaTime;
                if (CheckOutOfBounds())
                {
                    this.transform.localPosition += this.transform.right * moveSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.localPosition -= this.transform.forward * moveSpeed * Time.deltaTime;
                if (CheckOutOfBounds())
                {
                    this.transform.localPosition += this.transform.forward * moveSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.localPosition += this.transform.right * moveSpeed * Time.deltaTime;
                if (CheckOutOfBounds())
                {
                    this.transform.localPosition -= this.transform.right * moveSpeed * Time.deltaTime;
                }
            }
            this.transform.localRotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * spinSpeed * Time.deltaTime, Vector3.up);
            this.transform.localRotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * spinSpeed * Time.deltaTime, Vector3.left);
        }
    }

    bool CheckOutOfBounds()
    {
        if (((this.transform.localPosition.x) > (0.5f * mSize))||
            ((this.transform.localPosition.z) > (0.5f * mSize))||
            ((this.transform.localPosition.x) < -(0.5f * mSize))||
            ((this.transform.localPosition.z) < -(0.5f * mSize)))
        {
            return true;
        }
        return false;
    }

    //gives the camera its initial position
    void InitialiseCameraPosition()
    {
        this.transform.localPosition = initialPosition;
        this.transform.LookAt(initialViewPosition);
    }

}
