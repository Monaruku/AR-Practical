using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ButtonTest : MonoBehaviour
{

    public TMP_Text text;


    public void ClickButton()
    {
        text.text = "You clicked me";
    }
}