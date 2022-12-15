using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Plays a simple video intro of my logo.
/// </summary>
public class Intro : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer player;

    [SerializeField]
    private FadeAnimator fadeAnimator;

    private long frames;

    // Start is called before the first frame update
    void Start()
    {
        frames = (long)player.frameCount-1;
    }

    void Update()
    {
        if (player.frame == frames)
        {
            // Once the frames are all done, fade out.
            fadeAnimator.FadeOut();
        }
    }
}
