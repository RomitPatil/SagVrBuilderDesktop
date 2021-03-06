﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetFunction : MonoBehaviour {

    public GameObject NavigationCanvas;
    public Dropdown NavigationFunction;
    public string TargetFunctionObject;
    public Dropdown TargetFunctions;
    public InputField TextBoxFunction;
    public Vector3 position;
    public string SelectedTargetFunction;
    public string ActionFunction;
    public AddObjectHotspot AddObjectHotspot;
    public ObjectHotsot ObjectHotspot;
    public GameObject Model;
    public InputField InputTextBox;
    public float Z_pos;
    int CheckerScene;
    
    // Use this for initialization
    void Start () {
        ActionFunction = "Target";

    }
	
	// Update is called once per frame
	void Update ()
    {

        SelectedTargetFunction = TargetFunctions.captionText.text;
        AddObjectHotspot.TargetFunctionType = SelectedTargetFunction;
        ObjectHotspot.TargetFunctionType = SelectedTargetFunction;

        if (SelectedTargetFunction == "Navigation")
        {
            NavigationFunction.gameObject.SetActive(true);
            TextBoxFunction.gameObject.SetActive(false);
           
            if (CheckerScene != NavigationCanvas.transform.childCount)
            {
                InsertSceneList();
            }
            if (SelectedTargetFunction != TargetFunctions.captionText.text)
            {
                FunctionObjectSelection();
            }
            TargetFunctionObject = NavigationFunction.captionText.text;
            TargetFunctionObject = NavigationFunction.captionText.text.ToString();
            AddObjectHotspot.TargetFunctionData = TargetFunctionObject;
            ObjectHotspot.TargetFunctionData = TargetFunctionObject;
        }
        if (SelectedTargetFunction == "Text Box")
        {
            NavigationFunction.gameObject.SetActive(false);
            TextBoxFunction.gameObject.SetActive(true);
            TargetFunctionObject = TextBoxFunction.text;
          
            AddObjectHotspot.TargetFunctionData = TargetFunctionObject;
            ObjectHotspot.TargetFunctionData = TargetFunctionObject;

            gameObject.GetComponent<BoxCollider>().size = new Vector3(gameObject.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x, gameObject.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y, 5);
            gameObject.GetComponent<BoxCollider>().center = new Vector3(-45, 0, 0);
            gameObject.transform.GetChild(0).GetChild(0).transform.GetComponent<Text>().text = InputTextBox.text;
        }

        if (Input.GetMouseButton(0)) {

            AddObjectHotspot.Pos_X.text = gameObject.transform.localPosition.x.ToString();
            AddObjectHotspot.Pos_Y.text = gameObject.transform.localPosition.y.ToString();
            
        }
        position = transform.localPosition;
        if (AddObjectHotspot != null) {
            if (AddObjectHotspot.Pos_Z.text != null)
            {
                string z = AddObjectHotspot.Pos_Z.text;
                float Z = float.Parse(z);
                Z_pos = Z;
            }
        }
    }
    // Insert Scene Files
    public void InsertSceneList()
    {
        Debug.Log("Enter on Insert");
        List<Dropdown.OptionData> SceneFlag = new List<Dropdown.OptionData>();
        SceneFlag.Clear();
        NavigationFunction.ClearOptions();
        for (int i = 0; i < NavigationCanvas.transform.childCount; i++)
        {
            string SceneName = NavigationCanvas.transform.GetChild(i).name;
            Debug.Log("Scene name : " + SceneName);
            var flagOptionNavigate = new Dropdown.OptionData(SceneName);

            SceneFlag.Add(flagOptionNavigate);


        }
        CheckerScene = NavigationCanvas.transform.childCount;
        NavigationFunction.AddOptions(SceneFlag);
    }

    public void FunctionObjectSelection()
    {

        SelectedTargetFunction = TargetFunctions.captionText.text;
    }

    public void ActionOfTarget() {


    }
    public void OnClickTarget()
    {
        ObjectHotspot.ClickOnhotspot();
    }
}
