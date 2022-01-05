using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController pc;
    [SerializeField] Volume vol;
    Vignette vignette;

    public float minCamSize = 5;
    public float vShake;

    private float _gAngle;

    void Start()
    {
        _gAngle = 180;
        pc.onCollide.AddListener(CollisionReact);
        vol.profile.TryGet(out vignette);
    }

    void LateUpdate()
    {
        if (!pc)
            return;
        Vector2 vEff = Random.insideUnitCircle * pc.v.magnitude * vShake;
        _gAngle = Mathf.MoveTowardsAngle(_gAngle, Vector2.SignedAngle(Vector2.up, Physics2D.gravity + vEff), Time.deltaTime * 360);
        Vector3 temp = pc.transform.position + pc.v;
        temp.z = -10;

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, temp, Time.deltaTime);
        Camera.main.transform.rotation = Quaternion.Euler(0, 0, 180 + _gAngle);
        Camera.main.orthographicSize = Mathf.Max(minCamSize, Mathf.Lerp(Camera.main.orthographicSize, pc.v.magnitude, Time.deltaTime));
        vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0, Time.deltaTime * .5f);
    }

    void CollisionReact(float power, Color color)
    {
        //StopAllCoroutines();
        StartCoroutine(Shaker(power, Camera.main.orthographicSize * .01f));
        power = Mathf.Min(power, 1);
        vignette.intensity.value = power;
        vignette.color.value = color;
    }

    IEnumerator Shaker(float power, float bias)
    {
        while (power > 0)
        {
            Vector2 offset = Random.insideUnitCircle * power * bias;
            Camera.main.transform.position += (Vector3)offset;

            power = Mathf.Lerp(power, 0, Time.unscaledDeltaTime * 5);
            bias -= Time.unscaledDeltaTime;

            yield return new WaitForEndOfFrame();
        }
    }
}
