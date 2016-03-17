using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public void Start() {

	}

	public void PlayerHitCheckPoint() {

	}

	private IEnumerator PlayerHitCheckpointCo(int bonus) {

		yield break;
	}

	public void PlayerLeftCheckpoint() {

	}

	public void SpawnPlayer(Player player) {
		player.RespawnAt (transform);
	}

	public void AssignObjectToCheckpoint() {

	}
}
