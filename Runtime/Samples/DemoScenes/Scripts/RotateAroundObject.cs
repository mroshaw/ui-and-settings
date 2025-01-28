using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Samples
{
    public class RotateAroundObject : MonoBehaviour
    {
        #region Class Variables

        [BoxGroup("Settings")] [SerializeField] private Transform targetObject;
        [BoxGroup("Settings")] [SerializeField] private float rotateSpeed = 5.0f;
        [BoxGroup("Settings")] [SerializeField] private float distanceFromTarget = 10.0f;
        [BoxGroup("Settings")] [SerializeField] private float heightFromGround = 10.0f;
        #endregion

        #region Startup
        private void Start()
        {
            transform.position = targetObject.position + (targetObject.forward * distanceFromTarget);
            transform.position += Vector3.up * heightFromGround;
            transform.LookAt(targetObject);
        }
        #endregion

        #region Update
        private void Update()
        {
            transform.Translate(Vector3.right * (Time.deltaTime * rotateSpeed));
            transform.LookAt(targetObject);
        }
        #endregion
    }
}