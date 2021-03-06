using UnityEngine;
using System.Collections;

public class BattleUIManager : UIManager
{
	private BattleGameManager battleGameManager;
	
	public override void Awake ()
	{
		BgmType = Bgm.NONE;
		BgmName = string.Empty;
		
		IsCache = false;
	}

	public override void Start ()
	{
		battleGameManager = gameObject.GetComponent<BattleGameManager> ();
	}

//	void Update ()
//	{
//		float temp = battleGameManager.GetTimer ();
//		if (temp > 0) {
//			timer.text = "" + (int)temp;
//		}
//	}

	private void Common (int length)
	{
		battleGameManager.SetNumber (length);
	}

	public void BattleOnClick ()
	{
		Debug.Log ("BattleOnClick");
		if (!battleGameManager.GetCheckStatus (GameStatus.Play)) {
			return;
		}

		GameObject gO = UIButton.current.gameObject;
		UILabel tempUILabel = gO.GetComponentInChildren<UILabel> ();
		if (tempUILabel.text == "") {
			return;
		}

		Common(int.Parse(gO.name) - 1);
		gO.GetComponent<Animation> ().Play (Config.ANIMATION_BUTTON);
		tempUILabel.text = "";
		// Color32 myNewColor = new Color32(128,128,128,255);
		// Color myOtherColor = new Color(0.5f,0.5f,0.5f, 1f); //RGBA in 0-1f
	}

	public void Stop ()
	{
		SSSceneManager.Instance.PopUp (Config.STOP);
	}
}
