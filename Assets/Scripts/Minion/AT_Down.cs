using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class AT_Down : ActionTask {

		public float downTime = 5f;		//time to stay down
		public float dropRange = 3f;	//how far away to drop held item
		public BBParameter<Transform> item;	//reference to item
		float timer;	//keeps track of time spent

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			timer = downTime;	//set timer
			agent.transform.Translate(0f,-1f,0f);		//put minion into the ground
			agent.gameObject.GetComponent<NavMeshAgent>().enabled = false;	//turn off the nav agent

			//if item is held, drop it
			if(item.value != null) {
				item.value.position = new Vector3(agent.transform.position.x + Random.Range(-dropRange,dropRange), 2f, agent.transform.position.z + Random.Range(-dropRange,dropRange));
			}
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//decrease timer, end when it hits 0
			timer -= Time.deltaTime;
			if(timer <= 0){
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			//bring minion back out of the ground, reset the down flag, turn the nav agent back on
			agent.transform.Translate(0f,1f,0f);
			agent.gameObject.GetComponent<MinionController>().down = false;
			agent.gameObject.GetComponent<NavMeshAgent>().enabled = true;
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}