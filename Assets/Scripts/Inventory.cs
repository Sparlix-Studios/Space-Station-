using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{   
    public Sprite item0;

    List<string> itemID = new List<string>();

    List<string> Inv = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkInv();
    }

    private void checkInv() {
        foreach(string i in Inv) {

        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Give") {
            addItem(0);
        }
    }

    private void addItem(int itemInt) {
        string item = itemID[itemInt];

        
    }
}
