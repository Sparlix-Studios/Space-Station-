using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] float playerSpeed = 5;
    [SerializeField] [Range(0, 10)] int jumpHeight = 5;

    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject fpCam;
    [SerializeField] GameObject tpCam;

    Rigidbody rb;
    SaveData save;

    Vector3 fwdDir;

    public bool firstPerson = true;
    bool isGrounded = false;
    bool shiftDown = false;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        save = GetComponent<SaveData>();
        //NEVER save.addMoney AT START!!! (Or Fix Bug)
        StartCoroutine("testData");
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    IEnumerator testData() {
        yield return new WaitForSeconds(1f);
        //save.addDataType("money", 0f, true);
        save.addDataType("testData", 0f, true);
    }

    private void Update() {
        GetInput();
        CheckView();
    }

    private void CheckView() {
        if (firstPerson) {
            //mainCam.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            playerSpeed *= 2;
            shiftDown = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            playerSpeed /= 2;
            shiftDown = false;
        }

        if (Input.GetKeyDown(KeyCode.V)) {
            firstPerson = !firstPerson;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (!shiftDown)
                save.addData("money", 1);
            else
                save.removeData("money", 1);
        }

        if (Input.GetKeyDown(KeyCode.Insert)) {
            save.clearDataHistory(true);
        }

        if (firstPerson)
            Cursor.lockState = CursorLockMode.Locked;
    }

    private void Movement() {
        fwdDir = tpCam.transform.forward;
        if (Cursor.lockState == CursorLockMode.Locked) {
            if (Input.GetKeyDown(KeyCode.LeftShift))
                playerSpeed = 2;
            if (Input.GetKeyUp(KeyCode.LeftShift))
                playerSpeed = 1;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * 5f, 0)));
            rb.MovePosition(transform.position + (fwdDir * Input.GetAxis("Vertical") * playerSpeed / 4) + (tpCam.transform.right * Input.GetAxis("Horizontal") * playerSpeed / 4));
            if (Input.GetKeyDown("space") && isGrounded)
                rb.AddForce(transform.up * jumpHeight * 50);
        }
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
