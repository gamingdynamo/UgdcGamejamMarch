using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;


public class FriendsCounter : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI badFriendsText;
	[SerializeField] private TextMeshProUGUI goodFriendsText;

	private int goodFriendNumber;
	private int badFriendNumber;

	public void AddFriendsNumber(bool goodFriend)
	{
		if (goodFriend) {
			goodFriendNumber++;
			goodFriendsText.text = goodFriendNumber.ToString();

			GameObject.FindObjectOfType<AudioManager>().PlaySound("AddGoodFriend");
		}
		if (!goodFriend) {
			badFriendNumber++;
			badFriendsText.text = badFriendNumber.ToString();

			GameObject.FindObjectOfType<AudioManager>().PlaySound("AddBadFriend");
		}
	}
}
