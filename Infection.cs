using System;
using System.Collections.Generic;
using System.Text;
using GorillaLocomotion;
using Unity;
using UnityEngine;
using BepInEx;
using UnityEngine.InputSystem;
using Photon.Pun;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Classes;

namespace StupidTemplate.Mods
{
    public class Infection
    {
        public static void TagAll()
        {
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
                {
                    VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
                    if (!vrrig.mainSkin.material.name.Contains("fected") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                        GorillaTagger.Instance.myVRRig.transform.position = vrrig.transform.position;
                    }
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    GetIndex("Tag All").enabled = false;
                }
            }
        }

        public static void TagSelf()
        {
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f || Mouse.current.rightButton.isPressed)
                {
                    VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
                    if (!vrrig.mainSkin.material.name.Contains("fected") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.rightHandTransform.transform.position;
                        GorillaTagger.Instance.myVRRig.transform.position = vrrig.rightHandTransform.transform.position;
                    }
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    GetIndex("Tag All").enabled = false;
                }
            }
        }

        static GameObject point = null;

        public static void TagGun()
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
                    GorillaTagger.Instance.myVRRig.transform.position = point.transform.position;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }

        }

        public static void FlickTagGun()
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
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = point.transform.position;
                    GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = point.transform.position;
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
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = point.transform.position;
                    GorillaTagger.Instance.offlineVRRig.rightHandTransform.position = point.transform.position;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }

        }

        public static void TagAura()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected") || PhotonNetwork.InRoom == true)
                {
                    GorillaLocomotion.Player.Instance.rightControllerTransform.position = RigManager.GetClosestVRRig().transform.position;
                    GorillaLocomotion.Player.Instance.leftControllerTransform.position = RigManager.GetClosestVRRig().transform.position;
                }
                else
                {
                    Notifications.NotifiLib.SendNotification("<color=red>{ERROR}</color>, <color=blue>You Either are not tagged or not in a room</color>");
                }
            }
        }


    }
}
