using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {

	private Player player;
	private Animator animator;
	public AnimationClip WalkingAnimation;
	public AnimationClip IdleAnimation;
	// Use this for initialization
	void Start () {
		player = transform.parent.gameObject.GetComponent<Player>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.movingDirection != Vector2.zero)
		{
			animator.Play(WalkingAnimation.name);
		}
		else 
		{
			animator.Play(IdleAnimation.name);
		}
	}
}
