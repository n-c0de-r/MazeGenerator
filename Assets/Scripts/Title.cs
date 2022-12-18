using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls behaviors of the titlescreen animation and quiting the game.
/// </summary>
public class Title : MonoBehaviour
{
    [SerializeField]
    private Box[] boxes;

    [SerializeField]
    private AudioSource sound;

    [SerializeField]
    private AudioSource music;

    [SerializeField]
    private GameObject menuPanel;

    /// <summary>
    /// Function for the quit button to execute.
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// When the title has dropped, it should trigger the sprites to change.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sound.Play();
        foreach (var box in boxes)
        {
            box.SwitchSprite();
        }

        menuPanel.SetActive(true);
    }

    private void Awake()
    {
        DontDestroyOnLoad(music);
    }
}
