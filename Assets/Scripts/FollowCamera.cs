using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    void Update()
    {
        //transform.position = target.transform.position;
    }

    public float duration;
    public float magnitude;

    public void Shake()
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    IEnumerator Shake(float duration, float magnitude)
    {

        Debug.Log("shake");
        Vector3 originPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = Vector3.zero;

    }


}
