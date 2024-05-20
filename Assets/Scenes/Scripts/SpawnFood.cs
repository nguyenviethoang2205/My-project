using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnFood : MonoBehaviour
{
    public GameObject food;
    [SerializeField] private float time = 0f;
    [SerializeField] private Transform pointA;
    private float leftPos;
    private float rightPos;
    private float spawnPos;

    void Start()
    {
        pointA = this.gameObject.GetComponent<Transform>();
        spawnPos = pointA.position.y;
        leftPos = pointA.position.x + 6f;
        rightPos = pointA.position.x - 6f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 5)
        {      
            Invoke("SpawnF", 0f);
            Invoke("SpawnF", 0.5f);
            Invoke("SpawnF", 1f);
            Invoke("SpawnF", 1.5f);
            Invoke("SpawnF", 2f);
            time = 0f;
        }


    }

    private void SpawnF()
    {
        Instantiate(Resources.Load("Food"), new Vector3(Random.Range(leftPos,rightPos), spawnPos, 0), Quaternion.identity);
    }

}
