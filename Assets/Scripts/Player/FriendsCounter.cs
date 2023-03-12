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

	[HideInInspector]
	public int goodFriendNumber;
	[HideInInspector]
	public int badFriendNumber;
	private int PointsNumber;
	private float timer;

	public GameObject ControlsPanel;
	private float distancetonpc;

	private Transform player;
	private GameObject npc;
	private Npc npcscript;

	float intensity;

    private void Start()
    {
		npc = GameObject.FindGameObjectWithTag("npc");
		npcscript = FindObjectOfType<Npc>();
    }


    private void Update()
    {
		Cursor.lockState = CursorLockMode.None;
		timer += Time.deltaTime;
		Time.timeScale += (1f / duration) * Time.unscaledDeltaTime;
		Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
	}




    public void AddFriendsNumber(bool goodFriend)
	{
		if (goodFriend) {
			GameObject.FindObjectOfType<AudioManager>().PlaySound("AddGoodFriend");
			goodFriendNumber++;
			PointsNumber++;
			goodFriendsText.text = goodFriendNumber.ToString();
			PointsText.text = PointsNumber.ToString();

			DoSlowMo();
			
			
			
		}
		if (!goodFriend) {
			GameObject.FindObjectOfType<AudioManager>().PlaySound("AddBadFriend");
			badFriendNumber++;

				PointsNumber--;
            
			badFriendsText.text = badFriendNumber.ToString();
			PointsText.text = PointsNumber.ToString();

			DoSlowMo();
			


		}
	}

	void DoSlowMo()
    {
		
		Time.timeScale = SlowDownFactor;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;

		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("npc"))
        {
			ControlsPanel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("npc"))
        {
			ControlsPanel.gameObject.SetActive(false);
		}
    }
}
