using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Camera[] cameras;
    public Material[] cameraMats;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (cameras[i].targetTexture != null)
            {
                cameras[i].targetTexture.Release();
            }
            cameras[i].targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            cameraMats[i].mainTexture = cameras[i].targetTexture;

            if (i != 0)
            {
                //cameraMats[i].
            }
        }
    }

    void ChangeActivePortal()
    {

    }
}
