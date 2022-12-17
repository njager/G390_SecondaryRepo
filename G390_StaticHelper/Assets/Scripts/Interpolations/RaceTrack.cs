using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTrack : MonoBehaviour
{
    public Transform start, finish, player;
    public float percentage;

    private void Update()
    {
        Vector3 startPos = start.position;
        Vector3 finishPos = finish.position;
        Vector3 playerPos = player.position;

        float percentage = MathUtils.InverseLerp(startPos, finishPos, playerPos);
    }
}
