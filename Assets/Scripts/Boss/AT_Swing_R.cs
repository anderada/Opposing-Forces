using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AT_Swing_R : ActionTask {

		Animator swing; //reference to animation
		int buffer; //leaves one frame for the animator to activate

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			//get reference to animator
			swing = agent.transform.GetChild(0).GetChild(2).GetComponentInChildren<Animator>();
			return null;
		}


		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			swing.SetBool("Play", true);	//play the animation
			buffer = 1;	//leave one frame for the animation to start
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if(buffer <= 0) // if one frame has been passed, end action
				EndAction(true);
			buffer--; // reduce buffer to show one frame has passed
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			//reset animation trigger
			swing.SetBool("Play", false);
		}

		//Called when the task is paused.
		protected override void OnPause() {

		}
	}
}