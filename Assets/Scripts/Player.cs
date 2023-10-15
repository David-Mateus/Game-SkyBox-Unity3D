using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 3f;
    public float maximumVelocity = 3f;
    private Rigidbody rb;
    // Start is called before the first frame update
    // refatoração com caching
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //variavel criada para movimentação x
        var horizontalInput = Input.GetAxis("Horizontal");
        if(rb.velocity.magnitude <= maximumVelocity){
            rb.AddForce(new Vector3(horizontalInput * forceMultiplier, 0 , 0));
        }
        
    }
    //Para colisão com o objeto
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Hazard"){
            Destroy(gameObject);
        }
    }
}
