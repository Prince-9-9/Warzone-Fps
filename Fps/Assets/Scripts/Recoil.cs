using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{

    ////Rotation
    //private Vector3 currentRotation, targetRotation;

    ////Hipfire Recoil
    //[SerializeField] private float recoilX;
    //[SerializeField] private float recoilY;
    //[SerializeField] private float recoilZ;

    ////Settings
    //[SerializeField] private float snappiness;
    //[SerializeField] private float returnSpeed;


    //void Start()
    //{

    //}


    //void Update()
    //{
    //    targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, Time.deltaTime * returnSpeed);
    //    currentRotation = Vector3.Slerp(currentRotation, targetRotation, Time.fixedDeltaTime * snappiness);
    //    transform.localRotation = Quaternion.Euler(currentRotation);
    //}

    //public void RecoilFire()
    //{
    //    targetRotation += new Vector3(recoilX, Random.Range(-recoilY,recoilY), Random.Range(-recoilZ,recoilZ));
    //}






    Vector3 currentRotation, currentPosition, targetRotation, targetPosition, initialGunPosition;
    public Transform recoilCam;
    public Transform mainCam;

    [SerializeField] float recoilX;
    [SerializeField] float recoilY;
    [SerializeField] float recoilZ;

    [SerializeField] float kickBackZ;

    public float snappiness, returnAmount;

    // Start is called before the first frame update
    void Start()
    {
        initialGunPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, Time.deltaTime * returnAmount);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, Time.fixedDeltaTime * snappiness);
        transform.localRotation = Quaternion.Euler(currentRotation);
        recoilCam.localRotation = Quaternion.Euler(targetRotation);
        //mainCam.localRotation = Quaternion.Euler(currentRotation);
        back();
    }

    public void recoil()
    {
        targetPosition -= new Vector3(0, 0, kickBackZ);
        targetRotation += new Vector3(recoilX, 0, 0);
        //Debug.Log("REC"); 
    }

    void back()
    {
        targetPosition = Vector3.Lerp(targetPosition, initialGunPosition, Time.deltaTime * returnAmount);
        currentPosition = Vector3.Lerp(currentPosition, targetPosition, Time.fixedDeltaTime * snappiness);
        transform.localPosition = currentPosition;
    }
}