using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // [SerializeField] private float moveSpeed = 0f;
    Rigidbody2D rb;
    Collider2D cl;
    [SerializeField] private SpriteRenderer spriteRenderer;
    bool facingRight;
    private float previousX;
    GameObject zone;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cl = gameObject.GetComponent<Collider2D>();
        zone = GameObject.Find("background");
        spriteRenderer = zone.GetComponent<SpriteRenderer>();
        previousX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        checkFlip();
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
