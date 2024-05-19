using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.UI;

public class MoveToFood : Agent
{
    [SerializeField] private Transform target;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private Transform env;
    [SerializeField] private Walls spawn;
    public float point;
    [SerializeField] Text pointText;
    bool actionTaken = false;
    [SerializeField] Academy academy;
    private void Start() {
        point = 10f;
    }
    private void FixedUpdate() {
        AddReward(-1/MaxStep);
        // point -= 1f * Time.fixedDeltaTime;
        // pointText.text = "Point: " + (int) point;
    }

    private void Update()
    {
        if (spawn.count == 1)
        { //test4
            AddReward(-0.1f);
            spawn.count = 0;
            EndEpisode();
        }
        
        
    }
    
    public override void OnEpisodeBegin()
    {
        // transform.localPosition = new Vector3(0, 0);    //test1
        // transform.localPosition = new Vector3(Random.Range(-5.5f,5.5f),Random.Range(-3.5f,3.5f));    //test3
        //test3 not reset position
        // target.localPosition = new Vector3(Random.Range(-5.5f,5.5f),Random.Range(-3.5f,3.5f));  
        // target.localPosition = new Vector3(Random.Range(-5.5f, 5.5f), Random.Range(0f, 3.5f));  //test5
        // env.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360f)); //special test
        // transform.rotation = Quaternion.identity;

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation((Vector2)transform.localPosition);
    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveY = actions.ContinuousActions[1];
        float moveSpeed = actions.ContinuousActions[2];
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
            AddReward(0.5f);
            point += 1;
            EndEpisode();
        }
        // else if (collision2D.gameObject.tag == "Wall")
        // { 
        //     AddReward(-1f);
        //     EndEpisode();
        // }

        if (collision2D.gameObject.tag == "BigFish")
        {
            AddReward(-1f);
            EndEpisode();
            point -= 5;
        }


    }


    
}
