using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool buildModeOn = true;
    public void buildModeToggle() {
        buildModeOn = !buildModeOn;
    }
}
