using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject playButton;

    private void Update()
    {
        if (UDPReceiver.hasData)
        {
            playButton.SetActive(false);
        }
        else
        {
            playButton.SetActive(true);
        }
    }
}
