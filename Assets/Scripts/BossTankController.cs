using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankController : MonoBehaviour
{
    public enum bossStates { shooting, hurt, moving};
    public bossStates currentStates;

    public Transform theBoss;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool moveRight;
    
    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;



    // Start is called before the first frame update
    void Start()
    {
        currentStates = bossStates.shooting;
    }

    // Update is called once per frame
    void Update()
    {
       switch (currentStates) {
           case bossStates.shooting:
               
               break;
           
           case bossStates.hurt:
               if(hurtCounter > 0){
                   hurtCounter -= Time.deltaTime;
                   if(hurtCounter <=0)
                   {
                       currentStates = bossStates.moving;
                   }
               }
               break;

            case bossStates.moving:
               theBoss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
               if(theBoss.position.x > rightPoint.position.x){
                   theBoss.localScale = Vector3.one;
                   moveRight = false;
                   
                   EndMovement(); 
               } else {
                   theBoss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                if(theBoss.position.x < leftPoint.position.x){
                   theBoss.localScale = new Vector3(-1f,1f,1f);
                   moveRight = true;
                   
                   EndMovement(); 
               }
               }
               break;
           
           default :
               
               break;
       }
    }

    public void TakeHit() {
        currentStates = bossStates.hurt;
        hurtCounter = hurtTime;

        anim.SetTrigger("Hit");
    }

    private void EndMovement()
    {
        currentStates = bossStates.shooting;
        shotCounter = timeBetweenShots;
        anim.SetTrigger("StopMoving");
    }
}
