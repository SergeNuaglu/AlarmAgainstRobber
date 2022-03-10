using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Light _alarmLight;
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private bool _isWork;
    [SerializeField] private float _blinkDuration;

    public void TurnOnAlarm()
    {
        StartCoroutine(Work());
        _alarmSound.GetComponent<AudioSource>().Play();
    }

    private IEnumerator Work()
    {
        float mixingRate = 0;

        yield return new WaitForSeconds(0.5f);

        while (_isWork)
        {
            if (mixingRate <= 0)
            {
                while (mixingRate < 1)
                {
                    Blink(mixingRate);
                    mixingRate += Time.deltaTime / _blinkDuration;
                    yield return null;
                }
            }
            else if (mixingRate >= 1)
            {
                while (mixingRate > 0)
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
