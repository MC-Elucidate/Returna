﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float attackWidth;
    [SerializeField]
    private bool DebugMode;

    void Start () {
		
	}
	
	void Update () {
    }

    public void AttackCast()
    {
        if(DebugMode)
            DebugHelper.DrawBoxCastBox(transform.position, new Vector3(attackWidth, 1, 0), transform.forward, transform.rotation, attackRange, Color.green, 0.5f);

        RaycastHit[] hits = Physics.BoxCastAll(transform.position, new Vector3(attackWidth, 1, 0), transform.forward, transform.rotation, attackRange, LayerMask.GetMask(Constants.Layers.Enemy));
        if (hits.Length > 0)
            Debug.Log("Hit enemy");
    }
}
