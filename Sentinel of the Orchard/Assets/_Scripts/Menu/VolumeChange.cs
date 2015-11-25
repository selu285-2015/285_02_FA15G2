using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{

    [SerializeField]
    private Slider volSlider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeVolume()
    {
        AudioListener.volume = (volSlider.value) / 10;
    }
}
