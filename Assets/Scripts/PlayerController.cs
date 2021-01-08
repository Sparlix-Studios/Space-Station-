using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] int playerSpeed = 5;
    [SerializeField] [Range(0, 10)] int jumpHeight = 5;

    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject fpCam;
    [SerializeField] GameObject tpCam;

    Rigidbody rb;

    Vector3 fwdDir;

    public bool firstPerson = true;
    bool isGrounded = false;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        GetInput();
        CheckView();
    }

    private void CheckView() {
        if (firstPerson) {
            mainCam.SetActive(false);
            tpCam.SetActive(false);
            fpCam.SetActive(true);
        }
        if (!firstPerson) {
            mainCam.SetActive(false);
            tpCam.SetActive(true);
            fpCam.SetActive(false);
        }
    }

    private void GetInput() {

        Movement();

        if (Input.GetKeyDown(KeyCode.LeftShift))
            playerSpeed *= 2;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            playerSpeed /= 2;

        if (Input.GetKeyDown(KeyCode.V)) {
            firstPerson = !firstPerson;
        }

        if (firstPerson)
            Cursor.lockState = CursorLockMode.Locked;
    }

    private void Movement() {
        fwdDir = tpCam.transform.forward;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * 5f, 0)));
        if (firstPerson)
            rb.MovePosition(transform.position + (fwdDir * Input.GetAxis("Vertical") * playerSpeed / 4) + (transform.right * Input.GetAxis("Horizontal") * playerSpeed / 4));
        else
            rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * playerSpeed / 4) + (transform.right * Input.GetAxis("Horizontal") * playerSpeed / 4));
        if (Input.GetKeyDown("space") && isGrounded)
            rb.AddForce(transform.up * jumpHeight * 50);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.collider.tag == "Ground")
            isGrounded = false;
    }
}
