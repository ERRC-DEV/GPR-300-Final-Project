using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script written by Ethan Chevalier

public class PortalPlaneScript : MonoBehaviour
{
    [SerializeField] DimensionalManagerScript managerScript;
    [SerializeField] PortalManager portalManagerScript;
    [SerializeField] DimensionalStabilizerScript stabilizerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 portalToPlayer = other.transform.position - transform.position;
        float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
        if (dotProduct > 0.0f)
        {
            managerScript.TransferPlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        portalManagerScript.ChangeActivePortal(stabilizerScript.activePlayer);
    }
}
