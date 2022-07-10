using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    private Rigidbody rig;

    // Move object using accelerometer
    [SerializeField] private float speed = 10.0f;

    [SerializeField] bool inputX = true;
    [SerializeField] bool inputY = true;
    [SerializeField] bool inputZ = true;
    [SerializeField] bool onlyTransform = true;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();

        if (rig == null)
        {
            this.gameObject.AddComponent<Rigidbody>();
            rig = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        if (!GameManager_Level3.instance.inputEnabled && GameManager_Level3.instance != null)
            return;

        Vector3 dir = Vector3.zero;

        // we assume that device is held parallel to the ground
        // and Home button is in the right hand

        // remap device acceleration axis to game coordinates:
        //  1) XY plane of the device is mapped onto XZ plane
        //  2) rotated 90 degrees around Y axis
        dir.x = InputManager.instance.inputAcceleration.x;
        dir.y = InputManager.instance.inputAcceleration.z;
        dir.z = InputManager.instance.inputAcceleration.y;

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        dir *= speed;

        // Move object
        if (inputX && inputY && inputZ)
            rig.AddForce(dir.x, dir.y, dir.z);
        else if (inputX && !inputY && !inputZ)
            rig.AddForce(dir.x, 0, 0);
        else if (!inputX && inputY && !inputZ)
            rig.AddForce(0, dir.y, 0);
        else if (!inputX && !inputY && inputZ)
            rig.AddForce(0, 0, dir.z);

        if (onlyTransform)
            transform.Translate(0, dir.y, 0);
    }
}
