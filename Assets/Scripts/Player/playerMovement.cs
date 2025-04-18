using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    NavMeshAgent nav;   //reference to the nav agent
    public float dashTime = 1;  //how long the player can dash
    public float speed = 12;    //how fast the player is
    public float dashSpeed = 30;    //how fast the dash is
    float timer;    //keeps track of time
    public Slider healthbar;    //reference to hp bar
    float hp;   //player hp
    public float maxhp = 100;   //maximum hp
    public float damageTakenPerHit = 10;    //how much damage one hit does to the player
    public Animator sword;  //animator for the sword swing

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>(); //get nav agent
        hp = maxhp; // set hp to max
    }

    // Update is called once per frame
    void Update()
    {
        //get input and set destination
        Vector3 input = new Vector3(Input.GetAxis("Vertical"),0f,-Input.GetAxis("Horizontal"));
        Vector3 destination = transform.position + input;
        nav.SetDestination(destination);

        //if the cooldown isn't active and the player presses space, start dash
        timer -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && timer <= 0)
        {
            timer = dashTime;
            nav.speed = dashSpeed;
        }

        //if the player presses enter and the cooldown isn't active, play sword swing animation
        sword.SetBool("play",false);
        if(Input.GetKeyDown(KeyCode.Return) && timer <= 0){
            sword.SetBool("play",true);
        }

        //if the dash is active, do a spin
        if(timer > 0)
        {
            transform.rotation = Quaternion.Euler(360f / (timer / dashTime + 1),transform.eulerAngles.y,transform.eulerAngles.z);
        }
        //once the dash ends, reset the speed
        else if(timer > -1)
        {
            timer = -2;
            nav.speed = speed;
        }

        //if hp < 0 destroy player
        if(hp <= 0){
            Destroy(this.gameObject);
        }

        //update hp bar
        healthbar.value = hp/maxhp;
    }

    void OnCollisionEnter(Collision other) {
        //if enemy hits player, take damage
        if(other.gameObject.tag == "Enemy"){
            hp -= damageTakenPerHit;
        }
        //if player gets health item, heal player
        else if(other.gameObject.tag == "Health"){
            hp += damageTakenPerHit;
            //cap hp at max
            if(hp > maxhp) hp = maxhp;
            Destroy(other.gameObject);
        }
    }
}
