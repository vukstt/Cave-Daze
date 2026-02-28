using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutsceneStarter : MonoBehaviour
{
    private dataHolder infoHolder;
    public Color backColor;
    public string sceneName;
    public string characterName;
    public Sprite background;
    public string[] lines;
    public Sprite[] expressions;
    
    void Start()
    {
        infoHolder = GameObject.FindGameObjectsWithTag("InfoHolder")[0].GetComponent<dataHolder>();
    }
    //string sceneName, Sprite background, (string, Sprite)[] lines
    public void StartCutscene()
    {
        

    }

    public void aihsdk()
    {
        
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Cutscene");
        infoHolder.characterName = characterName;
        infoHolder.background = background;
        infoHolder.backColor = backColor;
        infoHolder.lines = lines;
        infoHolder.expressions = expressions;
        infoHolder.sceneName = sceneName;
    }
}
