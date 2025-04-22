using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Camera[] cameras;
    public Material[] cameraMats;
    public GameObject[] portalPlanes;

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
                //portalPlanes[i].GetComponent<Renderer>().enabled = false;
                portalPlanes[i].SetActive(false);
            }
        }
    }

    public void ChangeActivePortal(int activePortal)
    {
        //Debug.Log("Code gets called");
        for (int i = 0; i < 4; i++)
        {
            if (i == activePortal)
            {
                portalPlanes[i].SetActive(true);
            }
            else
            {
                portalPlanes[i].SetActive(false);
            }
        }
    }
}
