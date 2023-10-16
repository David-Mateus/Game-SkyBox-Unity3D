using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    Vector3 rotation;
    private void Start() 
    {
        //Rotacionar o objeto
        var xRotation = Random.Range(0.5f, 1f);
        rotation = new Vector3(-xRotation, 0);
    }
    private void Update() 
    {
        //Rotacionar o objeto
        transform.Rotate(rotation);
    }
    private void OnCollisionEnter(Collision collision) 
    {
        //Destruir ao tocar no solo
        if(!collision.gameObject.CompareTag("Hazard")){
            Destroy(gameObject);
        }
        
    }
}
