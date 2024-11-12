using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextButtonsColor : MonoBehaviour
{

    public AudioClip buttonSound;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
    }

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

    public void ClickButton()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}
