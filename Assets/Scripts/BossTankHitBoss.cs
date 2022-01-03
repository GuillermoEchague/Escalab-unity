using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankHitBoss : MonoBehaviour
{
    public BossTankController bossCont;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && playerController.instance.transform.position.y > transform.position.y)
        {
            bossCont.TakeHit();
            playerController.instance.Bounce();
            gameObject.SetActive(false);
        }
    }
}
