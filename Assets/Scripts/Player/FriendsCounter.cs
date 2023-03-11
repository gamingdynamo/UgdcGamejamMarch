using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using TMPro;

public class FriendsCounter : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI badFriendsText;
	[SerializeField] private TextMeshProUGUI goodFriendsText;
	[SerializeField] private TextMeshProUGUI PointsText;

	public float SlowDownFactor = 0.05f;
	public float duration = 2f;

	[Header("Sounds")]
	[SerializeField] private AudioSource goodfriend, badfriend;

	private int goodFriendNumber;
	private int badFriendNumber;
	private int PointsNumber;
	private float timer;

	float intensity;
    private void Update()
    {
		timer += Time.deltaTime;
		Time.timeScale += (1f / duration) * Time.unscaledDeltaTime;
		Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

		
		 
	}

    private void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
	}


    public void AddFriendsNumber(bool goodFriend)
	{
		if (goodFriend) {
			goodFriendNumber++;
			PointsNumber++;
			goodFriendsText.text = goodFriendNumber.ToString();
			PointsText.text = PointsNumber.ToString();
			goodfriend.Play();

			DoSlowMo();
			
			
			
		}
		if (!goodFriend) {
			badFriendNumber++;

				PointsNumber--;
            
			badFriendsText.text = badFriendNumber.ToString();
			PointsText.text = PointsNumber.ToString();
			badfriend.Play();
			DoSlowMo();
			


		}
	}

	void DoSlowMo()
    {
		
		Time.timeScale = SlowDownFactor;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;

		
	}
}
