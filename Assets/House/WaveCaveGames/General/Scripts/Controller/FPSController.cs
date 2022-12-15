using UnityEngine;

namespace WaveCaveGames{
	
	public class FPSController : MonoBehaviour {

		public int speed = 5;
		[Tooltip("Camera Rotate Sensitivity")]
		public float cameraRotateSensitivity = 150f;
		private CharacterController controller;
		private Transform playerCam;

		void Start(){
			controller = GetComponent<CharacterController>();
			if (controller == null) {
				Debug.LogError("Character Controller component is not attached to FPS Controller!");
				Destroy(gameObject); return;
			}
			playerCam = GetComponentInChildren<Camera>().transform;
			if (playerCam == null) {
				Debug.LogError("Camera component is not attached to child of FPS Controller!");
				Destroy(gameObject); return;
			}
		}
		void Update () {
			float hor = Input.GetAxis("Horizontal");
			float ver = Input.GetAxis("Vertical");
			controller.SimpleMove(transform.TransformDirection(hor, 0f, ver) * ((float)speed / 3.6f));
			//rotate camera
			playerCam.Rotate(-Input.GetAxis("Mouse Y") * cameraRotateSensitivity * Time.deltaTime, 0f, 0f);
			transform.Rotate(0f, Input.GetAxis("Mouse X") * cameraRotateSensitivity * Time.deltaTime, 0f);
			playerCam.localRotation = Quaternion.Euler(playerCam.localEulerAngles.x, playerCam.localEulerAngles.y, 0);
		}
	}
}
