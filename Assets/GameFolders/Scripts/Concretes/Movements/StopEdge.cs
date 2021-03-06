using UdemyProject.Abstracts.Movements;
using UnityEngine;

namespace UdemyProject.Movements
{
    public class StopEdge : MonoBehaviour , IStopEdge
    {
        [SerializeField] private float distance = 0.1f;
        [SerializeField] private LayerMask layermask;

        private Collider2D _collider;
        private float _direction;
        
        public bool IsRightDirection { get; private set; }

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _direction = transform.localScale.x;
        }

        public bool ReachEdge()
        {
            float x = GetXPosition();
            float y = _collider.bounds.min.y;

            Vector2 origin = new Vector2(x, y);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distance, layermask);
            Debug.DrawRay(origin, Vector2.down * distance, Color.red);

            //if hit.collider doesn't hit selected layermask return false.
            if (hit.collider != null)
            {
                _direction = transform.localScale.x;
                return false;
            }
            //if hit return true.
            return true;
        }

        private float GetXPosition()
        {
            IsRightDirection = _direction == 1f; 
            
            if (IsRightDirection)
            {
                return _collider.bounds.max.x;
            }
            else
            {
                return _collider.bounds.min.x;
            }
        }
    }
}
