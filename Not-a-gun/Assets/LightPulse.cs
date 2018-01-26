using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour {
    public float PulseRate = 0.010f;
    public float MaxIntencity = 1.0f;
    public float MinIntencity = 0.2f;
    private Light _pulselight;
    private bool _intencityUp;
    private List<Color> _colors;

    public bool IntencityUp
    {
        get
        {
            return _intencityUp;
        }

        set
        {
            _intencityUp = value;
            if (value)
            {
                _pulselight.color = _colors[(_colors.IndexOf(_pulselight.color) + 1) == _colors.Count ? 0 : (_colors.IndexOf(_pulselight.color) + 1)];
            }
        }
    }

    // Use this for initialization
    void Start () {
        _pulselight = this.GetComponent<Light>();
        _colors.Add(Color.blue);
        _colors.Add(Color.red);
        _pulselight.color = _colors[0];
    }
	
	// Update is called once per frame
	void Update ()
	{
	    var inTents = _pulselight.intensity;

        if (IntencityUp)
	    {
	        if (_pulselight.intensity >= MaxIntencity)
	        {
	            IntencityUp = false;
	            return;
	        }
	        _pulselight.intensity = inTents + PulseRate;
        }
	    else
        {
            if (_pulselight.intensity <= MinIntencity)
            {
                IntencityUp = true;
                return;
            }
            _pulselight.intensity = inTents - PulseRate;
        }
	}
}
