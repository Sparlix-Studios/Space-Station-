using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TempDebugScript : MonoBehaviour
{
    WorldGen worldGen;

    private void Start() {
        worldGen = GetComponent<WorldGen>();
    }
    private void Update() {
        Debug.DrawRay(transform.position, transform.forward*worldGen.dist, Color.green);
    }
}
