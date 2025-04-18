using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionalStabilizerScript : MonoBehaviour
{
    public int activePlayer;
    public GameObject[] AllPlayers;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (activePlayer)
        {
            case 0:
                AllPlayers[1].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(0, 0, -50.0f);
                AllPlayers[2].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(-50.0f,0,-50.0f);
                AllPlayers[3].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(-50.0f, 0,0);
                break;
            case 1:
                AllPlayers[0].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(0, 0, 50.0f);
                AllPlayers[2].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(-50.0f, 0, 0);
                AllPlayers[3].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(-50.0f, 0, 50.0f);
                break;
            case 2:
                AllPlayers[0].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(50.0f, 0, 50.0f);
                AllPlayers[1].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(50.0f, 0, 0);
                AllPlayers[3].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(0, 0, 50.0f);
                break;
            case 3:
                AllPlayers[0].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(50.0f, 0, 0);
                AllPlayers[1].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(50.0f, 0, -50.0f);
                AllPlayers[2].transform.position = AllPlayers[activePlayer].transform.position + new Vector3(0, 0, -50.0f);
                break;
        }

        if (activePlayer == 1)
        {
            Debug.Log("Testing");
        }

        for (int i = 0; i < AllPlayers.Length; i++)
        {
            if (i != activePlayer)
            {
                AllPlayers[i].transform.rotation = AllPlayers[activePlayer].transform.rotation;
            }
        }

        for (int i = 0; i < AllPlayers.Length; i++)
        {
            if (i != activePlayer)
            {
                GameObject altCamera = AllPlayers[i].transform.GetChild(0).gameObject;
                GameObject playerCamera = AllPlayers[activePlayer].transform.GetChild(0).gameObject;
                altCamera.transform.rotation = playerCamera.transform.rotation;
            }
        }

    }

    public void IncrementActivePlayer()
    {
        
        if (activePlayer == 3)
        {
            activePlayer = 0;
        }
        else
        {
            activePlayer += 1;
        }
    }
}
