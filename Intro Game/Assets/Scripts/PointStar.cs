using UnityEngine;
using System.Collections;

public class PointStar : MonoBehaviour, IPlayerRespawnListener {

	public GameObject Effect;
	public int PointsToAdd = 10;
	public AudioClip HitStarSound;
	public Animator Animator;

	private bool _isCollected;

	public void OnTriggerEnter2D(Collider2D other) {
		if (_isCollected)
			return;

		if (other.GetComponent<Player> () == null)
			return;

		if (HitStarSound != null)
			AudioSource.PlayClipAtPoint (HitStarSound, transform.position);

		GameManager.Instance.AddPoints (PointsToAdd);
		Instantiate (Effect, transform.position, transform.rotation);
		FloatingText.Show (string.Format ("+{0}!", PointsToAdd), "PointStarText", new FromWorldPointTextPositioner (Camera.main, transform.position, 1.5f, 50f));

		_isCollected = true;

		Animator.SetTrigger ("Collect");
	}

	public void FinishAnimationEvent() {
		gameObject.SetActive (false);
	}

	public void OnPlayerRespawnInThisCheckpoint(Checkpoint checkpoint, Player player) {
		_isCollected = false;
		gameObject.SetActive(true);
	}
}
