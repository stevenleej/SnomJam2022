using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckManager : MonoBehaviour
{
    private TruckMovement truckMovement;
    // Start is called before the first frame update
    void Start()
    {
        truckMovement = GetComponent<TruckMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        truckMovement.LoopPlayerMovement();
        
    }
}
