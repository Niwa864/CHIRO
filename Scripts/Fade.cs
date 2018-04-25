using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {
    public static string Stage;
    public static int ClrFlg;
    public static bool bGoTitle;
    string FromMain;
    public static bool bReturn;
    public static bool bTitle;
    public static bool bOneMore = false;
    public static int nAlfa;
    private bool bOnce;
    private bool bUninit;
    private int nClear;

    void Start()
    {
        nAlfa = 0;
        bOnce = true;
        bUninit = true;

        if(bTitle == false && bGoTitle == false)
            Stage = StageTouch.sStage;

        if (bReturn == true)
        {
            FromMain = Stage;
            Stage = "Stage";
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        if (nAlfa == 1 && bOnce == true)
        {

            Enemy.sReturnStage = Stage;
            Blocks.sReturn = Stage;

            if (bReturn == true && bTitle == false)
            {
                SceneManager.UnloadSceneAsync(FromMain);

                if (ClrFlg == 0)
                    SceneManager.UnloadSceneAsync("Clear");
                else if (ClrFlg == 1)
                    SceneManager.UnloadSceneAsync("Fail");
                else if (ClrFlg == 2)
                    SceneManager.UnloadSceneAsync("Stage5Fail");

                bReturn = false;
            }
            else if (bReturn == false && bTitle == false && bOneMore == false)
            {
                SceneManager.UnloadSceneAsync("Stage");
                bReturn = false;
            }

            if (bTitle == true)
            {
                SceneManager.UnloadSceneAsync("Title");
                bTitle = false;
            }

            if (bOneMore == true)
            {
                SceneManager.UnloadSceneAsync(Stage);
                bOneMore = false;
            }

            if (bGoTitle == true)
            {
                SceneManager.UnloadSceneAsync("Stage");
                bGoTitle = false;
            }

            SceneManager.LoadScene(Stage, LoadSceneMode.Additive);
            bOnce = false;
        }
        else if (nAlfa == 2 && bUninit == true)
        {
            SceneManager.UnloadSceneAsync("Fade");
            bUninit = false;
        }
	}
}