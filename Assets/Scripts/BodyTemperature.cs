using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TemperatureController : MonoBehaviour
{
    public Text temperatureText;
    [SerializeField]
    private float bodyTemperature = 37.0f;
    [SerializeField]
    private float temperatureDecreaseAmount = 0.05f;
    [SerializeField]
    private float waitSeconds = 1f;
    private WaitForSeconds waitTime;

    private void Start()
    {
        print("body temp start");
        waitTime = new WaitForSeconds(waitSeconds);       
    }

    private void OnEnable()
    {
       StartCoroutine(DecreaseTemperature());
    }

    private IEnumerator DecreaseTemperature()
    {
        while (true)
        {
            bodyTemperature -= temperatureDecreaseAmount;
            temperatureText.text = "Body temperature: " + bodyTemperature.ToString("F1");

            if(bodyTemperature < 35)
            {
                GameObject.Find("PostProcessManager").SendMessage("IntensifyVignette");
            }

            if(bodyTemperature < 28)
            {
                GameObject.Find("GameManager").SendMessage("GameOver");
            }
            yield return waitTime;
        }
    }
}
