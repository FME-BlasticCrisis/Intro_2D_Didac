using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {

	private const float SkinWidth = .02f;
	private const int TotalHorizontalRays = 8;
	private const int TotalVerticalRays = 4;

	private static readonly float SlopeLimitTangent = Mathf.Tan(75f * Mathf.Deg2Rad);

	public LayerMask PlatformMask;
	public ControllerParameters2D DefaultParameters;

	public ControllerState2D State { get; private set;}

	public void Awake() {

	}

	public void AddForce (Vector2 force) {

	}

	public void SetForce (Vector2 force) {

	}

	public void SetHorizontalForce (float x) {

	}

	public void SetVerticalForce (float x) {

	}

	public void Jump() {

	}

	public void LateUpdate() {

	}

	private void HandlePlatforms () {

	}

	private void CalculateRayOrigins () {

	}

	private void MoveHorizontally (ref Vector2 deltaMovement) {

	}


}
