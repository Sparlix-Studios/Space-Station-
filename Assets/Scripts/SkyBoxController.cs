using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxController : MonoBehaviour
{
    //[SerializeField] bool rotateSky = false;
    //public bool speedUp = false;
    //public float rotateSpeed = 1.0f;

    //Vector3 originalCamAngle;
    //Camera thisCam;
    //private void Start() {
    //    //Camera.main.fieldOfView = 60f;
    //    //thisCam = GetComponent<Camera>();
    //    originalCamAngle = new Vector3(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
    //}
    //private void Update() {
    //    GetInput();
    //    //hyperSpace();
    //    if (!rotateSky) {
    //        transform.Rotate(originalCamAngle.x, originalCamAngle.y, originalCamAngle.z);
    //    }
    //}

    ////private void hyperspace() {
    ////    if (speedup) {
    ////        if (thiscam.fieldofview < 179f)
    ////            thiscam.fieldofview++;
    ////        if (thiscam.fieldofview == 179)
    ////            rotatespeed = 6;
    ////    } else {
    ////        if (thiscam.fieldofview > 60f)
    ////            thiscam.fieldofview--;
    ////        if (thiscam.fieldofview == 179)
    ////            rotatespeed = 1;
    ////    }
    ////}

    //private void GetInput() {
    //    if (Input.GetKeyDown(KeyCode.O)) {
    //        speedUp = !speedUp;
    //    }
    //}

    //private Vector3 rotationValue; private float turnValue = 0.0f; private float turnVal { get { return turnValue; } set { turnValue = value; if (turnValue >= 360f) turnValue = 0.0f; } }
    //void LateUpdate() {
    //    if (rotateSky) {
    //        turnVal += Time.deltaTime * rotateSpeed;
    //        rotationValue = new Vector3(Camera.main.transform.rotation.eulerAngles.x + turnVal, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
    //        transform.rotation = Quaternion.Euler(rotationValue);
    //    } else {
    //        //rotationValue = new Vector3(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
    //        transform.rotation = Quaternion.Euler(rotationValue);
    //    }
    //}
}