using UnityEngine;

namespace DrumDrumRevolution {
	public sealed class RandomSingleClipPlayer {
		public AudioClip[] clips;
		public float[] volumes;
		public AudioSource source;
		
		public RandomSingleClipPlayer(AudioClip[] clips, float[] volumes, AudioSource source) {
			this.clips = clips;
			this.volumes = volumes;
			this.source = source;
		}
		
		public void Play() {
			int index = Random.Range(0, clips.Length);
			
			float volume = 1;
			if (volumes != null && index < volumes.Length) {
				volume = volumes[index];
			}
			
			source.PlayOneShot(clips[index], volume);
		}
	}
}