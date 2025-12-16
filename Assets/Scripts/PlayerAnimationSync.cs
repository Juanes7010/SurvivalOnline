using UnityEngine;
using Photon.Pun;

public class PlayerAnimationSync : MonoBehaviourPun, IPunObservable
{
    [SerializeField] private Animator animator;

    private float moveSpeed;
    private bool isJumping;

    void Update()
    {
        if (photonView.IsMine)
        {
            moveSpeed = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;
            isJumping = Input.GetButton("Jump");

            animator.SetFloat("MoveSpeed", moveSpeed);
            animator.SetBool("IsJumping", isJumping);
        }
        else
        {
            animator.SetFloat("MoveSpeed", moveSpeed);
            animator.SetBool("IsJumping", isJumping);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(moveSpeed);
            stream.SendNext(isJumping);
        }
        else
        {
            moveSpeed = (float)stream.ReceiveNext();
            isJumping = (bool)stream.ReceiveNext();
        }
    }
}