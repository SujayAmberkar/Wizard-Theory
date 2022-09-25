using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Rigidbody2D fb;
    void Start()
    {
        fb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void rangeDestroy(){
        float dist = Vector2.Distance(player.transform.position,fb.transform.position);
        if(dist>4){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
