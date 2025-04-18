using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class bossController : MonoBehaviour
{
    public Slider healthbar;    //refence to health bar
    float hp;   //boss hp
    public float maxhp = 100;   //maxiumum hp
    public float damageTakenPerHit = 10;    //how much damage the boss takes when the player hits it

    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp; //set hp to max
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = hp/maxhp; //update hp bar

        //if hp is < 0 destroy the boss
        if(hp <= 0){
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
        //if the player hits it, take damage
        if(other.gameObject.tag == "Sword"){
            hp -= damageTakenPerHit;
        }
    }

    public void healBoss(){
        //heal boss for 4 hits
        hp += 4 * damageTakenPerHit;
        //cap hp at max
        if(hp > maxhp) hp = maxhp;
    }
}
