﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
	public GameObject impactEffect;

	public float speed = 70f;

	
    // finding target
	public void Seek (Transform _target)
	{
		target = _target;
	}

	// Update is called once per frame
	void Update () {

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

        // distance from bullet to target in current frame
		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);

	}

	void HitTarget ()
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 2f);

		Destroy(target.gameObject);
		Destroy(gameObject);
	}
}