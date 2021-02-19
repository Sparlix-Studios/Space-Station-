using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxController : MonoBehaviour
{
    public bool speedup = false;
    public float rotatespeed = 1.0f;

    public Camera MainCamera;
    public Camera SkyCamera;
    public Vector3 SkyBoxRotation;
    void Update() {
        SkyCamera.transform.position = MainCamera.transform.position;
        SkyCamera.transform.rotation = MainCamera.transform.rotation;
        SkyCamera.transform.Rotate(SkyBoxRotation);
    }

    private void OnMouseDown() {
    }

private Vector3 rotationvalue; private float turnvalue = 0.0f; private float turnval { get { return turnvalue; } set { turnvalue = value; if (turnvalue >= 360f) turnvalue = 0.0f; } }
    void LateUpdate() {
        turnval += Time.deltaTime * rotatespeed;
        rotationvalue = new Vector3(Camera.main.transform.rotation.eulerAngles.x + turnval, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(rotationvalue);
    }
}