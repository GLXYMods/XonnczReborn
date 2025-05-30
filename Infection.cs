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
using static StupidTemplate.Mods.Movement;
using StupidTemplate.Patches;
using Player = GorillaLocomotion.GTPlayer;

namespace StupidTemplate.Mods
{
    public class Infection
    {

        public static void antitag()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            float num;
            VRRig vrrig2 = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    if (vrrig.mainSkin.material.name.Contains("fected") || vrrig.mainSkin.material.name.Contains("it") || !GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                    {
                        if (Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrig.transform.position) < 5)
                        {
                            num = Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, vrrig.transform.position);
                            vrrig2 = vrrig;
                            GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = -100;
                        }
                        else
                        {
                            GorillaTagger.Instance.offlineVRRig.headBodyOffset.x = -0;
                        }
                    }
                }
            }
        }



        public static void TagSelf()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5f || Mouse.current.rightButton.isPressed)
                {
                    if (vrrig.mainSkin.material.name.Contains("fected") && !GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.rightHandTransform.transform.position;
                        GorillaTagger.Instance.myVRRig.transform.position = vrrig.rightHandTransform.transform.position;
                    }
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }

        public static void TagAll()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            if (InputLib.RT() || Mouse.current.rightButton.isPressed)
            {
                {
                    foreach (var rig in GorillaParent.instance.vrrigs)
                    {
                        if (!GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected") && !GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("it") && !GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("ice")) break;
                        if ((!rig.mainSkin.material.name.Contains("ice") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("ice")) || (!rig.mainSkin.material.name.Contains("it") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("it")) || (!rig.mainSkin.material.name.Contains("fected") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected")))
                        {
                            var ins = GorillaTagger.Instance.offlineVRRig;
                            ins.enabled = false;
                            ins.transform.position = rig.transform.position + Vector3.up;
                            ins.rightHand.rigTarget.transform.position = rig.transform.position;
                            ins.leftHand.rigTarget.transform.position = rig.transform.position;
                            GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position = rig.transform.position;
                            ins.enabled = true;
                        }
                    }
                }
            }
        }

        public static VRRig lockon;
        public static VRRig rigg;

        static GameObject point;

        public static void TagGun()
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
                    Collider collider2 = hitInfo.collider;
                    Troll.rigg = ((collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null);
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        lineRenderer2.startColor = Color.blue;
                        lineRenderer2.endColor = Color.blue;
                        point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        point.GetComponent<Renderer>().material.color = Color.blue;
                        point.transform.position = Troll.lockon.transform.position;
                        lineRenderer2.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                        lineRenderer2.SetPosition(1, Troll.lockon.transform.position);
                        var ins = GorillaTagger.Instance.offlineVRRig;
                        ins.enabled = false;
                        ins.transform.position = Troll.lockon.transform.position + Vector3.up;
                        ins.rightHand.rigTarget.transform.position = Troll.lockon.transform.position;
                        ins.leftHand.rigTarget.transform.position = Troll.lockon.transform.position;
                        GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position = Troll.lockon.transform.position;
                    }

                }
                else
                {
                    lockon = null;
                }
            }
            else
            {
                lockon = null;
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
            if (point != null)
            {
                GameObject.Destroy(point, Time.deltaTime);
            }            
        }

        public static void PcTagGun()
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
                    Collider collider2 = raycastHit.collider;
                    Troll.rigg = ((collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null);
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        lineRenderer.startColor = Color.blue;
                        lineRenderer.endColor = Color.blue;
                        point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        point.GetComponent<Renderer>().material.color = Color.blue;
                        point.transform.position = Troll.lockon.transform.position;
                        lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position);
                        lineRenderer.SetPosition(1, Troll.lockon.transform.position);
                        var ins = GorillaTagger.Instance.offlineVRRig;
                        ins.enabled = false;
                        ins.transform.position = Troll.lockon.transform.position + Vector3.up;
                        ins.rightHand.rigTarget.transform.position = Troll.lockon.transform.position;
                        ins.leftHand.rigTarget.transform.position = Troll.lockon.transform.position;
                        GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position = Troll.lockon.transform.position;
                    }
                }
                else
                {
                    Troll.lockon = null;
                    Troll.enablerig();
                }
            }
            else
            {
                Troll.lockon = null;
            }
            if (point != null)
            {
                GameObject.Destroy(point, Time.deltaTime);
            }
        }

        public static void FlickTagGun()
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
                    Player.Instance.rightControllerTransform.position = point.transform.position;
                }
            }
            if (point != null)
            {
                GameObject.Destroy(point, Time.deltaTime);
            }
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
                lineRenderer.startWidth = 0.01f;
                lineRenderer.endWidth = 0.01f;
                lineRenderer.positionCount = 2;
                lineRenderer.useWorldSpace = true;
                lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position);
                lineRenderer.SetPosition(1, point.transform.position);
                lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                UnityEngine.Object.Destroy(lineRenderer, Time.deltaTime);
                UnityEngine.Object.Destroy(line, Time.deltaTime);
                if (UnityInput.Current.GetMouseButton(0))
                {
                    
                }
                else
                {
                    Troll.lockon = null;
                    Troll.enablerig();
                }
            }
            else
            {
                Troll.lockon = null;
            }
            if (point != null)
            {
                GameObject.Destroy(point, Time.deltaTime);
            }
        }

        public static void TagAura()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            float fl;
            VRRig rig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    if (!vrrig.mainSkin.material.name.Contains("fected"))
                    {
                        var distance = 7;
                        var vrrigBody = vrrig.transform.position;
                        var bdyc = GorillaTagger.Instance.bodyCollider.transform.position;
                        var bdy = Vector3.Distance(vrrigBody, bdyc);
                        if (bdy <= distance)
                        {
                            rig = vrrig;
                            var ins = GorillaTagger.Instance.offlineVRRig;
                            ins.enabled = false;
                            ins.transform.position = vrrigBody + Vector3.up;
                            ins.rightHand.rigTarget.transform.position = vrrigBody;
                            ins.leftHand.rigTarget.transform.position = vrrigBody;
                            Player.Instance.rightControllerTransform.position = vrrigBody;
                        }
                        else
                        {
                            var ins = GorillaTagger.Instance.offlineVRRig;
                            ins.enabled = true;
                        }
                    }                  
                }
            }
        }




    }
}
