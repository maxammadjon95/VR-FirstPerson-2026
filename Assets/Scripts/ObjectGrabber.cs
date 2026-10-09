using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
	public class ObjectGrabber : MonoBehaviour
	{
		[SerializeField] private Rigidbody _objRigidbody;
        [SerializeField] private float _grabDistance = 1.5f;
        [SerializeField] private Transform _parent;
        private float _distance;
        private bool _isGrabbed;

        private void Update()
        {
            _distance = Vector3.Distance(transform.position, _objRigidbody.position);
            var keyboard = Keyboard.current;
            if (keyboard.fKey.wasPressedThisFrame && _distance < _grabDistance)
            {
                if (!_isGrabbed)
                    Grab();
                else
                    DetachObject();
            }
        }

        private void Grab()
        {
            _objRigidbody.isKinematic = true;
            _objRigidbody.useGravity = false;
            _objRigidbody.transform.parent = _parent;
            _objRigidbody.transform.localPosition = Vector3.zero;
            _isGrabbed = true;
        }

        private void DetachObject()
        {
            _objRigidbody.isKinematic = false;
            _objRigidbody.useGravity = true;
            _objRigidbody.transform.parent = null;
            _isGrabbed = false;
        }
    }
}