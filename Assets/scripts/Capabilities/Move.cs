using UnityEngine;

namespace Shinjingi
{
    // Controls Ember's movement physics
    [RequireComponent(typeof(Controller))]
    public class Move : MonoBehaviour
    {
        [SerializeField, Range(0f, 100f)] private float _maxSpeed = 4f;
        [SerializeField, Range(0f, 100f)] private float _maxAcceleration = 35f;
        [SerializeField, Range(0f, 100f)] private float _maxAirAcceleration = 20f;

        private Controller _controller;
        private Vector2 _direction, _desiredVelocity, _velocity;
        private Rigidbody2D _body;
        private Ground _ground;

        private float _maxSpeedChange, _acceleration;
        private bool _onGround;
        private float prev_x = 0;

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            _ground = GetComponent<Ground>();
            _controller = GetComponent<Controller>();
        }

        private void Update()
        {
            _direction.x = _controller.input.RetrieveMoveInput();
            _desiredVelocity = new Vector2(_direction.x, 0f) * Mathf.Max(_maxSpeed - _ground.Friction, 0f);
        }

        private void FixedUpdate()
        {
            _onGround = _ground.OnGround;
            // Debug.Log(_onGround);
            if(_onGround){
                // prev_x = 0;
            }
            _velocity = _body.velocity;
            _acceleration = _maxAcceleration;
            // _acceleration = _onGround ? _maxAcceleration : _maxAirAcceleration;
            _maxSpeedChange = _acceleration * Time.deltaTime;
            
            _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, _maxSpeedChange);
            // if(prev_x != _velocity.x){
            //     _body.velocity = _velocity;
            // }
            _body.velocity = _velocity;
            prev_x = _velocity.x;
        }
    }
}
