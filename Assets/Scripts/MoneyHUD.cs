using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHUD : MonoBehaviour
{
    SaveData sd;
    Text txt;

    private void Start() {
        sd = GetComponent<SaveData>();
        txt = GetComponent<Text>();
    }

    private void Update() {
        txt.text = "$"+sd.money.ToString();
    }
}
