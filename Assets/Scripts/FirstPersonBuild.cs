using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonBuild : MonoBehaviour
{

    public bool buildMode;
    public bool obstacle;
    [SerializeField] [Range(0, 20)] float reachDistance = 10f;

    public GameObject item;
    public GameObject ship;
    public GameObject camObj;
    public GameObject player;
    
    RaycastHit hit;
    public GameObject selectedObj;

    bool instantiated = false;
    bool hitObj = false;
    private void Update() {

        if (buildMode && !instantiated) {
            selectedObj = Instantiate(item, null, true);
            selectedObj.transform.rotation = Quaternion.identity;
            selectedObj.name = "Selected";
            foreach (MeshCollider child in selectedObj.GetComponentsInChildren<MeshCollider>()) {
                child.enabled = false;
            }
            instantiated = true;
        }

        if (buildMode) {

            if(selectedObj != null)
                findObstacle();

            if (Input.GetMouseButtonDown(0) && selectedObj != null) {
                foreach (MeshCollider child in selectedObj.GetComponentsInChildren<MeshCollider>()) {
                    //child.enabled = true;
                }
                //selectedObj.name = "NewObj";
                //selectedObj = null;

            }

            if (hitObj && selectedObj != null) {
                //float y = hit.point.y + (selectedObj.transform.localScale.y / 2f);
                //Vector3 pos = new Vector3(hit.point.x, y, hit.point.z);
                //selectedObj.transform.position = pos;
            }
        }

        //if build mode off, delete selected gameobject

        if (Input.GetKeyDown(KeyCode.R))
            buildMode = !buildMode;

    }

    private void findObstacle() {

        if (Physics.Raycast(camObj.transform.position, camObj.transform.forward, out hit, reachDistance)) {

            hitObj = true;
            
            Debug.DrawRay(camObj.transform.position, camObj.transform.forward * hit.distance, Color.red);
        } else {

            hitObj = false;
            Debug.DrawRay(camObj.transform.position, camObj.transform.forward * reachDistance, Color.green);
        }
    }
}