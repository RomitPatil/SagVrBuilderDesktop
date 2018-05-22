﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HideInfo : MonoBehaviour {
   public bool hide;
    public bool RequireMsg;
	int s;
	string temp;  
	public TriLib.Samples.PreviewHotspot previewHotspot; 
	 
	// Use this for initialization
	void Start () {
		s = 1;  
        
		previewHotspot = gameObject.transform.parent.GetComponent<TriLib.Samples.PreviewHotspot> ();  
		if(previewHotspot.Always == true)  
			gameObject.transform.GetChild (0).transform.GetChild (0).GetComponent<Text> ().text = previewHotspot.LableText; 
		else
			gameObject.transform.GetChild (0).transform.GetChild (0).GetComponent<Text> ().text = previewHotspot.LableTitle;

        if (GetComponent<SphereCollider>()) {
            GetComponent<SphereCollider>().radius = 3;
        }
	}
	 
	// Update is called once per frame
	void Update () {

        RequireMsg = previewHotspot.isRequire;

    } 

    public void OnMouseOver() {
        Debug.Log(">>>>>");
        if (!RequireMsg)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = previewHotspot.LableText;
        }

        else {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
           gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = previewHotspot.GetMsg;
        }
	  
    }

    public void OnClick() {
        if (RequireMsg)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "";
        }
    }
    public void OnMouseExit()
    {
        Debug.Log("<<<<<<<");
        if (!RequireMsg)
        {

            Debug.Log("Visible");
            if (previewHotspot.Always == true)
                gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = previewHotspot.LableText;
            else
                gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = previewHotspot.LableTitle;

        }
        else {
            Debug.Log("<<<<<<<??????");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "";
        }
    }
	  
	public void changeText(){      
		if(previewHotspot == null) 
			previewHotspot = gameObject.transform.parent.GetComponent<TriLib.Samples.PreviewHotspot> ();
		if (s % 2 == 0) {   
			gameObject.transform.GetChild (0).transform.GetChild (0).GetComponent<Text> ().text = previewHotspot.LableTitle; 
			s++;    
		} else {  
			gameObject.transform.GetChild (0).transform.GetChild (0).GetComponent<Text> ().text = previewHotspot.LableText;   
			s++;
		}
	} 
}