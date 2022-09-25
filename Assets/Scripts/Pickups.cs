using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    [SerializeField] ParticleSystem ps;
    public SpriteRenderer sr;
    bool once = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player" && once){
            once = false;
            var em = ps.emission;
            var dur = ps.main.duration;
            em.enabled=true;
            ps.Play();
            Destroy(sr);
            Invoke(nameof(DestroyFeather),dur);
            Destroy(gameObject,dur);
        }
    }

    void DestroyFeather(){
        Destroy(gameObject);
    }
}
