using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private Transform groundCheckTransform = null;

    private bool jumpKeyPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start() {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            jumpKeyPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    // FixedUpdate is called once per physics engine update
    private void FixedUpdate() {
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, rigidbodyComponent.velocity.z);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1) { // Object may overlap several objects and so it returns a list, if the list doesn't have any entries then not colliding so return
            return;                                                                     // However, it has it's own collider so need to test for list length of 1
        }
        if (jumpKeyPressed) {
            rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }
    }


}
