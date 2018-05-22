using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions; 

public class AddHotspot : MonoBehaviour { 

	public GameObject navHotspotprefab;
	public GameObject HotspotContainer;
	public GameObject ActiveHotspotPanal;
	public GameObject DomeCamera;
	public SetupDome DomeSetup; 
	public GameObject locationDome;  
	public GameObject navigationLocation;  
	public GameObject BlueHotspotPanal; 
	public GameObject purpleHotspotPanal;
	public GameObject redHotspotPanal;
	public GameObject greenHotspotPanal; 
	public GameObject viewCamera;    
	public GameObject transition0,transition1,transition2,transition3;  
	public InputField posx, posy, posz,UserAction_InputField;   
	public Dropdown Action_SceneList;
	  
    // Edited
    public Text BtnID;  
    public Text HotspotName;  

    public GameObject[] AllHotspotTemplets;

    int click;
    int CheckerScene;

    // Use this for initialization  
    void Start () {
		  
	}


	private void EnableTheActionHotspotPanal () {
		gameObject.transform.parent.gameObject.GetComponent<Image> ().enabled = true;
		BlueHotspotPanal.SetActive (false);
		purpleHotspotPanal.SetActive (false);
		redHotspotPanal.SetActive (false);    
		greenHotspotPanal.SetActive (false); 
		ActiveHotspotPanal.SetActive (true);    
	//	navigationLocation.SetActive (true); 
	}

    public void EnableHotspotPanal() {  

        for (int j = 0; j < AllHotspotTemplets.Length; j++)
        {

            if (AllHotspotTemplets[j].gameObject.name == "NavigateHotspotPanel")  
            {

                AllHotspotTemplets[j].SetActive(true);
            }
            else
            {
                AllHotspotTemplets[j].SetActive(false);
            }
        }
    }

	private void InitiatingHotspotObjectOnSelectedScene() {
        EnableHotspotPanal();
        for (int i = 0; i < HotspotContainer.transform.childCount; i++) {
			Debug.Log (HotspotContainer.transform.GetChild (i).name + "   " + DomeSetup.Scene_Name_Input.text);
			if (HotspotContainer.transform.GetChild (i).name == DomeSetup.Scene_Name_Input.text) {
    
				GameObject hotspotObj = GameObject.Instantiate (navHotspotprefab);   


				hotspotObj.transform.parent = HotspotContainer.transform.GetChild (i).transform;
			     
				hotspotObj.transform.eulerAngles = DomeCamera.transform.eulerAngles;
				DomeSetup.SelectFile.GetComponent<SelectFiles> ().EditScene = true;
				DomeSetup.SelectFile.GetComponent<SelectFiles> ().scene.SceneTitle = DomeSetup.Scene_Name_Input.text;

				DomeSetup.SelectFile.GetComponent<SelectFiles> ().scene.sceneTexture = DomeSetup.GetComponent<MeshRenderer> ().material.mainTexture;				 
				SetupDome.ButtonId = SetupDome.ButtonId + 1; 
				SetupDome.SelectedHotspot = hotspotObj;
                hotspotObj.GetComponent<navigateActionHotspot>().ButtonID = SetupDome.ButtonId;
                hotspotObj.GetComponent<navigateActionHotspot> ().Hotspot_Name = HotspotName; 
				hotspotObj.GetComponent<navigateActionHotspot> ().SetupNewActionhotspot (); 
				for (int j = 0; j < HotspotContainer.transform.childCount; j++) { 
				       
					hotspotObj.GetComponent<navigateActionHotspot> ().SceneTexture.Add (HotspotContainer.transform.GetChild (j).GetComponent<SceneProperties> ().SceneTexture);
					hotspotObj.GetComponent<navigateActionHotspot> ().SceneTexturePath.Add (HotspotContainer.transform.GetChild (j).GetComponent<SceneProperties> ().SceneTexturePath);
				}       
				          
				  
			} else {
				HotspotContainer.transform.GetChild (i).gameObject.SetActive(false);
			}
			 
		}
	} 
	public void OnClick (){ 
			click++; 
			StartCoroutine (waitFroClick ()); 
	}

	IEnumerator waitFroClick () { 
		Debug.Log ("OnClick");

		EnableTheActionHotspotPanal ();
		InitiatingHotspotObjectOnSelectedScene ();
		yield return new WaitForSeconds (2f);  
		click = 0;
	}

	public void DefaultPos () {
//		transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f); 
		DomeCamera.GetComponent<MouseCameraDraging>().pitch = 0;
		DomeCamera.GetComponent<MouseCameraDraging> ().yaw = 0; 
		DomeCamera.transform.eulerAngles = new Vector3 (0, 0, 0.0f);

	}
	public void LeftPos () {
		DomeCamera.GetComponent<MouseCameraDraging>().pitch = 90;
		DomeCamera.GetComponent<MouseCameraDraging> ().yaw = 0;
		DomeCamera.transform.eulerAngles = new Vector3 (0, 90, 0.0f);
	}
	public void RightPos () {

		DomeCamera.GetComponent<MouseCameraDraging>().pitch = 270f;
		DomeCamera.GetComponent<MouseCameraDraging> ().yaw = 0f;

		DomeCamera.transform.eulerAngles = new Vector3 (0, 270f, 0.0f);
	}
	public void FrontPos () {

		DomeCamera.GetComponent<MouseCameraDraging>().pitch = 0;
		DomeCamera.GetComponent<MouseCameraDraging> ().yaw = 0; 

		DomeCamera.transform.eulerAngles = new Vector3 (0, 0, 0.0f);
	}
	public void BackPos () {

		DomeCamera.GetComponent<MouseCameraDraging>().pitch = 180f;
		DomeCamera.GetComponent<MouseCameraDraging> ().yaw = 0;
		DomeCamera.transform.eulerAngles = new Vector3 (0, 180f, 0.0f);
	}

	// Update is called once per frame 
	void Update () {
		if (HotspotContainer == null) {
		//	HotspotContainer = GameObject.FindGameObjectWithTag ("HotSpotContainer");
		}
		if (DomeCamera == null) {
			DomeCamera = GameObject.Find ("DomeCamera"); 
		}  
		if (DomeSetup == null) {
			DomeSetup = GameObject.FindObjectOfType<SetupDome> ();
		}

        if (CheckerScene != HotspotContainer.transform.childCount)
        {
         
                InsertSceneList();
            
        }
    }  

    public void InsertSceneList()
    {
        List<Dropdown.OptionData> SceneFlag = new List<Dropdown.OptionData>();
        SceneFlag.Clear();
        Action_SceneList.ClearOptions();
        for (int i = 0; i < HotspotContainer.transform.childCount; i++)
        {
            if (HotspotContainer.transform.GetChild(i).GetComponent<SceneProperties>())
            {
                string SceneName = HotspotContainer.transform.GetChild(i).name;
                var flagOptionNavigate = new Dropdown.OptionData(SceneName);


                SceneFlag.Add(flagOptionNavigate);
            }

        }
        CheckerScene = HotspotContainer.transform.childCount;
        Action_SceneList.AddOptions(SceneFlag);
    }
}
