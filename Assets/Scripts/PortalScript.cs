using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{

    public GameObject ExitPortal;
    Rigidbody2D EntryPortal;
    // Start is called before the first frame update
    void Start()
    {
        EntryPortal = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            other.gameObject.transform.position = ExitPortal.transform.position + new Vector3(1,1,0);
        }   
    }
}
