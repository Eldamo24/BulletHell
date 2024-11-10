using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextButtonsColor : MonoBehaviour
{

    public void OnMouseOver()
    {
        TMP_Text text = GetComponentInChildren<TMP_Text>();
        text.color = Color.red;
        UIController.instance.SetCursorOver();
    }

    public void OnMouseExit()
    {
        TMP_Text text = GetComponentInChildren<TMP_Text>();
        text.color = Color.white;
        UIController.instance.SetCursorExit();
    }
}
