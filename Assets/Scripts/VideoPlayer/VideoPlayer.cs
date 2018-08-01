using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        get_video(GameManager.VideoName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void get_video(string name)
    {
        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.url = "Assets/Resources/video/" + name;
        videoPlayer.Play();
    }

    private void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }
}
