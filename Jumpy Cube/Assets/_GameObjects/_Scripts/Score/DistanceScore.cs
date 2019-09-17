﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceScore : MonoBehaviour
{
    public Transform player;
    public float initialPosX;
    public float finalPosX;
    public float distanceMultiplier = 0.8f;
    public float dist;
    public int distance;

    public TMP_Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        if(!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        initialPosX = player.position.x;

        distance = 0;
        scoreTxt.text = distance + "";
    }

    // Update is called once per frame
    void Update()
    {
        finalPosX = player.position.x;
        dist = (initialPosX - finalPosX);
        dist *= distanceMultiplier;
        distance = (int)(dist);
        scoreTxt.text = distance + "";
    }
}
