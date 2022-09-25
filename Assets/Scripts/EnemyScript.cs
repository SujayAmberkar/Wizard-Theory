using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] ParticleSystem enemyPS;
    public SpriteRenderer sr;
    bool once = true;
    // public Rigidbody2D greenFeather;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyDeath();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "bullet"){
            health = health - 30;
        }
    }

    void enemyDeath(){
        if(health<=0 && once){
            var em = enemyPS.emission;
            var dur = enemyPS.main.duration;
            em.enabled = true;
            enemyPS.Play();
            Invoke(nameof(pickupInst),1);
            Destroy(sr);
            Invoke(nameof(DestroyObj),dur);
            Destroy(gameObject,dur);
        }
    }

    void DestroyObj(){
        Destroy(gameObject);
    }
    void pickupInst(){
        // Instantiate(greenFeather,transform.position,transform.rotation);
    }
}
