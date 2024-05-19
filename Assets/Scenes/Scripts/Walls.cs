using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public int count;
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Food")){
            count = 1;
        }
    }
}
