using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour
{
    NavMeshAgent nav;
    public float dashTime = 1;
    public float speed = 12;
    public float dashSpeed = 30;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Vertical"),0f,-Input.GetAxis("Horizontal"));
        Vector3 destination = transform.position + input;
        nav.SetDestination(destination);

        timer -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && timer <= 0)
        {
            timer = dashTime;
            nav.speed = dashSpeed;
        }

        if(timer > 0)
        {
            transform.rotation = Quaternion.Euler(360f / (timer / dashTime + 1),transform.eulerAngles.y,transform.eulerAngles.z);
        }
        else if(timer > -1)
        {
            timer = -2;
            nav.speed = speed;
        }
    }
}
