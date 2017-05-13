using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class PupulateLevels : MonoBehaviour {
    public GameObject leftParent;
    public GameObject rightParent;

    protected string levelAssetsPath = @"LevelAssets/";
    protected string levelButtonLeftTemplate = @"LevelAssets/UITemplates/LoadLevelButtonLeftTemplate";
    protected string levelButtonRightTemplate = @"LevelAssets/UITemplates/LoadLevelButtonRightTemplate";

    protected Vector3 leftOffset = new Vector3(0, 10, 0);

	// Use this for initialization
	void Awake ()
    {
        int index = 0;
        Sprite levelSelectTexture = Resources.Load<Sprite>(levelAssetsPath + "Level"+(index+1)+"/LevelSelect/LevelSelect");
        GameObject levelLeftButtonResource = Resources.Load<GameObject>(levelButtonLeftTemplate);
        GameObject levelRightButtonResource = Resources.Load<GameObject>(levelButtonRightTemplate);

        RectTransform levelLeftButtonResTransform = levelLeftButtonResource.GetComponent<RectTransform>();
        float buttonHeight = levelLeftButtonResTransform.rect.height; //get once should be the same
        while (levelSelectTexture != null)
        {
            GameObject newButton = Instantiate((index % 2) == 0 ? levelLeftButtonResource: levelRightButtonResource, (index % 2) == 0 ? leftParent.transform : rightParent.transform);
            newButton.name = "Level" + (index + 1); 
            newButton.GetComponent<Image>().sprite = levelSelectTexture;
            newButton.transform.Translate(new Vector3(0, - index / 2 * (buttonHeight + leftOffset.y), 0));
            ++index;
            levelSelectTexture = Resources.Load<Sprite>(levelAssetsPath + "Level" + (index + 1) + "/LevelSelect/LevelSelect");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
