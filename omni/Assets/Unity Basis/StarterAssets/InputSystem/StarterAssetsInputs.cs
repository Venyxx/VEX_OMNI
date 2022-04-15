using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		private script_third_person_controller script_Third_Person_Controller;
		private ThirdPersonController thirdPersonController;
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool Aim;
		public bool shoot;
		public bool bow;
		public bool sword;
		public bool escape;
		public GameObject reticle;

		[Header("Movement Settings")]
		public bool analogMovement;

#if !UNITY_IOS || !UNITY_ANDROID
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
			reticle.SetActive(false);
			Aim = false;
			shoot = false;
		}

		public void OnAim(InputValue value)
		{
			Debug.Log("noticed aim");
			AimInput(value.isPressed);
		}

		public void OnShoot(InputValue value)
		{
			Debug.Log("noticed shooot");
			ShootInput(value.isPressed);
		}

		public void OnBow(InputValue value)
		{
			Debug.Log("noticed bow press 1");
			BowInput(value.isPressed);
		}
		public void OnSword(InputValue value)
		{
			Debug.Log("noticed sword press 2");
			OnSwordInput(value.isPressed);
		}
		public void OnEscape(InputValue value)
		{
			Debug.Log("noticed esc");
			EscapeInput(value.isPressed);
		}
#else
	// old input sys if we do decide to have it (most likely wont)...
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
			//thirdPersonController.doubleJump++;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void AimInput(bool newAimState)
		{
			Aim = newAimState;
		}

		public void ShootInput(bool newShootState)
		{
			shoot = newShootState;
		}

		public void EscapeInput(bool newEscapeState)
		{
			escape = newEscapeState;
			Debug.Log("esc");
		}

		
		public void BowInput(bool newBowState)
		{
			bow = newBowState;

		}
		public void OnSwordInput(bool newSwordState)
		{
			sword = newSwordState;
			bow = false;
			
		}
#if !UNITY_IOS || !UNITY_ANDROID

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

#endif

	}
	
}