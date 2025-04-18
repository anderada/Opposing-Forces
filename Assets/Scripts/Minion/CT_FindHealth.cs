using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CT_FindHealth : ConditionTask {

		public BBParameter<Transform> healthItemRef;	//reference to item

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
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
			//find if there's a health item in the scene
			var healthItem = GameObject.FindGameObjectWithTag("Health");
			//if there is, set the blackboard item to the item and return true
			if(healthItem != null){
				healthItemRef.value = healthItem.transform;
				return  true;
			}
			//else return false
			return false;
		}
	}
}