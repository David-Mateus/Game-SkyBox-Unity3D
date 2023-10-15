using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float maximumVelocity = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //variavel criada para movimentação x
        var horizontalInput = Input.GetAxis("Horizontal");
        if(GetComponent<Rigidbody>().velocity.magnitude <= maximumVelocity){
            GetComponent<Rigidbody>().AddForce(new Vector3(horizontalInput * forceMultiplier, 0 , 0));
        }
        
    }
    //Para colisão com o objeto
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Hazard"){
            Destroy(gameObject);
        }
    }
}
