using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class AT_GoToBoss : ActionTask {

		public float acceptRadius = 3f;	//how far away the minion has to be to heal the boss
		public BBParameter<Transform> itemRef;	//reference to the item
		public BBParameter<Transform> bossRef;	//reference to the boss
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

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//if the item stops existing return false
			if(itemRef.value == null){
				EndAction(false);
			}
			//go towards the boss
			nav.SetDestination(bossRef.value.position);
			//hold item above head
			itemRef.value.position = agent.transform.position + new Vector3(0f,3f,0f);
			//if the minion gets close enough, heal the boss, destroy the item, and end action
			if((agent.transform.position - bossRef.value.position).magnitude <= acceptRadius){
				GameObject.Destroy(itemRef.value.gameObject);
				bossRef.value.GetComponent<bossController>().healBoss();
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