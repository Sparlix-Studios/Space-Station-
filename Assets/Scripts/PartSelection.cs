using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSelection : MonoBehaviour
{
    [SerializeField] GameObject particles;

    public bool isSelected = false;
    
    Renderer r;
    Material mat;
    Color startColor;
    SnapScript snapScript;

    private void Start() {
        r = gameObject.GetComponent<Renderer>();
        snapScript = GetComponent<SnapScript>();

        mat = r.material;
        startColor = r.material.color;
    }
    private void Update() {
        if (snapScript.buildMode) {
            if (isSelected) {
                selectObject();
            } else {
                deselectObject();
            }
        }
    }

    private void deselectObject() {
        mat.color = startColor;
        particles.SetActive(false);
        mat.DisableKeyword("_EMISSION");
    }

    private void selectObject() {
        mat.color = new Color(0f, 253f, 239f, 0f);
        mat.EnableKeyword("_EMISSION");
        particles.SetActive(true);
    }
}
