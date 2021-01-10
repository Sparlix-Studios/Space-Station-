using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudController : MonoBehaviour
{
    [SerializeField] GameObject money;

    Text moneyText;

    

    private void Start() {
        moneyText = money.GetComponent<Text>();
    }
}
