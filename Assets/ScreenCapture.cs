using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenCapture : MonoBehaviour
{
    public int FileCounter = 0;
    private RenderTexture _targetRenderTexture;
    private Texture2D _cameraFeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateTextures();
            StartCoroutine(CaptureScreenshot());
        }
    }

    private void CreateTextures()
    {
        _targetRenderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        _cameraFeed = new Texture2D(Screen.width, Screen.height);
    }

    public IEnumerator CaptureScreenshot()
    {
        Debug.Log("CaptureScreenshot running");
        yield return new WaitForEndOfFrame();

        if (_targetRenderTexture.width != Screen.width || _targetRenderTexture.height != Screen.height)
        {
            CreateTextures();
        }
        Graphics.Blit(this.gameObject.GetComponent<Camera>().activeTexture, _targetRenderTexture);
        RenderTexture.active = _targetRenderTexture;

        _cameraFeed.ReadPixels(new Rect(0, 0, _cameraFeed.width, _cameraFeed.height), 0, 0);
        _cameraFeed.Apply();

        byte[] bytes;
        bytes = _cameraFeed.EncodeToPNG();


        if (Directory.Exists(Application.dataPath + "/Backgrounds"))
        {
            if (!File.Exists(Application.dataPath + "/Backgrounds/" + FileCounter + ".png"))
            {
                File.WriteAllBytes(Application.dataPath + "/Backgrounds/" + FileCounter + ".png", bytes);
            }
            else
            {
                File.Delete(Application.dataPath + "/Backgrounds/" + FileCounter + ".png");
                File.WriteAllBytes(Application.dataPath + "/Backgrounds/" + FileCounter + ".png", bytes);
            }
        }
        else
        {
            Directory.CreateDirectory(Application.dataPath + "/Backgrounds");
            File.WriteAllBytes(Application.dataPath + "/Backgrounds/" + FileCounter + ".png", bytes);
        }

        FileCounter++;
    }

}
