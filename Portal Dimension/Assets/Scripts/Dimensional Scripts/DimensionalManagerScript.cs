using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DimensionalManagerScript : MonoBehaviour
{
    [SerializeField] DimensionalStabilizerScript stabilizerScript;
    [SerializeField] PortalManager portalManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TransferPlayer();
        }
    }

    public void TransferPlayer()
    {
            float prevRotation = stabilizerScript.AllPlayers[stabilizerScript.activePlayer].GetComponent<First_Person_Movement>().xRotation;
            stabilizerScript.IncrementActivePlayer();

            for (int i = 0; i < stabilizerScript.AllPlayers.Length; i++)
            {
                if (i == stabilizerScript.activePlayer)
                {
                    ActivatePlayer(stabilizerScript.AllPlayers[i], prevRotation);
                }
                else
                {
                    if (stabilizerScript.AllPlayers[i].GetComponent<First_Person_Movement>() != null)
                    {
                        DisablePlayer(stabilizerScript.AllPlayers[i]);
                    }
                }
            }
    }
    void DisablePlayer(GameObject player)
    {
        player.transform.GetChild(0).gameObject.GetComponent<Camera>().depth = -1;
        Destroy(player.GetComponent<First_Person_Movement>());
        

    }

    void ActivatePlayer(GameObject player, float prevRot)
    {
        player.transform.GetChild(0).gameObject.GetComponent<Camera>().depth = 1;
        First_Person_Movement newControlScript = player.AddComponent<First_Person_Movement>();

        // Essentials
        newControlScript.PlayerCamera = player.transform.GetChild(0).gameObject.transform;
        newControlScript.Controller = player.GetComponent<CharacterController>();
        newControlScript.Player = player.transform;
        newControlScript.xRotation = prevRot;

        // Config
        newControlScript.Speed = 5.0f;
        newControlScript.JumpForce = 7.5f;
        newControlScript.Sensetivity = 1.5f;
        newControlScript.Gravity = 9.81f;
        newControlScript.SneakSpeed = 2.5f;
    }
}
