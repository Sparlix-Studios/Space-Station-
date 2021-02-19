using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam :MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] [Range(0, 5)] float sensitivity = 5f;


    PlayerController playerController;

    bool firstPerson;

    private void Start() {
        playerController = player.GetComponent<PlayerController>();
    }

    float pitch = 0.0f;
    float roll = 0.0f;

    private void Update() {
        
        if (Cursor.lockState == CursorLockMode.Locked && !playerController.inventory && !playerController.Paused) {
            roll += sensitivity * Input.GetAxis("Mouse X");
            pitch -= sensitivity * Input.GetAxis("Mouse Y");

            pitch = Mathf.Clamp(pitch, -60f, 90f);

            transform.eulerAngles = new Vector3(pitch, roll, 0.0f);
        }
    }
}