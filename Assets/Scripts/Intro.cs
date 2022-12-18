using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Plays a simple video intro of my logo.
/// </summary>
public class Intro : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer player;

    [SerializeField]
    private FadeAnimator fadeAnimator;

    void Update()
    {
        // Fade out, once the video has played back
        if (player.frame > 0 && !player.isPlaying)
        {
            fadeAnimator.FadeOut();
        }
    }
}
