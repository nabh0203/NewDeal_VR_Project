using System.Collections.Generic;
using UnityEngine;

namespace Oculus.Interaction
{
    public class CustomGrabbable : PointableElement, IGrabbable
    {
        [SerializeField, Interface(typeof(ITransformer))]
        [Optional(OptionalAttribute.Flag.AutoGenerated)]
        private UnityEngine.Object _oneGrabTransformer = null;

        [SerializeField, Interface(typeof(ITransformer)), Optional]
        private UnityEngine.Object _twoGrabTransformer = null;

        [Tooltip("The target transform of the Grabbable. If unassigned, " +
            "the transform of this GameObject will be used.")]
        [SerializeField]
        [Optional(OptionalAttribute.Flag.AutoGenerated)]
        private Transform _targetTransform;

        [SerializeField]
        private int _maxGrabPoints = -1;

        public int MaxGrabPoints
        {
            get
            {
                return _maxGrabPoints;
            }
            set
            {
                _maxGrabPoints = value;
            }
        }

        public Transform Transform => _targetTransform;
        public List<Pose> GrabPoints => _selectingPoints;

        private ITransformer _activeTransformer = null;
        private ITransformer OneGrabTransformer;
        private ITransformer TwoGrabTransformer;

        private Rigidbody _rigidbody;

        protected override void Awake()
        {
            base.Awake();
            OneGrabTransformer = _oneGrabTransformer as ITransformer;
            TwoGrabTransformer = _twoGrabTransformer as ITransformer;
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected override void Start()
        {
            this.BeginStart(ref _started, () => base.Start());

            if (_targetTransform == null)
            {
                _targetTransform = transform;
            }

            if (_oneGrabTransformer != null)
            {
                this.AssertField(OneGrabTransformer, nameof(OneGrabTransformer));
                OneGrabTransformer.Initialize(this);
            }

            if (_twoGrabTransformer != null)
            {
                this.AssertField(TwoGrabTransformer, nameof(TwoGrabTransformer));
                TwoGrabTransformer.Initialize(this);
            }

            // Create a default if no transformers assigned
            if (OneGrabTransformer == null &&
                TwoGrabTransformer == null)
            {
                OneGrabFreeTransformer defaultTransformer = gameObject.AddComponent<OneGrabFreeTransformer>();
                _oneGrabTransformer = defaultTransformer;
                OneGrabTransformer = defaultTransformer;
                OneGrabTransformer.Initialize(this);
            }

            this.EndStart(ref _started);
        }

        public override void ProcessPointerEvent(PointerEvent evt)
        {
            switch (evt.Type)
            {
                case PointerEventType.Select:
                    EndTransform();
                    break;
                case PointerEventType.Unselect:
                    EndTransform();
                    break;
                case PointerEventType.Cancel:
                    EndTransform();
                    break;
            }

            base.ProcessPointerEvent(evt);

            switch (evt.Type)
            {
                case PointerEventType.Select:
                    BeginTransform();
                    break;
                case PointerEventType.Unselect:
                    BeginTransform();
                    break;
                case PointerEventType.Move:
                    UpdateTransform();
                    break;
            }
        }

        // Whenever we change the number of grab points, we save the
        // current transform data
        public void BeginTransform()
        {
            // End the transform on any existing transformer before we
            // begin the new one
            EndTransform();

            int useGrabPoints = _selectingPoints.Count;
            if (_maxGrabPoints != -1)
            {
                useGrabPoints = Mathf.Min(useGrabPoints, _maxGrabPoints);
            }

            switch (useGrabPoints)
            {
                case 1:
                    _activeTransformer = OneGrabTransformer;
                    break;
                case 2:
                    _activeTransformer = TwoGrabTransformer;
                    _rigidbody.isKinematic = false;
                    _rigidbody.useGravity = true;
                    break;
                default:
                    _activeTransformer = null;
                    break;
            }

            if (_activeTransformer == null)
            {
                return;
            }

            _activeTransformer.BeginTransform();
        }

        private void UpdateTransform()
        {
            if (_activeTransformer == null)
            {
                return;
            }

            _activeTransformer.UpdateTransform();
        }

        public void EndTransform()
        {
            if (_activeTransformer == null)
            {
                return;
            }
            _activeTransformer.EndTransform();
            _activeTransformer = null;

            if (_selectingPoints.Count == 0)
            {
                _rigidbody.isKinematic = true;
                _rigidbody.useGravity = false;
            }
        }

        protected override void OnDisable()
        {
            if (_started)
            {
                EndTransform();
            }

            base.OnDisable();
        }

        #region Inject

        public void InjectOptionalOneGrabTransformer(ITransformer transformer)
        {
            _oneGrabTransformer = transformer as UnityEngine.Object;
            OneGrabTransformer = transformer;
        }

        public void InjectOptionalTwoGrabTransformer(ITransformer transformer)
        {
            _twoGrabTransformer = transformer as UnityEngine.Object;
            TwoGrabTransformer = transformer;
        }

        public void InjectOptionalTargetTransform(Transform targetTransform)
        {
            _targetTransform = targetTransform;
        }

        #endregion
    }
}
