using UnityEngine;

public class Wood : MonoBehaviour {

    public GameObject gWood;
    private Vector2[] WoodPos = new Vector2[8] { new Vector2(-1.02f,  1.02f), 
                                                 new Vector2( 0.01f,  1.05f), 
                                                 new Vector2( 1.04f,  1.03f), 
                                                 new Vector2( 1.04f,   0.1f),
                                                 new Vector2( 1.04f, -0.95f), 
                                                 new Vector2(    0f, -0.92f),
                                                 new Vector2(-0.96f, -0.93f), 
                                                 new Vector2(-1.01f, -0.01f)};


    public void SetWood(int nWood)
    {
        GameObject obj = Instantiate<GameObject>(gWood);
        obj.transform.position = WoodPos[nWood];
    }
}
