using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArtifactHealthUI : MonoBehaviour
{
    [SerializeField] Slider artifactHealthSlider;
    [SerializeField] private Artifact artifact;

    private void Start()
    {
        artifactHealthSlider.maxValue = artifact.maxHealth;
        artifactHealthSlider.value = artifact.maxHealth;

    }
    private void Update()
    {
        if (artifact)
        {
            artifactHealthSlider.value = artifact.health;
        }
        else
        {
            artifactHealthSlider.value = 0;
        }
    }
}
