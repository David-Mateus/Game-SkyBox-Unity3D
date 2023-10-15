using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) 
    {
        //Destruir ao tocar no solo
        Destroy(gameObject);
    }
}
