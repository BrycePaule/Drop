using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;

    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Vector3 _offset;

   
    private void LateUpdate()
    {
        Vector3 desiredPos = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, _smoothSpeed * Time.deltaTime);
        FadeObscurers();
    }


    private void FadeObscurers()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.down, _offset.y);

        Debug.DrawRay(transform.position, Vector3.down * _offset.y, Color.yellow, 0f, false);

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.layer == 8) { continue; }

            hit.transform.gameObject.SetActive(false);
        }
    }

}
