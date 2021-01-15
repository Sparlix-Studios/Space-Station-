using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    float HSpeed = 5f;
    float VSpeed = 5f;

    float pitch = 0.0f;
    float roll = 0.0f;

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked) {
            roll += HSpeed * Input.GetAxis("Mouse X");
            pitch -= VSpeed * Input.GetAxis("Mouse Y");

            pitch = Mathf.Clamp(pitch, -60f, 90f);

            transform.eulerAngles = new Vector3(pitch, roll, 0.0f);
        }
        GetInput();
    }

    private void GetInput() {
        if (Input.GetKey(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Cursor.lockState == CursorLockMode.None) {
            if (Input.GetMouseButton(0)) {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

        private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
