using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour {

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public bool movementEnabled = true;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        // Pressing escape will enable/disable movement
        if (Input.GetKeyDown(KeyCode.Escape)) {
            movementEnabled = !movementEnabled;
        }

        if (!movementEnabled) {
            return;
        }

        // Space.world makes it move forward without regard to camera rotation, this will be useful
        if (Input.GetKey("w")) {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s")) {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d")) {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a")) {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        // Allows us to zoom in using the mouse wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 currentPosition = transform.position;
        currentPosition.y -= scroll * scrollSpeed * Time.deltaTime;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);
        transform.position = currentPosition;

    }
}
