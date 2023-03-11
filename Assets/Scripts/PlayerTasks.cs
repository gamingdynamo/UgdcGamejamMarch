using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTasks : MonoBehaviour
{
	[Header("Important")]
	[SerializeField] TextMeshProUGUI currentTaskText;

	private enum Task
	{
		GETONEFRIEND,
		GETFIVEFRIENDS,
		GETONEBADFRIEND,
		KILLONEFRIEND,
		NONE
	}

	private Task task;

	[HideInInspector]
	public bool killFriend;

	private void Start()
	{
		task = Task.GETONEFRIEND;
	}

	private void Update()
	{

		switch(task)
		{
			case Task.GETONEFRIEND:
				currentTaskText.text = "Get 1 good friends";
				if (GameObject.FindObjectOfType<FriendsCounter>().goodFriendNumber >= 1)
				{
					task = Task.GETFIVEFRIENDS;
				}
				break;
			case Task.GETFIVEFRIENDS:
				currentTaskText.text = "Get 5 good friends";
				if (GameObject.FindObjectOfType<FriendsCounter>().goodFriendNumber >= 5)
				{
					task = Task.GETONEBADFRIEND;
				}
				break;
			case Task.GETONEBADFRIEND:
				currentTaskText.text = "Get 1 bad friend";
				if (GameObject.FindObjectOfType<FriendsCounter>().badFriendNumber >= 1)
				{
					task = Task.KILLONEFRIEND;
				}
				break;
			case Task.KILLONEFRIEND:
				currentTaskText.text = "Kill 1 bad friend";
				killFriend = true;
				task = Task.NONE;
				break;
			case Task.NONE:
				if (killFriend == false)
				{
					currentTaskText.text = "You won";
				}
				break;
				
		}
	}
}
