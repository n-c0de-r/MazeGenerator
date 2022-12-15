using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Prefab object, can be used to fade in and out of scenes.
/// </summary>
public class FadeAnimator : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    /// <summary>
    /// Fades in from black.
    /// </summary>
    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }

    /// <summary>
    /// Fades out to black.
    /// </summary>
    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }

    /// <summary>
    /// Enables this object if needed again.
    /// </summary>
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Loads a scene with the specified index.
    /// Called after a fade out.
    /// </summary>
    /// <param name="index">Index of the scene to load.</param>
    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    /// <summary>
    /// Disables the overlay image containing this.
    /// Called after a fade in.
    /// </summary>
    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
