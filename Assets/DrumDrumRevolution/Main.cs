using UnityEngine;

namespace DrumDrumRevolution {
	public sealed class Main : MonoBehaviour {
		public AudioClip[] clips;
		public Transform handL, handR;

		RandomSingleClipPlayer clipPlayer;
		VrPlayer vrPlayer;

		void OnEnable() {
			Debug.Log("Restarted");

			var source = GetComponent<AudioSource>();
			clipPlayer = new RandomSingleClipPlayer(clips, null, source);

			vrPlayer = new VrPlayer(80, 80);
		}

		float lastTime;
		void Update() {
			float time = Time.time;
			float deltaTime = Time.deltaTime;

			if (time > lastTime + 1) {
				clipPlayer.Play();
				lastTime = time;
			}

			vrPlayer.RecordTransforms(deltaTime);
			handL.localPosition = vrPlayer.positionL;
			handL.localRotation = vrPlayer.rotationL;
			handR.localPosition = vrPlayer.positionR;
			handR.localRotation = vrPlayer.rotationR;
		}
	}
}