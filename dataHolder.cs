using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataHolder : MonoBehaviour
{
    public string sceneName;
    public string characterName;
    public Sprite background;
    public string[] lines;
    public Sprite[] expressions;
    public Color backColor;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
