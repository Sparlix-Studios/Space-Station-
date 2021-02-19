using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSnapping : MonoBehaviour
{
    [SerializeField] GameObject player;
    FirstPersonBuild fpb;

    [SerializeField] GameObject obj;
    [SerializeField] GameObject attach;

    [SerializeField] [Range(0, 10)] int gridSize;

    private void Start() {
        fpb = player.GetComponent<FirstPersonBuild>();
        
    }

    private void Update() {
        obj = GameObject.Find("Selected");

        //if (fpb.buildMode && fpb.selectedObj != null) {
        //   snapToGrid();
        //}
        snapToGrid();
    }

    private void snapToGrid() {
        obj.transform.position = attach.transform.position;
        //obj.transform.position = new Vector3 (
        //    GetGridPos().x * gridSize,
        //    GetGridPos().y * gridSize,
        //    GetGridPos().z * gridSize
        //    );         
    }

    private Vector3Int GetGridPos() {
        return new Vector3Int(
            Mathf.RoundToInt(attach.transform.position.x / gridSize),
            Mathf.RoundToInt(attach.transform.position.y / gridSize),
            Mathf.RoundToInt(attach.transform.position.z / gridSize)
            );
    }
    private void OnCollisionEnter(Collision collision) {
    }
}
