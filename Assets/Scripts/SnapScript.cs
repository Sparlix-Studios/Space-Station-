using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnapScript : MonoBehaviour
{
    [SerializeField] int gridSize = 5;

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
}
