using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour {
    public Camera camera;
    public Vector3 target;
    public bool isMoving;
    RaycastHit hit;
    public float elapsedTime = 0;
    public float duration = 1f;
    public float speed;
    private void Update() {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                target = hit.transform.position;
                target.y = transform.position.y;
                isMoving = true;
            }
        }
        if (isMoving) {
            float distance = Vector3.Distance(transform.position, target);
            transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
            elapsedTime = Time.deltaTime;
            if (distance<0.001f) {
                isMoving = false;
            }
        }
  
    }
}
