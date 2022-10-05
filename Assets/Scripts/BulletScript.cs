using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D fb;
    void Start()
    {
        fb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
