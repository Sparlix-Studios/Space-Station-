using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] GameObject playerObj;
    [SerializeField] [Range(0,5)] float sensitivity = 5f;

    PlayerController player;


    float pitch = 0.0f;
    float roll = 0.0f;
    private void Start() {
        player = playerObj.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!player.Paused && !player.inventory) {
            roll += sensitivity * Input.GetAxis("Mouse X");
            pitch -= sensitivity * Input.GetAxis("Mouse Y");

            pitch = Mathf.Clamp(pitch, -60f, 90f);

            transform.eulerAngles = new Vector3(pitch, roll, 0.0f);
        }
    }
}
