using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeMenu : MonoBehaviour
{
    // Declaring bounding sizes as specified in the task description. 
    private const int MAX_SIZE = 250;
    private const int MIN_SIZE = 10;

    [SerializeField]
    private Slider widthSlider, heightSlider;

    [SerializeField]
    private InputField widthInput, heightInput;

    [SerializeField]
    private MazeGenerator generator;

    [SerializeField]
    FadeAnimator fadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        widthInput.text     = "" + widthSlider.value;
        heightInput.text    = "" + heightSlider.value;
        generator.SetWidth ((int)widthSlider.value);
        generator.SetHeight((int)heightSlider.value);

        AddListeners();
        fadeAnimator.FadeIn();
    }

    /// <summary>
    /// Adds listeners to sliders and input fields.
    /// Converts values vice versa and passes them to generator.
    /// </summary>
    private void AddListeners()
    {
        // According to the API
        widthSlider.onValueChanged.AddListener(delegate {
            widthInput.text = "" + widthSlider.value;
            generator.SetWidth((int)widthSlider.value);
        });

        heightSlider.onValueChanged.AddListener(delegate {
            heightInput.text =  "" + heightSlider.value;
            generator.SetHeight((int)heightSlider.value);
        });

        widthInput.onEndEdit.AddListener(delegate {
            int.TryParse(widthInput.text, out int value);
            value = Mathf.Clamp(value, MIN_SIZE, MAX_SIZE);
            widthInput.text = "" + value;
            widthSlider.value = value;
            generator.SetWidth(value);
        });

        heightInput.onEndEdit.AddListener(delegate {
            int.TryParse(heightInput.text, out int value);
            value = Mathf.Clamp(value, MIN_SIZE, MAX_SIZE);
            heightInput.text = "" + value;
            heightSlider.value = value;
            generator.SetHeight(value);
        });
    }
}
