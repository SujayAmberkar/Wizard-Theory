using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D RedBall;
    public float ballSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            fireBall();
        }
    }

     
    
    void fireBall(){
        Rigidbody2D p;
        float pdir = Mathf.Sign(transform.localScale.x);
        p = Instantiate(RedBall,transform.position  + new Vector3(0.8f*pdir,0,0),Quaternion.identity);
        p.velocity = transform.right * ballSpeed * Time.deltaTime* Mathf.Sign(transform.localScale.x);
        
    }
}
