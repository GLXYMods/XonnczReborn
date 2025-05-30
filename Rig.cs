using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Unity;
using GorillaLocomotion;
using GorillaNetworking;
using GorillaGameModes;
using StupidTemplate.Classes;
using BepInEx;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;
using Player = GorillaLocomotion.GTPlayer;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Notifications;
using StupidTemplate.Patches;

namespace StupidTemplate.Mods
{
    public class Rig
    {

        public static int l = 0;

        public static void ChangeLongArmsShit()
        {
            l++;
            if (l < 0)
            {
                l = 4;
            }
            if (l > 4)
            {
                l = 0;
            }
            if (l == 0)
            {
                GetIndex("LongArm Size").overlapText = "Small";
                longarmsize = new Vector3(1.1f, 1.1f, 1.1f);
            }
            if (l == 1)
            {
                GetIndex("LongArm Size").overlapText = "Medium";
                longarmsize = new Vector3(1.2f, 1.2f, 1.2f);
            }
            if (l == 2)
            {
                GetIndex("LongArm Size").overlapText = "Large";
                longarmsize = new Vector3(1.3f, 1.3f, 1.3f);
            }
            if (l == 3)
            {
                GetIndex("LongArm Size").overlapText = "Very Large";
                longarmsize = new Vector3(1.4f, 1.4f, 1.4f);
            }
            if (l == 4)
            {
                GetIndex("LongArm Size").overlapText = "Massive?";
                longarmsize = new Vector3(1.6f, 1.6f, 1.6f);
            }
        }

        public static void LongArms()
        {
            GTPlayer.Instance.transform.localScale = longarmsize;
        }

        public static Vector3 longarmsize = new Vector3(1.3f, 1.3f, 1.3f);

        public static void GrabRig()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }

            if (ControllerInputPoller.instance.leftGrab)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }

            if (ControllerInputPoller.instance.leftControllerIndexFloat > 0.5f)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }


        public static VRRig lockon;
        public static VRRig rigg;
        static GameObject point = null;

        public static void riggun()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            if (ControllerInputPoller.instance.rightGrab)
            {
                Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position, -GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.up, out var hitInfo);
                point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                point.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                point.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                point.GetComponent<Renderer>().material.color = Color.red;
                point.transform.position = hitInfo.point;
                GameObject line2 = new GameObject("Line");
                LineRenderer lineRenderer2 = line2.AddComponent<LineRenderer>();
                lineRenderer2.startColor = Color.red;
                lineRenderer2.endColor = Color.red;
                lineRenderer2.startWidth = 0.01f;
                lineRenderer2.endWidth = 0.01f;
                lineRenderer2.positionCount = 2;
                lineRenderer2.useWorldSpace = true;
                lineRenderer2.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                lineRenderer2.SetPosition(1, point.transform.position);
                lineRenderer2.material.shader = Shader.Find("GUI/Text Shader");
                UnityEngine.Object.Destroy(lineRenderer2, Time.deltaTime);
                UnityEngine.Object.Destroy(line2, Time.deltaTime);
                UnityEngine.Object.Destroy(point, Time.deltaTime);
                GameObject.Destroy(point.GetComponent<BoxCollider>());
                GameObject.Destroy(point.GetComponent<Rigidbody>());
                GameObject.Destroy(point.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat >= 0.3f)
                {
                    lineRenderer2.startColor = Color.blue;
                    lineRenderer2.endColor = Color.blue;
                    point.GetComponent<Renderer>().material.color = Color.blue;
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = point.transform.position + new Vector3(0f, 0.8f, 0f);
                }
            }
            if (point != null)
            {
                GameObject.Destroy(point, Time.deltaTime);
            }          
        }
        public static void riggun2()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            if (Mouse.current.rightButton.isPressed)
            {
                RaycastHit raycastHit;
                Ray ray = GameObject.Find("Shoulder Camera").activeSelf ? GameObject.Find("Shoulder Camera").GetComponent<Camera>().ScreenPointToRay(UnityInput.Current.mousePosition) : GorillaTagger.Instance.mainCamera.GetComponent<Camera>().ScreenPointToRay(UnityInput.Current.mousePosition);
                if (Physics.Raycast(ray, out raycastHit) && point == null)
                {
                    point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(point.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(point.GetComponent<SphereCollider>());
                    point.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    ColorChanger colorChanger22 = point.AddComponent<ColorChanger>();
                    colorChanger22.Start();
                    point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                }
                point.GetComponent<Renderer>().material.color = Color.red;
                point.transform.position = raycastHit.point;
                GameObject line = new GameObject("Line");
                LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
                lineRenderer.startColor = Color.red;
                lineRenderer.endColor = Color.red;
                lineRenderer.startWidth = 0.01f;
                lineRenderer.endWidth = 0.01f;
                lineRenderer.positionCount = 2;
                lineRenderer.useWorldSpace = true;
                lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position);
                lineRenderer.SetPosition(1, point.transform.position);
                lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                UnityEngine.Object.Destroy(lineRenderer, Time.deltaTime);
                UnityEngine.Object.Destroy(line, Time.deltaTime);
                bool mouseButton = UnityInput.Current.GetMouseButton(0);
                if (mouseButton)
                {
                    lineRenderer.startColor = Color.blue;
                    lineRenderer.endColor = Color.blue;
                    point.GetComponent<Renderer>().material.color = Color.blue;
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = point.transform.position + new Vector3(0f, 0.8f, 0f);
                }
                else
                {
                    Troll.enablerig();
                }
            }
            if (point != null)
            {
                GameObject.Destroy(point, Time.deltaTime);
            }
        }

        public static void enablerig()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void freeze()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position;
                GorillaTagger.Instance.myVRRig.transform.position = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static bool Rp = ControllerInputPoller.instance.rightControllerPrimaryButton;      
        public static bool Lp = ControllerInputPoller.instance.leftControllerPrimaryButton;
        public static bool Rs = ControllerInputPoller.instance.rightControllerSecondaryButton;
        public static bool Ls = ControllerInputPoller.instance.leftControllerSecondaryButton;
        public static bool Lg = ControllerInputPoller.instance.leftGrab;
        public static bool Rg = ControllerInputPoller.instance.rightGrab;
        public static bool ghost = false;
        public static bool ghost1 = false;
        public static bool inviz = false;
        public static bool inviz1 = false;
        public static VRRig rig;
        public static bool Prefix(VRRig __instance)
        {
            return !(__instance == GorillaTagger.Instance.offlineVRRig);
        }
        public static void Ghost()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            bool Rp = ControllerInputPoller.instance.rightControllerPrimaryButton;
            if (!ghost && Rp || Mouse.current.rightButton.isPressed)
            {
                ghost1 = !ghost1;
            }
            ghost = Rp || Mouse.current.rightButton.isPressed;
            if (ghost1)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GameObject gameObject1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                float h = (Time.frameCount / 180f) % 1f;
                gameObject1.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1f));
                gameObject1.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
                gameObject1.transform.position = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                Object.Destroy(gameObject1.GetComponent<Rigidbody>());
                Object.Destroy(gameObject1.GetComponent<Collider>());
                Object.Destroy(gameObject1, Time.deltaTime);
                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                gameObject2.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1f));
                gameObject2.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
                gameObject2.transform.position = GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position;
                Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                Object.Destroy(gameObject2.GetComponent<Collider>());
                Object.Destroy(gameObject2, Time.deltaTime);
                Prefix(GorillaTagger.Instance.offlineVRRig);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                GorillaTagger.Instance.offlineVRRig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
            }
        }



        public static VRRig OverView;
        public static void Inviz()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            bool Rs = ControllerInputPoller.instance.rightControllerSecondaryButton;
            if (!inviz && Rs)
            {
                inviz1 = !inviz1;
            }
            inviz = Rs;
            if (inviz1)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, -999f, 0f);
                GameObject gameObject1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                float h = (Time.frameCount / 180f) % 1f;
                gameObject1.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1f));
                gameObject1.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
                gameObject1.transform.position = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                Object.Destroy(gameObject1.GetComponent<Rigidbody>());
                Object.Destroy(gameObject1.GetComponent<Collider>());
                Object.Destroy(gameObject1, Time.deltaTime);
                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                gameObject2.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1f));
                gameObject2.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
                gameObject2.transform.position = GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position;
                Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                Object.Destroy(gameObject2.GetComponent<Collider>());
                Object.Destroy(gameObject2, Time.deltaTime);
                Prefix(GorillaTagger.Instance.offlineVRRig);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, 0f, 0f);
            }
            if (Keyboard.current.hKey.wasPressedThisFrame)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, -999f, 0f);
            }
        }

        public static void FakeOculusMenu()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GTPlayer.Instance.rightControllerTransform.transform.position = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position;
                GTPlayer.Instance.leftControllerTransform.transform.position = GorillaLocomotion.GTPlayer.Instance.bodyCollider.transform.position;            
            }
        }

    }
}
