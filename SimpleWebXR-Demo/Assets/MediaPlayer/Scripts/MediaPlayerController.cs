using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(1.0f);

        var videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();

        // Play on awake defaults to true. Set it to false to avoid the url set
        // below to auto-start playback since we're in Start().
        videoPlayer.playOnAwake = false;

        // By default, VideoPlayers added to a camera will use the far plane.
        // Let's target the near plane instead.
        //videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        // This will cause our Scene to be visible through the video being played.
        videoPlayer.targetCameraAlpha = 0.5F;

        // Set the video to play. URL supports local absolute or relative paths.
        // Here, using absolute.
        videoPlayer.url = Application.streamingAssetsPath + "/Bunny.mp4";

        // Skip the first 100 frames.
        videoPlayer.frame = 100;

        // Restart from beginning when done.
        videoPlayer.isLooping = true;

        // Start playback. This means the VideoPlayer may have to prepare (reserve
        // resources, pre-load a few frames, etc.). To better control the delays
        // associated with this preparation one can use videoPlayer.Prepare() along with
        // its prepareCompleted event.
        videoPlayer.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
