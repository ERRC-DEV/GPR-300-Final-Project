using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionalStabilizerScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] AlternateModels;
    GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = player.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        AlternateModels[0].transform.position = player.transform.position + new Vector3(0,0,-50.0f);
        AlternateModels[1].transform.position = player.transform.position + new Vector3(-50.0f,0,-50.0f);
        AlternateModels[2].transform.position = player.transform.position + new Vector3(-50.0f, 0,0);

        for (int i = 0; i < AlternateModels.Length; i++)
        {
            AlternateModels[i].transform.rotation = player.transform.rotation;
        }

        for (int i = 0; i < AlternateModels.Length; i++)
        {
            GameObject altCamera = AlternateModels[i].transform.GetChild(0).gameObject;
            altCamera.transform.rotation = playerCamera.transform.rotation;
        }

    }
}
