using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ShakeEffect
{
    private float stength;
    private float length;
    private float lifeTime;
    private float targetStength = -1f;

    public ShakeEffect(float lifeTime, float stength)
    {
        this.lifeTime = lifeTime;
        this.length = this.lifeTime;
        this.stength = stength;
    }

    public void TransitionStrength(float targetStrength)
    {
        this.targetStength = targetStrength;
        if (this.targetStength < 0) this.targetStength = 0;
    }

    public float GetLength()
    {
        return length;
    }
    public void UpdateLength()
    {
        length -= Time.deltaTime;
    }

    public float GetStrength()
    {
        if (targetStength >= 0)
        {
            return Mathf.Lerp(targetStength, stength, length/lifeTime);
        }
        else
        {
            return stength;
        }
    }
}

public class CameraShake : MonoBehaviour {
    
	public Camera cameraToShake;
	private Vector3 initialPos;
    private List<ShakeEffect> shakeEffects;
    
    void Start () {
        shakeEffects = new List<ShakeEffect>();
		initialPos = cameraToShake.transform.position;
    }
	
	void Update ()
    {
        for (int i = 0; i < shakeEffects.Count; i++)
        {
            if (shakeEffects[i].GetLength() > 0)
            {
                shakeEffects[i].UpdateLength();
            }
            else
            {
                shakeEffects.RemoveAt(i);
            }
        }
        if (shakeEffects.Count > 0)
        {
            float strengthMultiplier = 0;
            for (int i = 0; i < shakeEffects.Count; i++)
            {
                if (shakeEffects[i].GetStrength() > strengthMultiplier)
                {
                    strengthMultiplier = shakeEffects[i].GetStrength();
                }
            }
            float shakeRange = 0.2f * strengthMultiplier;
			cameraToShake.transform.position = new Vector3(initialPos.x + Random.Range(-shakeRange, shakeRange), initialPos.y + Random.Range(-shakeRange, shakeRange), -10);
        }
        else
        {
			cameraToShake.transform.position = initialPos;
        }
    }

    public void ShakeCamera(float length, float stength)
    {
        ShakeEffect newEffect = new ShakeEffect(length, stength);
        shakeEffects.Add(newEffect);
    }

    public void ShakeCamera(float length, float stength, float fadeToStrength)
    {
        ShakeEffect newEffect = new ShakeEffect(length, stength);
        newEffect.TransitionStrength(fadeToStrength);
        shakeEffects.Add(newEffect);
    }

    public void StopCamera()
    {
        shakeEffects.Clear();
    }
}
