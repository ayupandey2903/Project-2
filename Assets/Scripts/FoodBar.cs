using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    // public variables with tooltips
    [Tooltip("Hunger Slider")] public Slider hungerSlider;                          // Slider for hunger
    [Tooltip("Slider Gradient for image fill")] public Gradient gradient;           // Gradient for the slider
    [Tooltip("Image fill")] public Image fill;                                      // Fill of the slider

    public void SetMaxHunger(int hunger)
    {
        hungerSlider.maxValue = hunger;
        hungerSlider.value = hunger;

        fill.color = gradient.Evaluate(1f);                                         // set the color of the slider
    }

    public void SetHunger(int hunger)
    {
        hungerSlider.value = hunger;

        fill.color = gradient.Evaluate(hungerSlider.normalizedValue);               // set the color of the slider
    }
}
