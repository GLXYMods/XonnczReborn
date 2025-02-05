using Photon.Pun;
using StupidTemplate.Menu;
using UnityEngine;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Classes
{
	internal class Button : MonoBehaviour
	{
		public string relatedText;

		public static float buttonCooldown = 0f;

		public static int buttonSound = 114;
		
		public void OnTriggerEnter(Collider collider)
		{
			if (Time.time > buttonCooldown && collider == buttonCollider && menu != null)
			{
                buttonCooldown = Time.time + 0.2f;
                GorillaTagger.Instance.StartVibration(rightHanded, GorillaTagger.Instance.tagHapticStrength / 2f, GorillaTagger.Instance.tagHapticDuration / 2f);
				GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(buttonSound, rightHanded, 0.4f);
				Toggle(this.relatedText);
            }
		}
	}
}
