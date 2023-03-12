using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private Sound[] sounds;

	private void Awake()
	{
		foreach(Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();

			s.source.clip = s.clip;

			s.source.name = s.name;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}
	}

   

    public void PlaySound(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		s.source.Play();
	}
}
