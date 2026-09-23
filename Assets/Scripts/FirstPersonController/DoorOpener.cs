using DG.Tweening;
using Scratch.FirstPerson;
using UnityEngine;

namespace Assets.Scripts.FirstPersonController
{
    public class DoorOpener : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private Transform _doorCheckingObject;
        [SerializeField] private float _doorDistance = 2.5f;
        [SerializeField] private float _duration = 1f;

        private bool _isDoorClosed = true;
        private float _distance;

        private Vector3 _openValue = new Vector3(0, -90, 0);
        private Tweener _openCloseDoorTweener;


        public void OpenOrCloseDoor()
        {
            if (_distance > _doorDistance)
                return;

            if (_isDoorClosed)
            {
                _openCloseDoorTweener?.Kill();
                _openCloseDoorTweener = transform.DORotate(_openValue, _duration).SetEase(Ease.InOutBounce);
                _isDoorClosed = false;
            }
            else
            {
                _openCloseDoorTweener?.Kill();
                _openCloseDoorTweener = transform.DORotate(Vector3.zero, _duration);
                _isDoorClosed = true;
            }
        }





        //public void OpenOrCloseDoor()
        //{
        //    if (_distance > _doorDistance)
        //        return;

        //    if (_isDoorClosed)
        //    {
        //        _animator.Play("doorOpen");
        //        _isDoorClosed = false;
        //    }
        //    else
        //    {
        //        _animator.Play("doorClose");
        //        _isDoorClosed = true;
        //    }
        //}

        private void Update()
        {
            CheckDistance();
        }


        private void CheckDistance()
        {
            _distance = Vector3.Distance(_doorCheckingObject.transform.position,
                _playerController.transform.position);
        }
    }
}