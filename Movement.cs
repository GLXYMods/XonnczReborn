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
using GorillaLocomotion;
using static StupidTemplate.Menu.Main;
using Photon.Pun;
using System.Linq;
using static StupidTemplate.Mods.InputLib;
using Xonncz_Reborn.Mods;

namespace StupidTemplate.Mods
{


    public class Movement
    {




        public static void JoystickFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.y > 0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.up * (Time.deltaTime * (15f / Time.deltaTime)), ForceMode.Acceleration);
            }
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.y < -0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.up * (Time.deltaTime * (-15f / Time.deltaTime)), ForceMode.Acceleration);
            }
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.x > 0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.right * (Time.deltaTime * (15f / Time.deltaTime)), ForceMode.Acceleration);
            }
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.x < -0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.right * (Time.deltaTime * (-15f / Time.deltaTime)), ForceMode.Acceleration);
            }
        }

        public static void carmonke()
        {
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.y > 0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.forward * (Time.deltaTime * (15f / Time.deltaTime)), ForceMode.Acceleration);
            }
            if (ControllerInputPoller.instance.rightControllerPrimary2DAxis.y < -0.5f)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(Player.Instance.bodyCollider.transform.forward * (Time.deltaTime * (-15f / Time.deltaTime)), ForceMode.Acceleration);
            }
        }
        private static bool Dash = false;
        private static bool Dash1 = false;
        private static bool dashing = false;
        private static float delay;
        public static void dash()
        {
            bool rp = ControllerInputPoller.instance.rightControllerPrimaryButton;
            bool rmb = Mouse.current.rightButton.wasPressedThisFrame;
            if (rp || rmb)
            {
                Player.Instance.GetComponent<Rigidbody>().velocity = Player.Instance.headCollider.transform.forward * 9f;
            }
        }
        public static void Speed()
        {
            Player.Instance.maxJumpSpeed = 8f;
            Player.Instance.jumpMultiplier = 2f;
        }
        public static void mosa()
        {
            Player.Instance.maxJumpSpeed = 6f;
            Player.Instance.jumpMultiplier = 3.5f;
        }

        public static void mega()
        {
            Player.Instance.maxJumpSpeed = 11f;
            Player.Instance.jumpMultiplier = 7f;
        }

        public static void SlideControl()
        {
            Player.Instance.slideControl = 9999f;
        }

        static GameObject checkpoint = null;
        public static void check()
        {     
            if (ControllerInputPoller.instance.rightGrab)
            {              
                if (checkpoint == null)
                {
                    checkpoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    checkpoint.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    checkpoint.GetComponent<Renderer>().material.color = MenuColor;
                    checkpoint.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    UnityEngine.Object.Destroy(checkpoint.GetComponent<SphereCollider>());
                    UnityEngine.Object.Destroy(checkpoint.GetComponent<Rigidbody>());
                }
                checkpoint.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
            }
            if (checkpoint != null)
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f)
                {
                    bool mesh = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;
                    MeshCollider[] mesh2 = Resources.FindObjectsOfTypeAll<MeshCollider>();
                    foreach (MeshCollider meshcollider in mesh2)
                    {
                        if (mesh)
                        {
                            meshcollider.enabled = !false;
                            Player.Instance.transform.position = checkpoint.transform.position;
                            GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        }
                    }

                }
                else
                {
                    bool mesh = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f;
                    MeshCollider[] mesh2 = Resources.FindObjectsOfTypeAll<MeshCollider>();
                    foreach (MeshCollider meshcollider in mesh2)
                    {
                        if (!mesh)
                        {
                            meshcollider.enabled = true;
                        }
                    }
                }
            }            
        }

        public static void disablecheck()
        {
            if (checkpoint != null)
            {
                UnityEngine.Object.Destroy(checkpoint);
                checkpoint = null;
            }
        }

        public static void DestroyObj(GameObject Gameobject, float time)
        {
            GameObject.Destroy(Gameobject, time);
        }

        public static void destroyexample()
        {
        }

        

        public static void CreateObj(PrimitiveType primitiveType, Vector3 scale, Vector3 position, bool colliders, float destroytime, Color color, bool inviz)
        {
            GameObject game = GameObject.CreatePrimitive(primitiveType);
            game.transform.localScale = scale;
            game.transform.position = position;
            game.GetComponent<BoxCollider>().enabled = colliders;
            game.GetComponent<SphereCollider>().enabled = colliders;
            game.GetComponent<Collider>().enabled = colliders;
            game.GetComponent<Collider2D>().enabled = colliders;
            game.GetComponent<Renderer>().material.color = color;
            game.GetComponent<Renderer>().enabled = inviz;
            DestroyObj(game, destroytime);
        }

        public static void example() 
        {
                      // Creates A Cube.  The Scale Of The Object                The Position Of The Object       uses colliders  Destroys when turned off   Color      Invisable
            CreateObj(PrimitiveType.Cube, new Vector3(0.1f, 0.1f, 0.1f), GorillaTagger.Instance.rightHandTransform.position, true, Time.deltaTime,          Color.red, false); 
        }

        

        static GameObject point = null;

        public static void TpToStump()
        {
            
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
                Player.Instance.transform.position = new Vector3(-63.8717f, 12.1881f, -83.0144f);
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }
        public static void TpToTut()
        {
            
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
                Player.Instance.transform.position = new Vector3(-86.6707f, 36.4451f, -65.8458f);
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }

        
        public static void TpToCity()
        {
            
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
                Player.Instance.transform.position = new Vector3(-66.9824f, 14.0115f, -97.0772f);
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }

        static VRRig ghostRig = null;
        public static void TpGun()
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
                lineRenderer2.startColor = Color.red;
                lineRenderer2.endColor = Color.red;
                lineRenderer2.startWidth = 0.01f;
                lineRenderer2.endWidth = 0.01f;
                lineRenderer2.positionCount = 2;
                lineRenderer2.useWorldSpace = true;
                lineRenderer2.SetPosition(0, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                lineRenderer2.SetPosition(1, point.transform.position);
                lineRenderer2.material.shader = Shader.Find("GUI/Text Shader");
                UnityEngine.Object.Destroy(lineRenderer2, Time.deltaTime);
                UnityEngine.Object.Destroy(line2, Time.deltaTime);
                UnityEngine.Object.Destroy(point, Time.deltaTime);
                GameObject.Destroy(point.GetComponent<BoxCollider>());
                GameObject.Destroy(point.GetComponent<Rigidbody>());
                GameObject.Destroy(point.GetComponent<Collider>());
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
                {
                    lineRenderer2.startColor = Color.blue;
                    lineRenderer2.endColor = Color.blue;
                    point.GetComponent<Renderer>().material.color = Color.blue;
                    GorillaLocomotion.Player.Instance.transform.position = point.transform.position;
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
                lineRenderer.SetPosition(0, GorillaLocomotion.Player.Instance.headCollider.transform.position);
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
                    GorillaLocomotion.Player.Instance.transform.position = point.transform.position;
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

        public static void testlockon()
        {

        }


        static GameObject ironL, ironR;
        public static void iron()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(20f * -GorillaTagger.Instance.leftHandTransform.right, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 50f * Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
                ParticleSystem particleSystem2 = new GameObject("LeftIronParticle").AddComponent<ParticleSystem>();
                particleSystem2.transform.position = Player.Instance.leftControllerTransform.position;
                particleSystem2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                particleSystem2.transform.rotation = Player.Instance.leftControllerTransform.rotation;
                particleSystem2.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                GradientColorKey[] array = new GradientColorKey[3];
                array[0].color = Color.red;
                array[0].time = 0f;
                array[1].color = new Color32(230, 108, 44, 255);
                array[1].time = 0.5f;
                array[2].color = Color.red;
                array[2].time = 1f;
                ColorChanger colorChanger = particleSystem2.AddComponent<ColorChanger>();
                colorChanger.colorInfo = new ExtGradient
                {
                    colors = array
                };
                colorChanger.Start();
                particleSystem2.GetComponent<Renderer>().material.color = Color.red;
                particleSystem2.Play();
                GameObject.Destroy(particleSystem2, 0.5f);
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                Player.Instance.bodyCollider.attachedRigidbody.AddForce(20f * GorillaTagger.Instance.rightHandTransform.right, ForceMode.Acceleration);
                GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 50f * Player.Instance.bodyCollider.attachedRigidbody.velocity.magnitude, GorillaTagger.Instance.tapHapticDuration);
                ParticleSystem particleSystem = new GameObject("RightIronParticle").AddComponent<ParticleSystem>();
                particleSystem.transform.position = Player.Instance.rightControllerTransform.position;
                particleSystem.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                particleSystem.transform.rotation = Player.Instance.rightControllerTransform.rotation;
                particleSystem.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                GradientColorKey[] array = new GradientColorKey[3];
                array[0].color = Color.red;
                array[0].time = 0f;
                array[1].color = new Color32(230, 108, 44, 255);
                array[1].time = 0.5f;
                array[2].color = Color.red;
                array[2].time = 1f;
                ColorChanger colorChanger = particleSystem.AddComponent<ColorChanger>();
                colorChanger.colorInfo = new ExtGradient
                {
                    colors = array
                };
                colorChanger.Start();
                particleSystem.GetComponent<Renderer>().material.color = Color.red;
                particleSystem.Play();
                GameObject.Destroy(particleSystem, 0.5f);
            }
        }

        static GameObject platL, platR, platL2, platL3, platL4, platR2, platR3, platR4;
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
                    GameObject.Destroy(platL);
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
                    GameObject.Destroy(platR);
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
                    platL.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platL.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platL.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    platL.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platL.GetComponent<Renderer>().material.color = MenuColor;                    
                    ColorChanger colorChanger = platL.AddComponent<ColorChanger>();
                    colorChanger.Start();                    
                }
            }
            else
            {
                if (platL != null)
                {
                    Rigidbody comp = platL.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    GameObject.Destroy(platL, 2f);
                    platL = null;
                }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platR == null)
                {
                    platR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platR.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platR.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    platR.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platR.GetComponent<Renderer>().material.color = MenuColor;                   
                    ColorChanger colorChanger = platR.AddComponent<ColorChanger>();
                    colorChanger.Start();
                }
            }
            else
            {
                if (platR != null)
                {
                    Rigidbody comp = platR.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    GameObject.Destroy(platR, 2f);
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
                    platL.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platL.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platL.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    platL.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platL.GetComponent<Renderer>().material.color = MenuColor;
                    platL2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platL2.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platL2.transform.position = GorillaTagger.Instance.leftHandTransform.position + new Vector3(0f, 0.06f, 0f);
                    platL2.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                    platL2.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platL2.GetComponent<Renderer>().material.color = Color.red;
                    platL2.GetComponent<Renderer>().enabled = false;
                    ColorChanger colorChanger = platL.AddComponent<ColorChanger>();
                    colorChanger.Start();
                }
            }
            else
            {
                if (platL != null && platL2 != null)
                {
                    Rigidbody comp = platL.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    GameObject.Destroy(platL, 2f);
                    GameObject.Destroy(platL2);
                    GameObject.Destroy(platL3);
                    GameObject.Destroy(platL4);
                    platL = null;
                    platL2 = null;
                    platL3 = null;
                    platL4 = null;
                }
            }
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platR == null)
                {
                    platR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platR.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, -0.06f, 0f);
                    platR.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    platR.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platR.GetComponent<Renderer>().material.color = MenuColor;
                    platR2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR2.transform.localScale = new Vector3(0.04f, 0.280f, 0.353f);
                    platR2.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0f, 0.06f, 0f);
                    platR2.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;
                    platR2.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    platR2.GetComponent<Renderer>().material.color = Color.red;
                    platR2.GetComponent<Renderer>().enabled = false;
                    ColorChanger colorChanger = platR.AddComponent<ColorChanger>();
                    colorChanger.Start();
                }
            }
            else
            {
                if (platR != null)
                {
                    Rigidbody comp = platR.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    GameObject.Destroy(platR, 2f);
                    GameObject.Destroy(platR2);
                    platR = null;
                    platR2 = null;
                }
            }
        }
        public static void platformsno()
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
                    platL.GetComponent<Renderer>().material.color = MenuColor;
                    ColorChanger colorChanger = platL.AddComponent<ColorChanger>();
                    colorChanger.Start();
                    foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider.enabled = false;
                    }
                }
            }
            else
            {            
                if (platL != null)
                {
                    Rigidbody comp = platL.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider.enabled = true;
                    }
                    GameObject.Destroy(platL, 2f);
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
                    platR.GetComponent<Renderer>().material.color = MenuColor;
                    ColorChanger colorChanger = platR.AddComponent<ColorChanger>();
                    colorChanger.Start();
                    foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider.enabled = false;
                    }
                }
            }
            else
            {
                if (platR != null)
                {
                    Rigidbody comp = platR.AddComponent(typeof(Rigidbody)) as Rigidbody;
                    comp.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider.enabled = true;
                    }
                    GameObject.Destroy(platR, 2f);
                    platR = null;
                }
            }
        }



        #region only wasd here :)
        public static void sadda() // Got this from one of my old devs so W :)
        {
            float speed = 15f;
            var rigidbody = GorillaTagger.Instance.rigidbody;
            Player.Instance.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0.067f, 0f);
            if (Mouse.current.rightButton.isPressed)
            {
                Vector3 euler = Player.Instance.rightControllerTransform.parent.rotation.eulerAngles;
                euler.y += (Mouse.current.delta.x.ReadValue() / UnityEngine.Screen.width) * 480f;
                euler.x -= (Mouse.current.delta.y.ReadValue() / UnityEngine.Screen.height) * 480f;
                Player.Instance.rightControllerTransform.parent.rotation = Quaternion.Euler(euler);
            }
            if (UnityInput.Current.GetKey(KeyCode.N))
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = true;
                }
            }
            Vector3 vector3 = Vector3.zero;
            if (UnityInput.Current.GetKey(KeyCode.W)) vector3 += Player.Instance.rightControllerTransform.parent.forward;
            if (UnityInput.Current.GetKey(KeyCode.S)) vector3 -= Player.Instance.rightControllerTransform.parent.forward;
            if (UnityInput.Current.GetKey(KeyCode.A)) vector3 -= Player.Instance.rightControllerTransform.parent.right;
            if (UnityInput.Current.GetKey(KeyCode.D)) vector3 += Player.Instance.rightControllerTransform.parent.right;
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

        public static void Noclip()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f)
            {
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }
        public static void upandDown()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.up * Time.deltaTime * 8f;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.up * Time.deltaTime * -8f;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }


        public static void flywithnoclip()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 17f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.Player.Instance.rightControllerTransform.forward * 20f;
                foreach (MeshCollider meshCollider in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider.enabled = false;
                }
            }
            else
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = true;
                }
            }
        }
        public static void flush()
        {
            GorillaNot.instance.rpcCallLimit = 99999999;
            GorillaNot.instance.rpcErrorMax = 99999999;
            GorillaNot.instance.rpcCallLimit = 99999999;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            GorillaNot.instance.rpcCallLimit = 99999999;
            GorillaNot.instance.rpcErrorMax = 99999999;
            GorillaNot.instance.rpcCallLimit = 99999999;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            GorillaNot.instance.rpcCallLimit = 9999;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.OpRemoveCompleteCache();
            PhotonNetwork.SendAllOutgoingCommands();
            PhotonNetwork.RemoveRPCsInGroup(666);
            PhotonNetwork.RemoveRPCsInGroup(666);
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
        }

    }
}
