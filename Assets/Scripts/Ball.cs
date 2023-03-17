using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public static Ball instance;
    public float speed = 5f;
    public int paintedGround = 0;

    Rigidbody rb;
    Vector2 _firstPos;
    Vector2 _secondPos;
    Vector2 _currentPos;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void Update() {
        Movement();
    }
    void Movement() {
        if (Input.GetMouseButtonDown(0)) {
            _firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0)) {
            _secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            _currentPos = new Vector2(_secondPos.x - _firstPos.x, _secondPos.y - _firstPos.y);

            _currentPos.Normalize();
        }

        if (_currentPos.y > 0 && _currentPos.x < 0.5f && _currentPos.x > -0.5f) {
            rb.velocity = Vector3.forward * speed * Time.deltaTime;
        } else if (_currentPos.y < 0 && _currentPos.x < 0.5f && _currentPos.x > -0.5f) {
            rb.velocity = Vector3.back * speed * Time.deltaTime;
        } else if (_currentPos.x < 0 && _currentPos.y < 0.5f && _currentPos.y > -0.5f) {
            rb.velocity = Vector3.left * speed * Time.deltaTime;
        } else if (_currentPos.x > 0 && _currentPos.y < 0.5f && _currentPos.y > -0.5f) {
            rb.velocity = Vector3.right * speed * Time.deltaTime;
        }


    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            var groundMat = collision.gameObject.GetComponent<MeshRenderer>().material;
            if (groundMat.color != Color.red) {
                groundMat.color = Color.red;
                paintedGround++;
            }
        }
    }
}
