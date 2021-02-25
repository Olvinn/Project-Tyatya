using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController pc;

    public float minCamSize = 5;
    public float vShake;

    private float _gAngle;

    void Start()
    {
        _gAngle = 180;
        pc.onCollide.AddListener(CollisionReact);
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
        Camera.main.backgroundColor = Vector4.MoveTowards(Camera.main.backgroundColor, Color.black, Time.deltaTime * .5f);
    }

    void CollisionReact(float power, Color color)
    {
        StartCoroutine(Shaker(power, Camera.main.orthographicSize * .05f));
        power = Mathf.Min(power, 1);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, color, power);
    }

    IEnumerator Shaker(float power, float bias)
    {
        while (power > 0)
        {
            Vector2 offset = Random.insideUnitCircle * power * bias;
            Camera.main.transform.position += (Vector3)offset;

            power -= Time.unscaledDeltaTime * .5f;
            bias -= Time.unscaledDeltaTime;

            yield return new WaitForEndOfFrame();
        }
    }
}
