using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour, ITrigger
{
    public Transform teleportSpawn;

    public void Trigger()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(teleportSpawn.position.x, teleportSpawn.position.y, player.transform.position.z);
    }

    private void OnDrawGizmos()
    {
        if (teleportSpawn != null)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawSphere(teleportSpawn.position, 0.1f);
        }
    }
}
