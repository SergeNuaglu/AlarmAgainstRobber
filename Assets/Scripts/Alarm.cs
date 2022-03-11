using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Light _alarmLight;
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _blinkDuration;

    public void TurnOnAlarm()
    {
        StartCoroutine(Work());
        _alarmSound.GetComponent<AudioSource>().Play();
    }

    private IEnumerator Work()
    {
        bool isWork = true;
        float mixingRate = 0;
        float timeBeforeAlarm = 0.5f;
        int minValue = 0;
        int maxValue = 1;
        
        yield return new WaitForSeconds(timeBeforeAlarm);

        while (isWork)
        {
            if (mixingRate <= minValue)
            {
                while (mixingRate < maxValue)
                {
                    Blink(mixingRate);
                    mixingRate += Time.deltaTime / _blinkDuration;
                    yield return null;
                }
            }
            else if (mixingRate >= maxValue)
            {
                while (mixingRate > minValue)
                {
                    Blink(mixingRate);
                    mixingRate -= Time.deltaTime / _blinkDuration;
                    yield return null;
                }
            }
        }
    }

    private void Blink(float mixingRate)
    {
        float minVolume = 0;
        float maxVolume = 1;

        _alarmSound.volume = Mathf.MoveTowards(minVolume, maxVolume, mixingRate);
        _alarmLight.color = Color.Lerp(Color.red, Color.black, mixingRate);
    }
}
