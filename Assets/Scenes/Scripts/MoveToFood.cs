using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.UIElements;

public class MoveToFood : Agent
{
    [SerializeField] private Transform target;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private Transform env;
    [SerializeField] private Walls spawn;
    [SerializeField] private float hunger;
    [SerializeField] private float moveSpeed =3.5f;
    public float point;
    // [SerializeField] TextField pointText;
    // bool actionTaken = false;
    private void Start() {
        // point = 10f;
    }
    private void FixedUpdate() {
        
        // Bắt đầu phạt khi độ đói dưới 70 %
        if(hunger <= 70f)
            AddReward(-1/MaxStep);
        hunger -=2f * Time.fixedDeltaTime;
        // point -= 1f * Time.fixedDeltaTime;
        // pointText.text = "Point: " + (int) point;
    }

    // private void Update()
    // {
    //     if (spawn.count == 1)
    //     { 
    //         spawn.count = 0;
    //         // if (hunger <= 65f/100*MaxStep)
    //         AddReward(-0.1f);
    //         EndEpisode();
    //     }
    // }
    
    public override void OnEpisodeBegin()
    {
        // hunger = 100;
        hunger = Random.Range(50,100);
        transform.localPosition = new Vector3(0, 0);    //test1
        transform.localPosition = new Vector3(Random.Range(-5.5f,5.5f),Random.Range(-3.5f,3.5f));    //test3
        //test3 not reset position
        // target.localPosition = new Vector3(Random.Range(-5.5f,5.5f),Random.Range(-3.5f,3.5f));  
        // target.localPosition = new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(0f, 3.5f));  //test5
        // env.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360f)); //special test
        // transform.rotation = Quaternion.identity;

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(hunger);
        sensor.AddObservation((Vector2)transform.localPosition);
    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveY = actions.ContinuousActions[1];
        transform.localPosition += new Vector3(moveX, moveY) * Time.deltaTime * moveSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> countinousActions = actionsOut.ContinuousActions;
        countinousActions[0] = Input.GetAxisRaw("Horizontal");
        countinousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Food")
        {
            if (hunger > 70f)
            {
                AddReward(-0.5f);
                // point -= 1;
                background.color = Color.cyan;
            }
            else
            {
                AddReward(0.5f);
                // point += 1;
                background.color = Color.green;
            }
            // AddReward(1f);
            // //     // point += 1;
            // background.color = Color.green;
            hunger+=10;
            EndEpisode();
        }
        else if (collision2D.gameObject.tag == "Wall")
        { 
            AddReward(-1f);
            background.color = Color.red;
            EndEpisode();
        }


    }


    
}
