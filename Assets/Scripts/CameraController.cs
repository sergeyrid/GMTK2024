using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private Vector3 dragOrigin;
    private Vector3 dragCamOrigin;
    Vector3 screenDelta;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0)) {
            dragOrigin = Input.mousePosition;
            dragCamOrigin = transform.position;
        } else {
            if(Input.GetMouseButton(0)) {
                // Why the fuck ScreenToWorldPoint() acts like it's non-linear
                Vector3 worldDelta = cam.ScreenToWorldPoint(Input.mousePosition) - cam.ScreenToWorldPoint(dragOrigin);
                worldDelta.z = 0;
                transform.position = dragCamOrigin - worldDelta;
            }
        }

        // Who cares about mouse wheel scrolling sideways, right
        if(Input.mouseScrollDelta.y > 0) {
            
        }
    }
}
