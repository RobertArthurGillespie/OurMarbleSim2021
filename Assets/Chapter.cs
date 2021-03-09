using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chapter",menuName = "Chapters",order = 51)]
public class Chapter : ScriptableObject
{
    [SerializeField]
    string chapterName;
    [SerializeField]
    AudioClip chapterSuccessAudio;
    [SerializeField]
    string correctObjectName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string ChapterName
    {
        get
        {
            return chapterName;
        }
    }

    public AudioClip ChapterAudio
    {
        get
        {
            return chapterSuccessAudio;
        }
    }

    public string CorrectObjectName
    {
        get
        {
            return correctObjectName;
        }
    }

}
