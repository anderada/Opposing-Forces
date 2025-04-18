using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions{

	public class AT_Wander : ActionTask {

		public float acceptRadius = 3;	//how far away the minion has to get to the target
		public float radius = 16f;	//where the minon  can wander from the centre of the arena
		NavMeshAgent nav;//reference to the nav agent
		Vector3 target;	//target location


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			nav = agent.GetComponent<NavMeshAgent>(); //get reference to nav agent
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//set random target in radius
			target = new Vector3(Random.Range(-radius,radius), 0f, Random.Range(-radius,radius));
			nav.SetDestination(target);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//if target is close enough, get a new random target
			if((target - agent.transform.position).magnitude <= acceptRadius) {
				target = new Vector3(Random.Range(-radius, radius), 0f, Random.Range(-radius, radius));
				nav.SetDestination(target);
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