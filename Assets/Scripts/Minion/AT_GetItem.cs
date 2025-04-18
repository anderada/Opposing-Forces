using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class AT_GetItem : ActionTask {

		public float acceptRadius = 3f;	//how far away the minion has to be to pick it up
		public BBParameter<Transform> itemRef;	//reference to the item
		NavMeshAgent nav;	//reference to the nav agent

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			nav = agent.GetComponent<NavMeshAgent>();	//get reference to nav agent
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			nav.SetDestination(itemRef.value.position);	//set destination to item
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//if the item stops existing, return false
			if(itemRef.value == null){
				EndAction(false);
			}
			//if the item is close enough, return true
			if((agent.transform.position - itemRef.value.position).magnitude <= acceptRadius){
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