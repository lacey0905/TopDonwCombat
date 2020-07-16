using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkCollider : MonoBehaviour
{

    public FollowCamera cam;
    public GameObject hitEft;
    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 spawnDir = player.position - other.transform.position;
        Vector3 spawnPos = other.transform.position + spawnDir.normalized * 0.5f;
        spawnPos = new Vector3(spawnPos.x, other.transform.position.y, spawnPos.z);

        Instantiate(hitEft, spawnPos, Quaternion.identity);

        cam.Shake();
        other.GetComponent<cap>().HitPush(player.forward);
        other.GetComponent<cap>().Damage();
    }
}
