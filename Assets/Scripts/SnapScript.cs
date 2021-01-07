using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnapScript : MonoBehaviour
{
    [SerializeField] int gridSize = 5;
    [SerializeField] [Range(0, 100)] int snapDist;


    public bool isSnapped = false;
    private void Update() {
        snapToGrid();
    }

    private void snapToGrid() {
        transform.position = new Vector3(
            GetGridPos().x * gridSize,
            GetGridPos().y * gridSize,
            GetGridPos().z * gridSize
            );
        ;
        ;
    }

    private Vector3Int GetGridPos() {
        return new Vector3Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.y / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
        ;
    }

    private void OnMouseDrag() {
        TransformObj();

        SnapToObj();
    }

    private void TransformObj() {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                    Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
        newPos.z = transform.position.z;

        transform.position = newPos;
    }

    private void SnapToObj() {
        Vector3 rayDir = transform.position - Camera.main.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, rayDir, out hit, snapDist)) {

            Debug.DrawRay(Camera.main.transform.position, rayDir * hit.distance, Color.green);
            isSnapped = false;


            if (hit.collider.name == "Cube") {
                Debug.DrawRay(Camera.main.transform.position, rayDir * hit.distance, Color.blue);
                Vector3 normal = hit.normal;
                normal = hit.transform.TransformDirection(normal);
                if (normal == hit.transform.up) {
                    transform.position = new Vector3(
                        hit.collider.transform.position.x,
                        hit.collider.transform.position.y + 1,
                        hit.collider.transform.position.z
                    );
                    ;
                }
                if (normal == -hit.transform.up) {
                    transform.position = new Vector3(
                        hit.collider.transform.position.x,
                        hit.collider.transform.position.y - 1,
                        hit.collider.transform.position.z
                    );
                    ;
                }
                if (normal == hit.transform.right) {
                    transform.position = new Vector3(
                        hit.collider.transform.position.x + 1,
                        hit.collider.transform.position.y,
                        hit.collider.transform.position.z
                    );
                    ;
                }
                if (normal == -hit.transform.right) {
                    transform.position = new Vector3(
                        hit.collider.transform.position.x - 1,
                        hit.collider.transform.position.y,
                        hit.collider.transform.position.z
                    );
                    ;
                }
                if (normal == hit.transform.forward) {
                    transform.position = new Vector3(
                        hit.collider.transform.position.x,
                        hit.collider.transform.position.y,
                        hit.collider.transform.position.z + 1
                    );
                    ;
                }
                if (normal == -hit.transform.forward) {
                    transform.position = new Vector3(
                        hit.collider.transform.position.x,
                        hit.collider.transform.position.y,
                        hit.collider.transform.position.z - 1
                    );
                    ;
                }
                isSnapped = true;
            }

        } else {
            Debug.DrawRay(Camera.main.transform.position, rayDir * snapDist, Color.red);
            isSnapped = false;
        }

        if (isSnapped) {
            transform.position = Camera.main.transform.position - transform.position/2;
            isSnapped = false;
        }


    }
}
