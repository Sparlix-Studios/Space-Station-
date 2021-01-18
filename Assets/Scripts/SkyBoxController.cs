using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxController : MonoBehaviour
{
    [SerializeField] bool rotatesky = false;
    public bool speedup = false;
    public float rotatespeed = 1.0f;

    Vector3 originalcamangle;
    Camera thisCam;
    private void Start() {
        Camera.main.fieldOfView = 60f;
        thisCam = GetComponent<Camera>();
        originalcamangle = new Vector3(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
    }
    private void Update() {
        getinput();
        //hyperspace();
        if (!rotatesky) {
            transform.Rotate(originalcamangle.x, originalcamangle.y, originalcamangle.z);
        }
    }

    //private void hyperspace() {
    //    if (speedup) {
    //        if (thiscam.fieldOfView < 179f)
    //            thiscam.fieldOfView++;
    //        if (thiscam.fieldOfView == 179)
    //            rotatespeed = 6;
    //    } else {
    //        if (thiscam.fieldOfView > 60f)
    //            thiscam.fieldOfView--;
    //        if (thiscam.fieldOfView == 179)
    //            rotatespeed = 1;
    //    }
    //}

    private void getinput() {
        if (Input.GetKeyDown(KeyCode.O)) {
            speedup = !speedup;
        }
    }

    private Vector3 rotationvalue; private float turnvalue = 0.0f; private float turnval { get { return turnvalue; } set { turnvalue = value; if (turnvalue >= 360f) turnvalue = 0.0f; } }
    void LateUpdate() {
        if (rotatesky) {
            turnval += Time.deltaTime * rotatespeed;
            rotationvalue = new Vector3(Camera.main.transform.rotation.eulerAngles.x + turnval, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Euler(rotationvalue);
        } else {
            rotationvalue = new Vector3(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Euler(rotationvalue);
        }
    }
}