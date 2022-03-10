using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawn : MonoBehaviour
{
    public GameObject[] targetPrefab;
    // List<GameObject> Target = new List<GameObject>();
    
    private float spawnRangeX;
    private float spawnRangeXx;
    private float spawnPosZ;
    private float spawnPosZz;
    private float startDelay = 2;
    private float spawnInterval = 4f;


    public float timeValue;
    public Text timerText;
    // public PlayerController bool winMap1;
    public bool winMap;
    // public GameObject winMap1;

    // Start is called before the first frame update
    void Start()
    {


        // for (int i = 0; i < number; i++)
        // {
        //         InvokeRepeating("SpawnRandomTarget", startDelay, spawnInterval);
        //         SpawnRandomTarget();

        // }
        // if (targetPrefab.Length < number)
        // {
        InvokeRepeating("SpawnRandomTarget", startDelay, spawnInterval);
        // SpawnRandomTarget();   
        // }else
        winMap =  false;


    }


    // Update is called once per frame
    public void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            winMap = true;
            CancelInvoke();

        }
        DisplayTime(timeValue);

    }

    void SpawnRandomTarget()
    {
        spawnRangeX = Random.Range(-35, -68);
        spawnRangeXx = Random.Range(35, 68);
        spawnPosZ = Random.Range(-20, -48);
        spawnPosZz = Random.Range(20, 48);

        int targetIndex = Random.Range(0, targetPrefab.Length);
        Vector3 randomSpawn = new Vector3(Random.Range(spawnRangeX, spawnRangeXx), 10, Random.Range(spawnPosZ, spawnPosZz));

        Instantiate(targetPrefab[targetIndex], randomSpawn, Quaternion.identity);

    }
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
