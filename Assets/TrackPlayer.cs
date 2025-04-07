using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class TrackPlayer : ActionTask {

		public BBParameter<Transform> playerBB;
		Transform player;
		public float waitTime;
		float timer;
		public float speed = 3;
		NavMeshAgent nav;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			nav = agent.GetComponent<NavMeshAgent>();
			player = playerBB.value;
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			nav.speed = speed;
			timer = waitTime;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			nav.SetDestination(player.position);
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