using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetPreviewFunction : MonoBehaviour {

    public Vector3 TargetPosition;
    public string TargetFunctionType;
    public string TargetFunctionData;
    public GameObject NavigationContainerPrv;
    public string NavTo;
    public Vector3 rotationView;
    public float Z_pos;
    // Use this for initialization
    private void Update()
    {
        if (NavigationContainerPrv == null) {

            NavigationContainerPrv = gameObject.transform.parent.parent.gameObject;
            gameObject.transform.parent.transform.localScale = new Vector3(Z_pos, Z_pos, Z_pos);
            gameObject.transform.localPosition = new Vector3(1,1,1);
            gameObject.transform.parent.transform.localPosition = TargetPosition;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "ObjectModel") {

            if (TargetFunctionType == "Navigation")
            {
                NavTo = TargetFunctionData;
                for (int i = 0; i < NavigationContainerPrv.transform.childCount; i++)

                {
                    Debug.Log(NavigationContainerPrv.transform.GetChild(i).gameObject.name + " :: " + NavTo);
                    Debug.Log(NavTo);
                    if (NavTo == NavigationContainerPrv.transform.GetChild(i).GetComponent<PreviewScene>().sceneName)
                    {

                        NavigationContainerPrv.transform.GetChild(i).gameObject.SetActive(true);
                        //set camera rot eulervalues to given rotationView    
                        NavigationContainerPrv.transform.GetChild(i).gameObject.GetComponent<PreviewScene>().camPos = rotationView;

                    }
                    else
                    {
                        NavigationContainerPrv.transform.GetChild(i).gameObject.SetActive(false);
                    }

                }
            }
            if (TargetFunctionType == "Text Box") {

                GameObject DisplayText = gameObject.transform.parent.GetComponentInChildren<HideInfo>().gameObject;
                DisplayText.SetActive(true);
                DisplayText.GetComponent<HideInfo>().RequireMsg = true;
                TriLib.Samples.PreviewHotspot previewHotspot = gameObject.transform.parent.GetComponent<TriLib.Samples.PreviewHotspot>();
                previewHotspot.Always = true;
                previewHotspot.GetMsg = TargetFunctionData;
               
            }
        }
    }


}
