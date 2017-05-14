using UnityEngine;
using UnityEngine.UI;

public class PupulateLevels : MonoBehaviour {
    public GameObject leftParent;
    public GameObject rightParent;

    protected string levelAssetsPath = @"LevelAssets/";
    protected string levelButtonLeftTemplate = @"LevelAssets/UITemplates/LoadLevelButtonLeftTemplate";
    protected string levelButtonRightTemplate = @"LevelAssets/UITemplates/LoadLevelButtonRightTemplate";

    protected string lockPath = @"LevelAssets/UITemplates/Lock";
    protected string starRating = @"LevelAssets/UITemplates/StarRating";

    protected Vector3 leftOffset = new Vector3(0, 10, 0);
    protected GameObject[] levelButtons;

	// Use this for initialization
	void Awake ()
    {
        levelButtons = new GameObject[UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings-1]; ///NOTE: fix this later. Might not be a good long term solution]
        Debug.Log(levelButtons.Length);
        int index = 0;
        Sprite levelSelectTexture = Resources.Load<Sprite>(levelAssetsPath + "Level"+(index+1)+"/LevelSelect/LevelSelect");
        GameObject levelLeftButtonResource = Resources.Load<GameObject>(levelButtonLeftTemplate);
        GameObject levelRightButtonResource = Resources.Load<GameObject>(levelButtonRightTemplate);
        GameObject starRatingImageResource = Resources.Load<GameObject>(starRating);
        GameObject lockResource = Resources.Load<GameObject>(lockPath);

        RectTransform levelLeftButtonResTransform = levelLeftButtonResource.GetComponent<RectTransform>();
        float buttonHeight = levelLeftButtonResTransform.rect.height; //get once should be the same
        while (levelSelectTexture != null)
        {
            GameObject newButton = Instantiate((index % 2) == 0 ? levelLeftButtonResource: levelRightButtonResource, (index % 2) == 0 ? leftParent.transform : rightParent.transform);
            newButton.name = "Level" + (index + 1); 
            newButton.GetComponent<Image>().sprite = levelSelectTexture;
            newButton.transform.Translate(new Vector3(0, - index / 2 * (buttonHeight + leftOffset.y), 0));
            if (PlayerPrefs.HasKey(PlayerPrefKeys.STAR_RATING+index))
            {
                GameObject levelStatus = Instantiate(starRatingImageResource, newButton.transform);
                levelStatus.GetComponentInChildren<Text>().text = PlayerPrefs.GetString(PlayerPrefKeys.STAR_RATING + index);
            }
            else
            {
                if (index == 0)
                {
                    PlayerPrefs.SetString(PlayerPrefKeys.STAR_RATING + 0, "0");
                    GameObject levelStatus = Instantiate(starRatingImageResource, newButton.transform);
                    levelStatus.GetComponentInChildren<Text>().text = PlayerPrefs.GetString(PlayerPrefKeys.STAR_RATING + index);
                }
                else
                {
                    GameObject levelStatus = Instantiate(lockResource, newButton.transform);
                }
            }
            levelButtons[index] = newButton;
            ++index;
            levelSelectTexture = Resources.Load<Sprite>(levelAssetsPath + "Level" + (index + 1) + "/LevelSelect/LevelSelect");
        }
	}

    public void WonLevel(int index,int stars)
    {
        if (int.Parse(levelButtons[index].GetComponentInChildren<Text>().text) < stars)
        {
            levelButtons[index].GetComponentInChildren<Text>().text = stars.ToString();
        }
        if (index+1 == levelButtons.Length)
        {
            return; //My job here is done !!
        }
        if (levelButtons[index+1].GetComponentInChildren<Text>() == null)//no star staus, thus locked
        {
            Destroy(levelButtons[index + 1].transform.GetChild(0).gameObject); 
            Instantiate(Resources.Load<GameObject>(starRating),levelButtons[index+1].transform);
            levelButtons[index + 1].GetComponentInChildren<Text>().text = "0";
        }
    }

}
