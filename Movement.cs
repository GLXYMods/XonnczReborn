using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Unity;
using UnityEngine.InputSystem;
using StupidTemplate.Classes;
using BepInEx;
using StupidTemplate.Menu;
using Random = UnityEngine.Random;

namespace StupidTemplate.Mods
{
    public class Movement
    {


        static GameObject point = null;

        public static void tpgun()
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
                var color2 = Main.MenuColor;
                lineRenderer2.startColor = Color.red;
                lineRenderer2.endColor = Color.red;
                lineRenderer2.startWidth = 0.05f;
                lineRenderer2.endWidth = 0.05f;
                lineRenderer2.positionCount = 2;
                lineRenderer2.useWorldSpace = true;
                lineRenderer2.SetPosition(0, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                lineRenderer2.SetPosition(1, point.transform.position);
                lineRenderer2.material.shader = Shader.Find("GUI/Text Shader");
                UnityEngine.Object.Destroy(lineRenderer2, Time.deltaTime);
                UnityEngine.Object.Destroy(line2, Time.deltaTime);
                GameObject.Destroy(point.GetComponent<BoxCollider>());
                GameObject.Destroy(point.GetComponent<Rigidbody>());
                GameObject.Destroy(point.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat >= 0.3f)
                {
                    lineRenderer2.startColor = Color.green;
                    lineRenderer2.endColor = Color.green;
                    point.GetComponent<Renderer>().material.color = Color.green;
                    GorillaLocomotion.Player.Instance.transform.position = point.transform.position;
                    GorillaTagger.Instance.offlineVRRig.transform.position = point.transform.position;
                    GorillaTagger.Instance.myVRRig.transform.position = point.transform.position;
                }
                else
                {
                    
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
                    GorillaLocomotion.Player.Instance.transform.position = point.transform.position;
                    GorillaTagger.Instance.offlineVRRig.transform.position = point.transform.position;
                    GorillaTagger.Instance.myVRRig.transform.position = point.transform.position;
                }
            }
            
        }


        static GameObject ironL, ironR;
        public static void iron()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(20f * -GorillaTagger.Instance.leftHandTransform.right, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 50f * GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
                ironL = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                ironL.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                ironL.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                ironL.GetComponent<SphereCollider>().enabled = false;
                ironL.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.yellow, Mathf.PingPong(Time.time, 1f));
            }
            else
            {
                UnityEngine.Object.Destroy(ironL, 1f);
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(20f * GorillaTagger.Instance.rightHandTransform.right, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 50f * GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
                ironR = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                ironR.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                ironR.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                ironR.GetComponent<SphereCollider>().enabled = false;
                ironR.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.yellow, Mathf.PingPong(Time.time, 1f));
            }
            else
            {
                GameObject.Destroy(ironR, 1f);
            }
        }

        static GameObject platL, platR;
        public static void Invizplatforms()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {                
                if (platL == null)
                {
                    platL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platL.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                    platL.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platL.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    platL.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platL.GetComponent<Renderer>().enabled = false;
                }
            }
            else
            {
                if (platL != null)
                {
                    GameObject.Destroy(platL, .2f);
                    platL = null;
                }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platR == null)
                {
                    platR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                    platR.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platR.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    platR.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platR.GetComponent<Renderer>().enabled = false;
                }
            }
            else
            {
                if (platR != null)
                {
                    GameObject.Destroy(platR, .2f);
                    platR = null;
                }
            }
        }
        public static void platforms()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (platL == null)
                {
                    platL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platL.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                    platL.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platL.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    platL.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platL.GetComponent<Renderer>().material.color = Main.MenuColor;
                    ColorChanger colorChanger = platL.AddComponent<ColorChanger>();
                    colorChanger.Start();
                }
            }
            else
            {
                if (platL != null)
                {
                    GameObject.Destroy(platL, .1f);
                    platL = null;
                }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platR == null)
                {
                    platR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                    platR.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platR.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    platR.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platR.GetComponent<Renderer>().material.color = Main.MenuColor;
                    ColorChanger colorChanger = platR.AddComponent<ColorChanger>();
                    colorChanger.Start();
                }
            }
            else
            {
                if (platR != null)
                {
                    GameObject.Destroy(platR, .1f);
                    platR = null;
                }
            }
        }
        public static void StickyPlatforms()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (platL == null)
                {
                    platL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platL.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                    platL.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platL.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    platL.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platL.GetComponent<Renderer>().material.color = Main.MenuColor;
                    platL.AddComponent<SphereCollider>().GetComponent<SphereCollider>().radius = 1;
                    ColorChanger colorChanger = platL.AddComponent<ColorChanger>();
                    colorChanger.Start();
                }
            }
            else
            {
                if (platL != null)
                {
                    GameObject.Destroy(platL, .1f);
                    platL = null;
                }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platR == null)
                {
                    platR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR.transform.localScale = new Vector3(0.02f, 0.270f, 0.353f);
                    platR.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platR.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    platR.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platR.GetComponent<Renderer>().material.color = Main.MenuColor;
                    platR.AddComponent<SphereCollider>().GetComponent<SphereCollider>().radius = 1;
                    ColorChanger colorChanger = platR.AddComponent<ColorChanger>();
                    colorChanger.Start();
                }
            }
            else
            {
                if (platR != null)
                {
                    GameObject.Destroy(platR, .1f);
                    platR = null;
                }
            }
        }

        #region only wasd here :)
        public static void sadda() // Got this from one of my old devs no idea if they made it or not.
        {
            var player = GorillaLocomotion.Player.Instance;
            var rigidbody = GorillaTagger.Instance.rigidbody;
            float speed = 15f;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0.067f, 0f);
            bool W = UnityInput.Current.GetKey(KeyCode.W);
            bool A = UnityInput.Current.GetKey(KeyCode.A);
            bool S = UnityInput.Current.GetKey(KeyCode.S);
            bool D = UnityInput.Current.GetKey(KeyCode.D);
            bool Space = UnityInput.Current.GetKey(KeyCode.Space);
            bool Ctrl = UnityInput.Current.GetKey(KeyCode.LeftControl);
            bool Shift = UnityInput.Current.GetKey(KeyCode.LeftShift);
            if (Mouse.current.rightButton.isPressed)
            {
                Vector3 euler = player.rightControllerTransform.parent.rotation.eulerAngles;
                euler.y += (Mouse.current.delta.x.ReadValue() / UnityEngine.Screen.width) * 480f;
                euler.x -= (Mouse.current.delta.y.ReadValue() / UnityEngine.Screen.height) * 480f;
                player.rightControllerTransform.parent.rotation = Quaternion.Euler(euler);
            }
            Vector3 vector3 = Vector3.zero;
            if (UnityInput.Current.GetKey(KeyCode.W)) vector3 += player.rightControllerTransform.parent.forward;
            if (UnityInput.Current.GetKey(KeyCode.S)) vector3 -= player.rightControllerTransform.parent.forward;
            if (UnityInput.Current.GetKey(KeyCode.A)) vector3 -= player.rightControllerTransform.parent.right;
            if (UnityInput.Current.GetKey(KeyCode.D)) vector3 += player.rightControllerTransform.parent.right;
            if (UnityInput.Current.GetKey(KeyCode.Space)) vector3 += Vector3.up;
            if (UnityInput.Current.GetKey(KeyCode.LeftControl)) vector3 -= Vector3.up;
            if (UnityInput.Current.GetKey(KeyCode.LeftShift)) speed = 25f; else { speed = 15f; }
            rigidbody.transform.position += vector3 * Time.deltaTime * speed;
        }
        #endregion
        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 20f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 20f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void FastFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 30f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 30f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void SlowFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 10f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 10f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void TriggerFly()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 20f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 20f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void TriggerFastFly()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 30f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 30f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void TriggerSlowFly()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward * Time.deltaTime) * 10f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (Mouse.current.rightButton.isPressed)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * 10f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }


    }
}
