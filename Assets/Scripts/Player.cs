using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forceMultiplier = 6f;
    public float maximumVelocity = 4f;
    private Rigidbody rb;
    
    /// Awake is called when the script instance is being loaded.
    
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        //Desabilitar o VSync e setar o frame rate para 60
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
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
            rb.AddForce(new Vector3(horizontalInput * forceMultiplier * Time.deltaTime, 0 , 0));
        }
        
    }
    //Para colisão com o objeto
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Hazard"){
            GameManager.GameOver();
            Destroy(gameObject);
        }
    }
}
