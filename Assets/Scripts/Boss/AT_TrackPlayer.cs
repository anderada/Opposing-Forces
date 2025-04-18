using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class AT_TrackPlayer : ActionTask {

		public BBParameter<Transform> playerBB;	//reference to player
		Transform player;	//reference to player
		public float waitTime;	//time to track player
		float timer;	//keeps track of time spent
		public float speed = 3;	//speed to follow player at
		NavMeshAgent nav;	//reference to nav agent

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			nav = agent.GetComponent<NavMeshAgent>();	//get reference to nav agent
			player = playerBB.value;	//get reference to player
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			nav.speed = speed;	//set agent speed
			timer = waitTime;	//set timer
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//if nav agent is enabled, set destination to the player
			if(nav.enabled)
				nav.SetDestination(player.position);

			//decrease timer, end action when it hits 0
			timer -= Time.deltaTime;
			if(timer <= 0){
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}