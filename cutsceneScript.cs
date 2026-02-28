using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutsceneScript : MonoBehaviour
{
    public string sceneName;
    private dataHolder infoHolder;
    public TMP_Text characterName;
    public TMP_Text linesText;
    public SpriteRenderer background;
    public SpriteRenderer character;
    public string[] lines;
    public Sprite[] expressions;
    public Animator anim;
    public Color backColor;
    int n = 0;


    void Start()
    {
        infoHolder = GameObject.FindGameObjectsWithTag("InfoHolder")[0].GetComponent<dataHolder>();
        characterName.text = infoHolder.characterName;
        background.sprite = infoHolder.background;
        //background.color = infoHolder.backColor;
        background.color = Color.gray;
        sceneName = infoHolder.sceneName;


        lines = infoHolder.lines;
        expressions = infoHolder.expressions;


    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            n = Mathf.Min(n + 1, lines.Length - 1);
            //anim.SetTrigger("switch");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            n = Mathf.Max(0, n - 1);
            //anim.SetTrigger("switch");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(sceneName);
        }


        linesText.text = infoHolder.lines[n];
        character.sprite = infoHolder.expressions[n];
    }

}
