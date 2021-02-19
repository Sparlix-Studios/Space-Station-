using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public bool onUI;
    public GameObject itemSlots;

    OverUI ui;
    void Update()
    {
        ui = itemSlots.GetComponent<OverUI>();

        if(ui.overUI) {
            print("over");
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        } else {
            print("off");
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
