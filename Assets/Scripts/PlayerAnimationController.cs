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

			if(player.movingDirection.x > 0)
			{
				var scale = transform.localScale;
				scale.x = Mathf.Abs(scale.x);
				transform.localScale = scale;
			}
			else
			{
				var scale = transform.localScale;
				scale.x = -Mathf.Abs(scale.x);
				transform.localScale = scale;
			}
		}
		else 
		{
			animator.Play(IdleAnimation.name);
		}
	}
}
