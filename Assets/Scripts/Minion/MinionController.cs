using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour
{
    public bool down = false;   //whether the minion is knocked down

    private void OnCollisionEnter(Collision other) {
        //when the player hits the minion, set the down flag
        if(other.gameObject.tag == "Sword"){
            down = true;
        }
    }
}
