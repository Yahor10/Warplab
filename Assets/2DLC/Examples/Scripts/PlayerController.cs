using UnityEngine;
using System.Collections;

namespace _2DLC.Examples {
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour {

        public Transform body;
        [Range(0, 1)]
        public float volume = 1f;
        public float groundDistance = 0.5f;     // Detecting the distance to ground
        public float moveSpeed = 8f;			// Movement speed
        public float jumpForce = 450f;			// Jumping force
        public bool multihop, is2DRigidbody;
        public AudioClip[] jumpClips;			// Arsenal clips for player jumping

        private Animator animator;
        //private Camera cam;
        private bool facingRight, onGround, jump;

        void Awake() {
            animator = GetComponent<Animator>();
            //cam = Camera.main;
        }

        void Start() {
            facingRight = true;
        }

        void Update() {
            AudioListener.volume = volume;

            Vector2 groundPos = new Vector2(transform.position.x,
                (transform.position.y - body.GetComponent<Renderer>().bounds.size.y / 2) - groundDistance);
            onGround = Physics2D.Linecast(transform.position, groundPos, 1 << LayerMask.NameToLayer("Ground"));

            if (Input.GetButtonDown("Jump") && (onGround || multihop)) {
                jump = true;
            }
        }

        void FixedUpdate() {
            float h = Input.GetAxis("Horizontal");

            animator.SetFloat("Speed", Mathf.Abs(h));
            animator.SetBool("OnGround", onGround);

            if (jump) {
                animator.SetTrigger("Jump");

                int i = Random.Range(0, jumpClips.Length);
                AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

                if (is2DRigidbody) {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
                } else {
                    GetComponent<Rigidbody>().AddForce(new Vector2(0f, jumpForce));
                }

                jump = false;
            }

            /*
            float targetX = transform.position.x + h * moveSpeed * Time.deltaTime;
            float camHalfWidth = cam.orthographicSize * cam.aspect;
            float minX = cam.transform.position.x - camHalfWidth;
            float maxX = cam.transform.position.x + camHalfWidth;

            transform.position =
                new Vector3(Mathf.Clamp(targetX, minX, maxX),
                    transform.position.y, transform.position.z);*/

            float targetX = transform.position.x + h * moveSpeed * Time.deltaTime;
            transform.position =
                new Vector3(targetX, transform.position.y, transform.position.z);
            //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);

            if (h > 0 && !facingRight) {
                Flip();
            } else if (h < 0 && facingRight) {
                Flip();
            }
        }

        void Flip() {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            facingRight = !facingRight;
        }

        public bool IsFacingRight() {
            return facingRight;
        }
    }
}
