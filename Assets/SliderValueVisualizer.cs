using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SliderValueVisualizer : MonoBehaviour
{
    [SerializeField] Slider maxGoalsSlider;

    private void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = 3.ToString();
    }
    public void UpdateTextValue()
    {
        this.GetComponent<TextMeshProUGUI>().text = maxGoalsSlider.value.ToString();

    }
}
