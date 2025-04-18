using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CT_playerIsClose : ConditionTask {

		public BBParameter<Transform> playerBB;	//reference to player
		public BBParameter<float> closeAttackCooldown;	//how long to wait between attacks when the player is close
		public float CooldownTime = 1;	// timer to keep track of cooldown
		Transform player;	//reference to the player
		public float distance = 3;	//distance the player has to be to activate

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			player = playerBB.value;	//get reference to player
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//if the player is dead return false
			if(player == null)
				return false;

			//decrease cooldown timer
			closeAttackCooldown.value -= Time.deltaTime;

			//if theres still a cooldown, return false
			if(closeAttackCooldown.value > 0)
				return false;

			//if the player is close enough return true
			if((player.position - agent.transform.position).magnitude <= distance) {
				closeAttackCooldown.value = CooldownTime;
				return true;
			}

			//else return false
			return false;
		}
	}
}