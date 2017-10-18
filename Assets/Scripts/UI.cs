using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum States
{
	MainMenu = 0,
	Options = 1,
	Pause = 2,
	Play = 3,
	Exit = 4
}

public class UI : MonoBehaviour 
{
	
	States state = States.MainMenu;
	// Use this for initialization

	public void Play()
	{
		state = States.Play;
	}

	public void Pause()
	{
		state = States.Pause;
	}

	public void MainMenu()
	{
		state = States.MainMenu;
	}

	public void Options()
	{
		state = States.Options;
	}

	public void Exit()
	{
		Application.Quit ();
	}

	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		switch (state) {
		case States.MainMenu:
			main menu buttons

		case States.Options:
			options buttons

		case States.Pause:
			pause buttons

		case States.Play:
			play buttons

		}
		*/
		
	}
}
