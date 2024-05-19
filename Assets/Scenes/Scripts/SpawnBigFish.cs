using Unity.Collections;
using UnityEngine;

public class SpawnBigFish : MonoBehaviour
{
    [SerializeField] private GameObject bigFish;
    [SerializeField] private GameObject tmpBigFish;
    [SerializeField] private Transform leftSpawn;
    [SerializeField] private Transform rightSpawn;
    [SerializeField] private Transform parent;
    public bool isSpawn = false;
    [SerializeField] private float speed = 0f;
    public int isSpawnLeft; // 1 = left, 2 = right

    [System.Obsolete]
    void Start()
    {
        
        // leftSpawn = GameObject.FindGameObjectWithTag("LeftSpawn");
        // rightSpawn = GameObject.FindGameObjectWithTag("RightSpawn");
        parent = this.gameObject.GetComponent<Transform>();
        leftSpawn = parent.FindChild("LeftSpawn");
        rightSpawn = parent.FindChild("RightSpawn");
    }

    void Update()
    {
        if (!isSpawn)
        {
            LogicSpawn();
        }

        switch (isSpawnLeft)
        {
            case 1:
                tmpBigFish.transform.position += transform.right * speed * Time.deltaTime;
                break;
            case 2:
                tmpBigFish.transform.position -= transform.right * speed * Time.deltaTime;
                break;
        }
    }

    private void SpawnBFish()
    {
        float x = parent.transform.position.x;
        float y = parent.transform.position.y;
        tmpBigFish = Instantiate(bigFish, new Vector3(x, Random.Range(y - 2, y + 2), 0), Quaternion.identity) as GameObject;
        tmpBigFish.SetActive(true);
    }

    private void LogicSpawn()
    {
        int randomSpawn = Random.Range(1, 3);
        if (randomSpawn == 1)
        {
            isSpawn = true;
            isSpawnLeft = 1;
            parent = leftSpawn;
            SpawnBFish();
        }
        else if (randomSpawn == 2)
        {
            isSpawn = true;
            isSpawnLeft = 2;
            parent = rightSpawn;
            SpawnBFish();
        }
    }
}
