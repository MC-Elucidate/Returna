﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
	AudioSource source;

	[SerializeField]
	private AudioClip footstepClip;

	void Start()
	{
		source = GetComponent<AudioSource>();
	}

	private void PlaySound(AudioClip clip)
	{
		if(clip == null)
			return;

		source.PlayOneShot(clip);
	}
	private void PlaySoundInstance(AudioClip clip)
	{
		if (clip == null)
			return;

		AudioSource.PlayClipAtPoint(clip, transform.position);
	}

	public void PlayFootstep()
	{
		PlaySound(footstepClip);
	}
}
