using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class AT_LookAtPlayer : ActionTask {

		public BBParameter<Transform> playerBB;	//reference to player
		Transform player;	//reference to player
		public float waitTime;	//time to complete task
		float timer;	//keeps track of time spent
		NavMeshAgent nav;	//reference to nav agent
		Animator lunge;		//animation player

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			nav = agent.GetComponent<NavMeshAgent>();	//get nav agent
			player = playerBB.value;	//get player reference
			lunge = agent.GetComponentInChildren<Animator>();	//get animator
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			timer = waitTime;	//set timer
			nav.SetDestination(agent.transform.position);	//stop boss where it is
			lunge.SetBool("Play",true);	//play lunge animation
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timer -= Time.deltaTime;	//reduce timer
			agent.transform.LookAt(player);	//look at player

			//end action when timer reaches  0
			if(timer <= 0){
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			lunge.SetBool("Play",false); //stop animation
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}