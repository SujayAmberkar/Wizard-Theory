using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolAi : MonoBehaviour
{
    public float speed;
    public float distance = 2f;
    public Transform groundDetection;
    private bool moveRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol(){
        transform.Translate(Vector2.right*speed*Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,distance);
        if(groundInfo.collider==false){
            if(moveRight==true){
                transform.eulerAngles = new Vector3(0,-180,0);
                moveRight=false;
            }else{
                transform.eulerAngles = new Vector3(0,0,0);
                moveRight = true;
            }
        }
    }

    void attack(){
        
    }
}
