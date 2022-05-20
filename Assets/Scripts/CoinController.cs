using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    GameManager gm;
    Transform player;

    private void Start()
    {
        gm = GameManager.instance;
        player = FindObjectOfType<PlayerController>().transform;
    }

    private void FixedUpdate()
    {
        if (!gm.magnet.isActive)
            return;

        if(Vector3.Distance(transform.position, player.position) < gm.magnet.range)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position,
                gm.magnet.coinsSpeed);
        }
    }
}
