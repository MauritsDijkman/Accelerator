using System.Collections;
using UnityEngine;

public class Rotation_Scene1 : MonoBehaviour
{
    [Header("Rotating values")]
    [SerializeField] private float rotatingTime = 0.3f;
    [SerializeField] private float rotatingAngle = 90.0f;

    [Header("Phone sensitivity")]
    [SerializeField] private float sensitivity = 0.1f;

    [Header("Direction to rotate")]
    [SerializeField] private bool rotateLeft;
    [SerializeField] private bool rotateRight;

    private bool rotating = false;
    private bool originalState = true;

    private void Update()
    {
        // Forward naar links
        // Back naar rechts

        //Debug.Log($"Go left: {InputManager.instance.inputAcceleration.x < sensitivity * -1} || Rotating: {rotating} || Original state: {originalState}");

        if (rotateLeft)
        {
            if (InputManager.instance.inputAcceleration.x < sensitivity * -1 && !rotating && originalState)
            {
                rotating = true;
                StartCoroutine(RotateMe(Vector3.forward * rotatingAngle, rotatingTime));
            }
            else if (InputManager.instance.inputAcceleration.x > sensitivity && !rotating && !originalState)
            {
                rotating = true;
                StartCoroutine(RotateMe(Vector3.back * rotatingAngle, rotatingTime));
            }
        }
        else if (rotateRight)
        {
            if (InputManager.instance.inputAcceleration.x < sensitivity * -1 && !rotating && !originalState)
            {
                rotating = true;
                StartCoroutine(RotateMe(Vector3.forward * rotatingAngle, rotatingTime));
            }
            else if (InputManager.instance.inputAcceleration.x > sensitivity && !rotating && originalState)
            {
                rotating = true;
                StartCoroutine(RotateMe(Vector3.back * rotatingAngle, rotatingTime));
            }
        }
    }

    private IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);

        for (var t = 0f; t <= 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }

        transform.rotation = toAngle;
        rotating = false;

        if (rotateLeft)
        {
            if (Mathf.Approximately(transform.rotation.eulerAngles.z, rotatingAngle))
                originalState = false;
            else if (Mathf.Approximately(transform.rotation.eulerAngles.z, 0.0f))
                originalState = true;
        }
        else if (rotateRight)
        {
            if (Mathf.Approximately(-transform.rotation.eulerAngles.z / 3, -rotatingAngle))
                originalState = false;
            else if (Vector3.Distance(transform.rotation.eulerAngles, new Vector3(0, 0, 0)) <= 0.01)
                originalState = true;
        }
    }
}
