using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealth : MonoBehaviour
{
    float timer = 0f;   //keeps track of time
    public float maxTime = 20f; //max time between hp item spawns
    public float minTime = 5f;  //min time between hp item spawns
    public float radius = 16f;  //radius where hp items can spawn from centre of arena
    public GameObject healthPrefab; //reference to hp item prefab

    // Start is called before the first frame update
    void Start()
    {
        //set timer to random time
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        //when timer reaches 0, spawn an hp item and set timer to a new random time
        timer -= Time.deltaTime;
        if(timer <= 0){
            Instantiate(healthPrefab, new Vector3(Random.Range(-radius, radius),2f , Random.Range(-radius,radius)), Quaternion.identity);
            timer = Random.Range(minTime, maxTime);
        }
    }
}
