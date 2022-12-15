using UnityEngine;
using WaveCaveGames;

namespace WaveCaveGames{

	public class FPSTrigger : MonoBehaviour {

		public KeyCode openDoorKey = KeyCode.Space;
		public KeyCode openWindowKey = KeyCode.J;
		private Door door;
		private Window window;

		void Update () {
			//door
			if (Input.GetKeyDown(openDoorKey) && door != null) {
				if (!door.locked && !door.notControlledByPlayer) {
					if (door.GetComponentInParent<DoorGroup>() != null) door.GetComponentInParent<DoorGroup>().OpenTheDoors();
					else door.enabled = true;
				}
			}
			//window
			if (Input.GetKeyDown(openWindowKey)) {
				if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) window.OpenWindow(1);
				else if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) window.OpenWindow(2);
				else if(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) window.OpenWindow(3);
				else window.OpenWindow(0);
			}
		}
		private void OnTriggerStay(Collider other){
			if (door == null || other.GetComponent<Door>() != null && !other.GetComponent<Door>().notControlledByPlayer) {
				door = other.GetComponent<Door>();
			}
			if (window == null || other.GetComponent<Window>() != null) {
				window = other.GetComponent<Window>();
			}
		}
		private void OnTriggerExit(Collider other){
			door = null;
			window = null;
		}
		void OnGUI(){
			GUIStyle style = new GUIStyle();
			Rect rect = new Rect(0, 0, Screen.width, Screen.height);
			style.alignment = TextAnchor.LowerCenter;
			style.fontSize = Screen.height / 24;
			string window1Text = "Press \"" + openWindowKey.ToString() + "\" key to open the window. ";
			string window2Text = "Press \"Shift+" + openWindowKey.ToString() + "\" to open 2nd window";
			if (window != null) {
				if (window.controlList.Length > 0 && window.controlList[0] != null) {
					if (window.controlList[0].locked) window1Text = "First window locked";
				} else {
					window1Text = "";
				}
				if (window.controlList.Length > 1 && window.controlList[1] != null) {
					if (window.controlList[1].locked) window2Text = "Second window locked";
				} else {
					window2Text = "";
				}
			}
			string text = "<color=lime>" + ((door != null && !door.notControlledByPlayer) ? (door.locked ? "Door locked" : "Press \"" + openDoorKey.ToString() + "\" key to open the door") : ((window != null) ? window1Text + window2Text : "")) + "</color>";
			GUI.Label(rect, text, style);
		}
	}
}
