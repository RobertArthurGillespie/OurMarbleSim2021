using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hitCorrectObject = false;

    [SerializeField]
    AudioSource gameAudio;

    [SerializeField]
    AudioClip successAudio;

    [SerializeField]
    AudioClip hitRedAudio;
    [SerializeField]
    AudioClip hitBlueAudio;
    [SerializeField]
    AudioClip incorrectAudio;

    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    AudioClip currentChapterAudio;

    string currentChapterName;
    RaycastHit hit;
    Ray ray;

    public Chapter currentChapter;

    [SerializeField]
    int currentChapterCounter;
    [SerializeField]
    List<Chapter> chapters = new List<Chapter>();

    private void Awake()
    {
        //audioClips.Add("Hit Red", hitRedAudio);
        //audioClips.Add("Hit Blue", hitBlueAudio);

        foreach(Chapter c in chapters)
        {
            audioClips.Add(c.ChapterName, c.ChapterAudio);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.gameObject.name)
                {
                    case "RedCube":
                        Debug.Log("you hit the red cube!");
                        break;

                }

            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(GameStoryRefactored());
        }
    }


    private IEnumerator GameStory()
    {
        //update chapter name and audio
        currentChapterName = "Hit Red";
        Debug.Log("starting game sequence");
        while (true)
        {
            //if the user makes a selection, detect what it is
            if (hit.transform != null)
            {
                if (hit.transform.gameObject.name == "RedCube"&&Input.GetMouseButtonDown(0)&&!gameAudio.isPlaying)
                {
                    Debug.Log("selected cube: " + hit.transform.gameObject.name);
                    gameAudio.clip = audioClips[currentChapterName];
                    gameAudio.Play();
                    break;
                }
                else if (hit.transform.gameObject.name != "RedCube"&& Input.GetMouseButtonDown(0)&&!gameAudio.isPlaying)
                {
                    Debug.Log("not hitting the red cube");
                    gameAudio.clip = incorrectAudio;
                    gameAudio.Play();
                }
            }
            
            

            yield return null;
        }
        while (true)
        {
            if (!gameAudio.isPlaying)
            {
                currentChapterName = "Hit Blue";
                audioClips.TryGetValue(currentChapterName, out currentChapterAudio);
                gameAudio.clip = currentChapterAudio;
                
                Debug.Log("starting second chapter");
                break;

            }
            yield return null;
        }
        while (true)
        {
            
            if (hit.transform != null)
            {
                if (hit.transform.gameObject.name == "BlueCube" && Input.GetMouseButtonDown(0) && !gameAudio.isPlaying)
                {
                    Debug.Log("selected cube: " + hit.transform.gameObject.name);
                    gameAudio.clip = currentChapterAudio;
                    gameAudio.Play();
                    break;
                }
                else if (hit.transform.gameObject.name != "BlueCube" && Input.GetMouseButtonDown(0) && !gameAudio.isPlaying)
                {
                    Debug.Log("not hitting the blue cube");
                    gameAudio.clip = incorrectAudio;
                    gameAudio.Play();
                }
            }
            //next event, same checks
            yield return null;
        }
    }

    public IEnumerator GameStoryRefactored()
    {
        currentChapter = chapters[currentChapterCounter];
        while (true)
        {
            //if the user makes a selection, detect what it is
            if (hit.transform != null)
            {
                if (hit.transform.gameObject.name == currentChapter.CorrectObjectName && Input.GetMouseButtonDown(0) && !gameAudio.isPlaying)
                {
                    Debug.Log("selected cube: " + hit.transform.gameObject.name);
                    gameAudio.clip = audioClips[currentChapter.ChapterName];
                    gameAudio.Play();
                    //break;
                }
                else if (hit.transform.gameObject.name != currentChapter.CorrectObjectName && Input.GetMouseButtonDown(0) && !gameAudio.isPlaying)
                {
                    Debug.Log("not hitting the red cube");
                    gameAudio.clip = incorrectAudio;
                    gameAudio.Play();
                }
                else if (hitCorrectObject)
                {
                    SetCorrectHitBool(false);
                    break;
                }
            }
                       
            yield return null;
        }
        while (true)
        {
            if (!gameAudio.isPlaying)
            {
                Debug.Log("incrementing chapter");
                currentChapterCounter++;
                break;
            }
            yield return null;
        }
        if (currentChapterCounter < chapters.Count)
        {
            Debug.Log("starting next chapter");
            StartCoroutine(GameStoryRefactored());
        }
        yield return null;
    }

    public void PlayCorrectAudio()
    {
        gameAudio.clip = successAudio;
        gameAudio.Play();
    }

    public void SetCorrectHitBool(bool boolVal)
    {
        hitCorrectObject = boolVal;
    }
}
