using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    [SerializeField] Transform PositionTransform = null;
    [SerializeField] Transform RotationTransform = null;
    private float PositionDampTime = 6f;
    private float RotationDampTime = 9f;
    private float Recoil1 = 35f;
    private float Recoil2 = 50f;
    private float Recoil3 = 35f;
    private float Recoil4 = 50f;
    [SerializeField] Vector3 Rotation;
    [SerializeField] Vector3 KickBack;
    private Vector3 CurrentRecoil1;
    private Vector3 CurrentRecoil2;
    private Vector3 CurrentRecoil3;
    private Vector3 CurrentRecoil4;
    private Vector3 RotationOutput;

    void FixedUpdate()
	{
		CurrentRecoil1 = Vector3.Lerp(CurrentRecoil1, Vector3.zero, Recoil1 * Time.deltaTime);
        CurrentRecoil2 = Vector3.Lerp(CurrentRecoil2, CurrentRecoil1, Recoil2 * Time.deltaTime);
        CurrentRecoil3 = Vector3.Lerp(CurrentRecoil3, Vector3.zero, Recoil3 * Time.deltaTime);
        CurrentRecoil4 = Vector3.Lerp(CurrentRecoil4, CurrentRecoil3, Recoil4 * Time.deltaTime);
        PositionTransform.localPosition = Vector3.Slerp(PositionTransform.localPosition, CurrentRecoil3, PositionDampTime * Time.fixedDeltaTime);
		RotationOutput = Vector3.Slerp(RotationOutput, CurrentRecoil1, RotationDampTime * Time.fixedDeltaTime);
		RotationTransform.localRotation = Quaternion.Euler(RotationOutput);
	}

    public void Fire()
	{
        CurrentRecoil1 += new Vector3(Rotation.x, Random.Range(-Rotation.y, Rotation.y), Random.Range(-Rotation.z, Rotation.z));
	    CurrentRecoil3 += new Vector3(Random.Range(-KickBack.x, KickBack.x), Random.Range(-KickBack.y, KickBack.y), KickBack.z);
	}
}