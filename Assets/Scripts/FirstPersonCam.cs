using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;


    PlayerController playerController;

    bool firstPerson;

    private void Start() {
        playerController = player.GetComponent<PlayerController>();
    }

    float HSpeed = 5f;
    float VSpeed = 5f;

    float pitch = 0.0f;
    float roll = 0.0f;

    private void Update() {

        firstPerson = playerController.firstPerson;

        if (Cursor.lockState == CursorLockMode.Locked) {
                roll += HSpeed * Input.GetAxis("Mouse X");
                pitch -= VSpeed * Input.GetAxis("Mouse Y");

                pitch = Mathf.Clamp(pitch, -60f, 90f);

                cam.transform.eulerAngles = new Vector3(pitch, roll, 0.0f);
        }
    }
}
