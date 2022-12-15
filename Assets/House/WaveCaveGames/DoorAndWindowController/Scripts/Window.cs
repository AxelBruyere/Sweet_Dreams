using UnityEngine;

namespace WaveCaveGames{
	
	public class Window : MonoBehaviour{
		//attach this component to a group of window so they can be controlled by FPSTrigger
		public Door[] controlList;

		public void OpenWindow(int i){
			if(controlList.Length > i && !controlList[i].locked) controlList[i].enabled = true;
		}
	}
}
