using UnityEngine;
using UnityEngine.XR;

public sealed class VrPlayer {
	public float positionDamping, rotationDamping;
	public Vector3 positionL, positionR;
	public Quaternion rotationL, rotationR;

	public VrPlayer(float positionDamping, float rotationDamping) {
		this.positionDamping = positionDamping;
		this.rotationDamping = rotationDamping;
	}

	public void RecordTransforms(float deltaTime) {
		var posL = InputTracking.GetLocalPosition(XRNode.LeftHand);
		var posR = InputTracking.GetLocalPosition(XRNode.RightHand);

		var rotL = InputTracking.GetLocalRotation(XRNode.LeftHand);
		var rotR = InputTracking.GetLocalRotation(XRNode.RightHand);

		positionL = Vector3.Lerp(positionL, posL, deltaTime * positionDamping);
		positionR = Vector3.Lerp(positionR, posR, deltaTime * positionDamping);

		rotationL = Quaternion.Slerp(rotationL, rotL, deltaTime * rotationDamping);
		rotationR = Quaternion.Slerp(rotationR, rotR, deltaTime * rotationDamping);
	}
}
