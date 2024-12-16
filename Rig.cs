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
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    public class Rig
    {

        static GameObject point = null;

        public static void riggun()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out var hitInfo);
                point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                point.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                point.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                point.GetComponent<Renderer>().material.color = Color.red;
                point.transform.position = hitInfo.point;
                GameObject line2 = new GameObject("Line");
                LineRenderer lineRenderer2 = line2.AddComponent<LineRenderer>();
                var color2 = MenuColor;
                lineRenderer2.startColor = Color.red;
                lineRenderer2.endColor = Color.red;
                lineRenderer2.startWidth = 0.05f;
                lineRenderer2.endWidth = 0.05f;
                lineRenderer2.positionCount = 2;
                lineRenderer2.useWorldSpace = true;
                lineRenderer2.SetPosition(0, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                lineRenderer2.SetPosition(1, point.transform.position);
                lineRenderer2.material.shader = Shader.Find("GUI/Text Shader");
                Rigidbody comp = line2.GetComponent(typeof(Rigidbody)) as Rigidbody;
                comp.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                UnityEngine.Object.Destroy(lineRenderer2, 1f);
                UnityEngine.Object.Destroy(line2, 1f);
                GameObject.Destroy(point.GetComponent<BoxCollider>());
                GameObject.Destroy(point.GetComponent<Rigidbody>());
                GameObject.Destroy(point.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat >= 0.3f)
                {
                    lineRenderer2.startColor = Color.green;
                    lineRenderer2.endColor = Color.green;
                    point.GetComponent<Renderer>().material.color = Color.green;
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = point.transform.position;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
            if (point != null)
            {
                GameObject.Destroy(point, Time.deltaTime);
            }
            if (Mouse.current.rightButton.isPressed)
            {
                RaycastHit raycastHit;
                Ray ray = Camera.main.ScreenPointToRay(UnityInput.Current.mousePosition);
                if (Physics.Raycast(ray, out raycastHit) && point == null)
                {
                    point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(point.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(point.GetComponent<SphereCollider>());
                    point.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    point.GetComponent<Renderer>().material.color = Color.red;
                    ColorChanger colorChanger22 = point.AddComponent<ColorChanger>();
                    colorChanger22.Start();
                    point.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                }
                point.transform.position = raycastHit.point;
                GameObject line = new GameObject("Line");
                LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
                lineRenderer.startColor = Color.red;
                lineRenderer.endColor = Color.red;
                lineRenderer.startWidth = 0.05f;
                lineRenderer.endWidth = 0.05f;
                lineRenderer.positionCount = 2;
                lineRenderer.useWorldSpace = true;
                lineRenderer.SetPosition(0, GorillaLocomotion.Player.Instance.headCollider.transform.position);
                lineRenderer.SetPosition(1, point.transform.position);
                lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                UnityEngine.Object.Destroy(lineRenderer, Time.deltaTime);
                UnityEngine.Object.Destroy(line, Time.deltaTime);
                if (UnityInput.Current.GetMouseButton(0))
                {
                    lineRenderer.startColor = Color.green;
                    lineRenderer.endColor = Color.green;
                    point.GetComponent<Renderer>().material.color = Color.green;
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = point.transform.position;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }

        }
        public static void freeze()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.headCollider.transform.position;
                GorillaTagger.Instance.myVRRig.transform.position = GorillaLocomotion.Player.Instance.headCollider.transform.position;
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
                gameObject1.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                Object.Destroy(gameObject1.GetComponent<Rigidbody>());
                Object.Destroy(gameObject1.GetComponent<Collider>());
                Object.Destroy(gameObject1, Time.deltaTime);
                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                gameObject2.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1f));
                gameObject2.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
                gameObject2.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                Object.Destroy(gameObject2.GetComponent<Collider>());
                Object.Destroy(gameObject2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                GorillaTagger.Instance.offlineVRRig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = GorillaTagger.Instance.offlineVRRig.playerColor;
            }
        }
        public static void Inviz()
        {
            bool Rs = ControllerInputPoller.instance.rightControllerSecondaryButton;
            if (!inviz && Rs || Mouse.current.leftButton.isPressed)
            {
                inviz1 = !inviz1;
            }
            inviz = Rs || Mouse.current.leftButton.isPressed;
            if (inviz1)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(-9999f, -9999f, -9999f);
                GameObject gameObject1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                float h = (Time.frameCount / 180f) % 1f;
                gameObject1.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1f));
                gameObject1.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
                gameObject1.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                Object.Destroy(gameObject1.GetComponent<Rigidbody>());
                Object.Destroy(gameObject1.GetComponent<Collider>());
                Object.Destroy(gameObject1, Time.deltaTime);
                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                gameObject2.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1f));
                gameObject2.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
                gameObject2.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                Object.Destroy(gameObject2.GetComponent<Collider>());
                Object.Destroy(gameObject2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                GorillaTagger.Instance.offlineVRRig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = GorillaTagger.Instance.offlineVRRig.playerColor;
            }
        }







    }
}
