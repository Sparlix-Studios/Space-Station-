using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController :MonoBehaviour {
    [SerializeField] [Range(0, 10)] float playerSpeed = 5;
    [SerializeField] [Range(0, 10)] int jumpHeight = 5;

    [SerializeField] GameObject fpCam;
    [SerializeField] GameObject tpCam;
    [SerializeField] GameObject invCanv;
    [SerializeField] Texture2D invCursor;
    [SerializeField] Texture2D ClickedCursor;

    Rigidbody rb;
    //SaveData save;
    Animator anim;

    Vector3 fwdDir;

    public bool firstPerson = true;
    public bool isGrounded = false;
    bool shiftDown = false;
    public bool Paused;
    public bool inventory = false;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        //save = GetComponent<SaveData>();
        anim = GetComponentInChildren<Animator>();

        //NEVER save.addMoney AT START!!! (Or Fix Bug)
        StartCoroutine("testData");
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(invCursor, Vector2.zero, CursorMode.Auto);
    }

    IEnumerator testData() {
        yield return new WaitForSeconds(1f);
        //save.addDataType("money", 0f, true);
        //save.addDataType("testData", 0f, true);
    }

    private void Update() {
        GetInput();
        CheckView();
    }

    private void CheckView() {
        if (firstPerson) {
            tpCam.SetActive(false);
            fpCam.SetActive(true);
        }
        if (!firstPerson) {
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
            if (!shiftDown) { }
            //save.addData("money", 1);
            else { }
                //save.removeData("money", 1);
        }

        if (Input.GetKeyDown(KeyCode.Insert)) {
            //save.clearDataHistory(true);
        }
        if (!isGrounded)
            anim.SetBool("inAir", true);
        else
            anim.SetBool("inAir", false);
        if (firstPerson)
            Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Paused = !Paused;
        }
        if (Input.GetMouseButton(0) && Paused)
            Paused = false;
        if (Paused == true) {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            inventory = !inventory;
            invCanv.SetActive(inventory);
            
        }
        if (inventory) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetMouseButtonDown(0)) {
                Cursor.SetCursor(ClickedCursor, Vector2.zero, CursorMode.Auto);
                print("Down");
            }
            if (Input.GetMouseButtonUp(0)) {
                Cursor.SetCursor(invCursor, Vector2.zero, CursorMode.Auto);
                print("Up");
            }
        } else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Movement() {
        if (Cursor.lockState == CursorLockMode.Locked && !Paused) {
            if (Input.GetKeyDown(KeyCode.W)) {
                if (isGrounded) {
                    if (shiftDown)
                        anim.SetBool("isSprinting", true);
                    else
                        anim.SetBool("isRunning", true);
                }
            }

            if (Input.GetKeyUp(KeyCode.W)) {
                if (isGrounded) {
                    if (shiftDown)
                        anim.SetBool("isSprinting", false);
                    anim.SetBool("isRunning", false);
                    anim.SetTrigger("goIdle");
                }
            }
            if (!inventory) {
                fwdDir = fpCam.transform.forward;
                rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * 5f, 0)));
            }
            if (firstPerson)
                rb.MovePosition(transform.position + (fwdDir * Input.GetAxis("Vertical") * playerSpeed / 4) + (transform.right * Input.GetAxis("Horizontal") * playerSpeed / 4));
            else
                rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * playerSpeed / 4) + (transform.right * Input.GetAxis("Horizontal") * playerSpeed / 4));
            if (Input.GetKeyDown("space") && isGrounded) {
                rb.AddForce(transform.up * jumpHeight * 50);
                anim.SetTrigger("Jump");
            }   
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Ground") {
            isGrounded = true;
            anim.SetTrigger("EndJump");
            anim.SetTrigger("goIdle");
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.collider.tag == "Ground") {
            isGrounded = false;
        }
    }
}
