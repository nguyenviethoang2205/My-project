using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFish : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject spawn;
    [SerializeField] SpawnBigFish spawnBigFish;
    bool facingRight;
    [SerializeField] private float previousX;
    private void Start() {
        
    }
    // Update is called once per frame
    void Update()
    {
        // spawn = GameObject.FindGameObjectWithTag("Spawn");
        spawnBigFish = spawn.GetComponent<SpawnBigFish>();
        checkFlip();

    }

    private void OnTriggerExit2D(Collider2D other) {
        if(spawnBigFish.isSpawnLeft == 1 && other.gameObject.tag == "RightSpawn"){
            Destroy(gameObject);
            spawnBigFish.isSpawn = false;
        }
        else if (spawnBigFish.isSpawnLeft == 2 && other.gameObject.tag == "LeftSpawn"){
            Destroy(gameObject);
            spawnBigFish.isSpawn = false;
        }
    }
    

    

    private void checkFlip(){
        float currentX = transform.position.x; 

        //Position x tăng - sang phải
        if (previousX < currentX)
        {
            if(facingRight){
                Flip();
            }
            
            previousX = currentX;
        }
        //Posiotion x giảm - sang trái 
        else if (previousX > currentX)
        {
            if(!facingRight){
                Flip();
            }
            previousX = currentX;
        }
    }

    private void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
