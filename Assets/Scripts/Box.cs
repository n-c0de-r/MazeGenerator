using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    private Sprite start; // The sprite each box starts with.

    [SerializeField]
    private Sprite end; // The sprite they all switch to.

    [SerializeField]
    private ParticleSystem particles; // The particles that emit on collision.

    [SerializeField]
    private ParticleSystem explosion; // The bigger particles emitted on sprite switch.

    [SerializeField]
    private AudioSource audio;

    private bool hasPlayed = false;

    /// <summary>
    /// When each box collides, they show an animation and play a sound.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y>0.5 && !hasPlayed) {
            audio.Play();
            particles.Play();
            hasPlayed = true;
        }
    }

    /// <summary>
    /// Once the title has dropped, each object changes their sprite.
    /// </summary>
    public void SwitchSprite()
    {
        explosion.Play();
        gameObject.GetComponent<SpriteRenderer>().sprite = end;
    }
}
