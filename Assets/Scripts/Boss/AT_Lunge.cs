using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Lunge : ActionTask {

		public BBParameter<Transform> playerBB;	//reference to player
		Transform player;	//reference to player
		public float speed = 20;	//speed of the lunge
		public float lungeTime = 3;	//time to spend lunging
		float timer;	//keeps track of time spent
		public float distance = 10;	//distance to lunge
		Vector3 destination;	//where to lunge to
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
			//if the nav agent is enabled, set destination behind the player, with length specified in public variable
			//and set speed to lunge speed
			if(nav.enabled){	
				destination = (player.position - agent.transform.position).normalized * distance + agent.transform.position;
				nav.SetDestination(destination);
				nav.speed = speed;
			}
			//set timer
			timer = lungeTime;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timer -= Time.deltaTime; //decrease timer
			//end action when timer reaches 0
			if(timer <= 0) {
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