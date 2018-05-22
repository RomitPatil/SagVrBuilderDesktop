using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TriLib.Samples;

public class MediaHotspotHelp : MonoBehaviour {

    public Vector3 Position;
    public bool Potrate;
    public bool landscape;
    public bool fullScreen;
    public GameObject NavigationCanvas;
    public AddHelpHotspot addMediaHotspot;
    public SetupDome setupDome;
    public VideoPlayer videoPlayer;
    public VideoPlayer FullScreenVideoPlayer;
    public string videoURL;
    public GameObject VideoMesh;
    public GameObject MediaContainer;
    public Image FrameOutLine;  
    public bool hide;  
    public bool changeAspetRatio;
    public bool clicked;
    public string ActionFunction;  
    public int Btn_ID;
    public bool Preview; 
    public GameObject FullScreenVideoUIPrv;
	public float scaleX,scaleY;  
	public GameObject[] AllHotspotTemplets;
	public Sprite hotspotSprite; 
	public Dropdown targetAction; 
	public bool BrowseImage;  
	public Texture ImageTexture;  

    public InputField posx, posy, posz;
    // Use this for initialization
    void Start () {
            ActionFunction = "MediaHotspot";
            addMediaHotspot = GameObject.Find("AddHelpHotspot").GetComponent<AddHelpHotspot>();
        landscape = true;

		      
    }  
	 
    public void OnClickHide()
    {
        if (clicked == false)
        {
            StartCoroutine(WaitForSce()); 
        }
        
    }
    public void OnClickMediaHotspot()  
    {
       
        addMediaHotspot.SelectedHotspot = gameObject;
        addMediaHotspot.hotspotName.text = "Btn ID :" + Btn_ID;     
        addMediaHotspot.posx.text = Position.x.ToString();
        addMediaHotspot.posy.text = Position.y.ToString();
        addMediaHotspot.InputUrl.text = videoURL;  
      
        if (gameObject.transform.localPosition.z != 0) {
            gameObject.transform.GetChild(0).gameObject.transform.localPosition = Vector3.zero;
        }
		 
		  
		AllHotspotTemplets = addMediaHotspot.AllHotspotTemplets; 
		if (gameObject.transform.parent.gameObject.GetComponent<helpActionHotspot> ()) {
			for (int j = 0; j < AllHotspotTemplets.Length; j++)
			{  
				if (AllHotspotTemplets[j].gameObject.name == "HelpPanel")
				{

					AllHotspotTemplets[j].SetActive(true);
				}  
				else
				{
					AllHotspotTemplets[j].SetActive(false);
				}
			}  
		}
		else if (gameObject.transform.parent.gameObject.GetComponent<NewActionHotspot> ()) {  
			for (int j = 0; j < AllHotspotTemplets.Length; j++)
			{

				if (AllHotspotTemplets[j].gameObject.name == "ActionHotspotTemplet") 
				{

					AllHotspotTemplets[j].SetActive(true);
				}
				else
				{
					AllHotspotTemplets[j].SetActive(false);
				}
			}
		}
		

    }

    IEnumerator WaitForSce()
    {
        hide = !hide;
        MediaContainer.SetActive(hide);
        changeAspetRatio = true;
        clicked = true;
        yield return new WaitForSeconds(0.2f);
        clicked = false;
    }

    public void PlayClip() {

        if (landscape)
        {
            changeAspetRatio = false;
            VideoMesh.SetActive(true);
            FullScreenVideoPlayer.Stop();
            FrameOutLine.gameObject.SetActive(true);
            FullScreenVideoPlayer.gameObject.SetActive(false);
            VideoMesh.gameObject.SetActive(true);
            VideoMesh.gameObject.transform.localScale = new Vector3(140f, 75f, 1f);
            FrameOutLine.rectTransform.sizeDelta = new Vector2(140f + 5f, 75f + 5f);
            FrameOutLine.GetComponent<BoxCollider>().size = new Vector3(145f, 75f, 4f);
            if (videoURL != "")
            {
                videoPlayer.url = videoURL;

            }
        }
    }
    // Update is called on{}ce per frame
    void Update ()
    {

        Position = gameObject.transform.position;

        if (!Preview)
        {
            if (addMediaHotspot == null)
            {

                addMediaHotspot = GameObject.Find("AddHelpHotspot").GetComponent<AddHelpHotspot>();
            }
        }
        else
        {
        //    FullScreenVideoUIPrv = GameObject.Find("FullScreenPreView").gameObject;
        }


       
			   
        

         

        }
          
	}
   

