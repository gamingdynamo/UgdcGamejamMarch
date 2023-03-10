using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;


public class FriendsCounter : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI badFriendsText;
	[SerializeField] private TextMeshProUGUI goodFriendsText;
	[SerializeField] private TextMeshProUGUI PointsText;

	private int goodFriendNumber;
	private int badFriendNumber;
	private int PointsNumber;

    public void AddFriendsNumber(bool goodFriend)
	{
		if (goodFriend) {
			goodFriendNumber++;
			PointsNumber++;
			goodFriendsText.text = goodFriendNumber.ToString();
			PointsText.text = PointsNumber.ToString();
			GameObject.FindObjectOfType<AudioManager>().PlaySound("AddGoodFriend");
		}
		if (!goodFriend) {
			badFriendNumber++;

				PointsNumber--;
            
			badFriendsText.text = badFriendNumber.ToString();
			PointsText.text = PointsNumber.ToString();
			GameObject.FindObjectOfType<AudioManager>().PlaySound("AddBadFriend");
		}
	}
}
