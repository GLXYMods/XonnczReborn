using System;
using System.Collections.Generic;
using System.Text;
using Photon.Pun;
using StupidTemplate.Classes;
using UnityEngine;
using UnityEngine.InputSystem;
using static StupidTemplate.Mods.Room;
using static StupidTemplate.Menu.Main;
using BepInEx;
using System.Reflection;
using Random = UnityEngine.Random;
using HarmonyLib;
using Object = UnityEngine.Object;
using System.Threading.Tasks;
using GorillaNetworking;
using System.Linq;
using GorillaTagScripts;
using StupidTemplate.Notifications;
using GorillaLocomotion.Gameplay;
using Player = GorillaLocomotion.GTPlayer;
using StupidTemplate.Menu;
using StupidTemplate.Patches;
using GorillaTag.Shared.Scripts;
using GorillaGameModes;

namespace StupidTemplate.Mods
{
    public class Troll
    {



        public static void UnloadCustom()
        {
            PhotonView ptnview = GameObject.Find("Environment Objects/LocalObjects_Prefab/VirtualStump_CustomMapLobby/ModIOMapsTerminal/NetworkObject").GetComponent<PhotonView>();
            ptnview.RPC("UnloadMapRPC", RpcTarget.Others, new object[]
            {

            });
        }


        public static void ChangeColor(Color color)
        {
            PlayerPrefs.SetFloat("redValue", Mathf.Clamp(color.r, 0f, 1f));
            PlayerPrefs.SetFloat("greenValue", Mathf.Clamp(color.g, 0f, 1f));
            PlayerPrefs.SetFloat("blueValue", Mathf.Clamp(color.b, 0f, 1f));
            GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
            PlayerPrefs.Save();
            try
            {
                GorillaTagger.Instance.myVRRig.SendRPC("RPC_InitializeNoobMaterial", 0, new object[]
                {
                    color.r,
                    color.g,
                    color.b
                });
                flush();
            }
            catch (Exception ex) { Debug.LogError($"Error {ex.Message}"); }
        }

        public static void RGB()
        {
            float h = (Time.frameCount / 200f) % 1f;
            ChangeColor(Color.HSVToRGB(h, 1f, 1f));
        }
        public static void Strobe()
        {
            ChangeColor(new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), 255));
        }





        public static void RopeSpaz()
        {
            foreach (GorillaRopeSwing r in Object.FindObjectsOfType<GorillaRopeSwing>())
            {
                RopeSwingManager.instance.photonView.RPC("SetVelocity", RpcTarget.All, new object[] { r.ropeId, 1, new Vector3(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f)), true, null });
            }
        }

        public static void RopeToSelf()
        {
            foreach (GorillaRopeSwing r in Object.FindObjectsOfType<GorillaRopeSwing>())
            {
                RopeSwingManager.instance.photonView.RPC("SetVelocity", RpcTarget.All, new object[] { r.ropeId, 1, GorillaLocomotion.GTPlayer.Instance.transform.position, true, null });
            }
        }

        public static void RopeUp()
        {
            foreach (GorillaRopeSwing r in Object.FindObjectsOfType<GorillaRopeSwing>())
            {
                RopeSwingManager.instance.photonView.RPC("SetVelocity", RpcTarget.All, new object[] { r.ropeId, 1, new Vector3(0, 100, 0), true, null });
            }
        }

        public static void RopeDown()
        {
            foreach (GorillaRopeSwing r in Object.FindObjectsOfType<GorillaRopeSwing>())
            {
                RopeSwingManager.instance.photonView.RPC("SetVelocity", RpcTarget.All, new object[] { r.ropeId, 1, new Vector3(0, -100, 0), true, null });
            }
        }

        public static void RopeLeft()
        {
            foreach (GorillaRopeSwing r in Object.FindObjectsOfType<GorillaRopeSwing>())
            {
                RopeSwingManager.instance.photonView.RPC("SetVelocity", RpcTarget.All, new object[] { r.ropeId, 1, new Vector3(-100, 0, 0), true, null });
            }
        }

        public static void RopeRight()
        {
            foreach (GorillaRopeSwing r in Object.FindObjectsOfType<GorillaRopeSwing>())
            {
                RopeSwingManager.instance.photonView.RPC("SetVelocity", RpcTarget.All, new object[] { r.ropeId, 1, new Vector3(100, 0, 0), true, null });
            }

        }

        public static void RopeForward()
        {
            foreach (GorillaRopeSwing r in Object.FindObjectsOfType<GorillaRopeSwing>())
            {
                RopeSwingManager.instance.photonView.RPC("SetVelocity", RpcTarget.All, new object[] { r.ropeId, 1, new Vector3(0, 0, 100), true, null });
            }
        }



        public static void GrabIdGun1()
        {
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
                    Troll.rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        lineRenderer2.startColor = Color.blue;
                        lineRenderer2.endColor = Color.blue;
                        Troll.point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        Troll.point.GetComponent<Renderer>().material.color = Color.blue;
                        Troll.point.transform.position = Troll.lockon.transform.position;
                        lineRenderer2.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                        lineRenderer2.SetPosition(1, Troll.lockon.transform.position);
                        string list = "==============Player Id==============!";
                        list += Troll.lockon.OwningNetPlayer.NickName + " - User Id : " + Troll.lockon.OwningNetPlayer.UserId;
                        System.IO.Directory.CreateDirectory("XonnczReborn");
                        System.IO.File.AppendAllText($"XonnczReborn\\{Troll.lockon.OwningNetPlayer.NickName}.txt", list);
                    }
                }
                else
                {
                    Troll.lockon = null;
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
        public static void GrabIdGun2()
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
                    Troll.rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        lineRenderer.startColor = Color.blue;
                        lineRenderer.endColor = Color.blue;
                        Troll.point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        Troll.point.GetComponent<Renderer>().material.color = Color.blue;
                        Troll.point.transform.position = Troll.lockon.transform.position;
                        lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                        lineRenderer.SetPosition(1, Troll.lockon.transform.position);
                        string list = "==============Player Id==============!";
                        list += Troll.lockon.OwningNetPlayer.NickName + " - User Id : " + Troll.lockon.OwningNetPlayer.UserId;
                        System.IO.Directory.CreateDirectory("XonnczReborn");
                        System.IO.File.AppendAllText($"XonnczReborn\\{Troll.lockon.OwningNetPlayer.NickName}.txt", list);
                    }
                }
                else
                {
                    Troll.lockon = null;
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


        public static void grabgun1()
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
                    Troll.rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        lineRenderer2.startColor = Color.blue;
                        lineRenderer2.endColor = Color.blue;
                        Troll.point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        Troll.point.GetComponent<Renderer>().material.color = Color.blue;
                        Troll.point.transform.position = Troll.lockon.transform.position;
                        lineRenderer2.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                        lineRenderer2.SetPosition(1, Troll.lockon.transform.position);
                        RigManager.GetNetworkViewFromVRRig(Troll.lockon).SendRPC("GrabbedByPlayer", Troll.lockon.Creator, new object[]
                        {
                            true,
                            false,
                            false,
                        });
                    }
                }
                else
                {
                    Troll.lockon = null;
                }
                flush();
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
        public static void grabgun2()
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
                    Troll.rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        lineRenderer.startColor = Color.blue;
                        lineRenderer.endColor = Color.blue;
                        Troll.point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        Troll.point.GetComponent<Renderer>().material.color = Color.blue;
                        Troll.point.transform.position = Troll.lockon.transform.position;
                        lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position);
                        lineRenderer.SetPosition(1, Troll.lockon.transform.position);
                        RigManager.GetNetworkViewFromVRRig(Troll.lockon).SendRPC("GrabbedByPlayer", Troll.lockon.Creator, new object[]
                        {
                            true,
                            false,
                            false,
                        });
                    }
                }
                else
                {
                    Troll.lockon = null;
                }
                flush();
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

        public static void crashgun1()
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
                    Troll.rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(0f, 999f, 0f);
                        lineRenderer2.startColor = Color.blue;
                        lineRenderer2.endColor = Color.blue;
                        Troll.point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        Troll.point.GetComponent<Renderer>().material.color = Color.blue;
                        Troll.point.transform.position = Troll.lockon.transform.position;
                        lineRenderer2.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position);
                        lineRenderer2.SetPosition(1, Troll.lockon.transform.position);
                        RigManager.GetNetworkViewFromVRRig(Troll.lockon).SendRPC("GrabbedByPlayer", Troll.lockon.Creator, new object[]
                        {
                            true,
                            false,
                            false,
                        });
                    }
                }
                else
                {
                    Troll.lockon = null;
                }
                flush();
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




        public static Transform pointA;
        public static Transform pointB;
        public static Transform pointC;


        public static void crashgun2()
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
                Object.Destroy(lineRenderer, Time.deltaTime);
                Object.Destroy(line, Time.deltaTime);

                bool mouseButton = UnityInput.Current.GetMouseButton(0);
                if (mouseButton)
                {
                    Collider collider2 = raycastHit.collider;
                    Troll.rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(0f, 999f, 0f);
                        lineRenderer.startColor = Color.blue;
                        lineRenderer.endColor = Color.blue;
                        Troll.point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        Troll.point.GetComponent<Renderer>().material.color = Color.blue;
                        Troll.point.transform.position = Troll.lockon.transform.position;
                        lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position);
                        lineRenderer.SetPosition(1, Troll.lockon.transform.position);
                        RigManager.GetNetworkViewFromVRRig(Troll.lockon).SendRPC("GrabbedByPlayer", Troll.lockon.Creator, new object[]
                        {
                            true,
                            false,
                            false,
                        });
                    }
                    flush();
                }
                else
                {
                    Troll.lockon = null;
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

        public static float Delay1 = 0f;
        public static float Delay12 = 0f;
        public static float crashed = 0f;
        public static void crash()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
                {
                    if (!vrrigs.isMyPlayer && !vrrigs.isOfflineVRRig)
                    {
                        RigManager.GetNetworkViewFromVRRig(vrrigs).SendRPC("GrabbedByPlayer", RpcTarget.Others, new object[]
                        {
                            true,
                            false,
                            false
                        });
                    }
                }
                crashed += Time.deltaTime;
                if (crashed < 0.2f)
                {
                    GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, 30f, 30f);
                }
                if (crashed < 0.43f)
                {
                    foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
                    {
                        if (!vrrigs.isMyPlayer && !vrrigs.isOfflineVRRig)
                        {
                            RigManager.GetNetworkViewFromVRRig(vrrigs).SendRPC("DroppedByPlayer", RpcTarget.Others, new object[]
                            {
                                new Vector3(0f, 0f, 0f),
                            });
                        }
                    }
                }
                if (crashed < 0.45f)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }

        public static void GrabAllAndDropAll()
        {
            if (ControllerInputPoller.instance.rightGrab || Mouse.current.rightButton.isPressed)
            {
                if (Time.time > Delay1)
                {
                    Delay1 = Time.time + 0.05f;
                    GorillaGuardianManager gorillaguardianmanager = GameObject.Find("GT Systems/GameModeSystem/Gorilla Guardian Manager").GetComponent<GorillaGuardianManager>();
                    if (gorillaguardianmanager.IsPlayerGuardian(PhotonNetwork.LocalPlayer))
                    {
                        foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
                        {
                            if (!vrrigs.isMyPlayer && !vrrigs.isOfflineVRRig)
                            {
                                RigManager.GetNetworkViewFromVRRig(vrrigs).SendRPC("GrabbedByPlayer", RpcTarget.Others, new object[]
                                {
                                    true,
                                    false,
                                    false
                                });
                            }
                        }
                    }
                }
            }

            if (ControllerInputPoller.instance.rightControllerIndexFloat >= 0.3f || Mouse.current.leftButton.isPressed)
            {
                if (Time.time > Delay12)
                {
                    Delay12 = Time.time + 0.05f;
                    GorillaGuardianManager gorillaguardianmanager = GameObject.Find("GT Systems/GameModeSystem/Gorilla Guardian Manager").GetComponent<GorillaGuardianManager>();
                    if (gorillaguardianmanager.IsPlayerGuardian(PhotonNetwork.LocalPlayer))
                    {
                        foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
                        {
                            if (!vrrigs.isMyPlayer && !vrrigs.isOfflineVRRig)
                            {
                                RigManager.GetNetworkViewFromVRRig(vrrigs).SendRPC("DroppedByPlayer", RpcTarget.Others, new object[]
                                {
                                    new Vector3(0f, 0f, 0f),
                                });
                            }
                        }
                    }
                }
            }

            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                flush();
            }

        }




        public static void AutoGuardian()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            if (!GameMode.ActiveGameMode.name.Contains("fected"))
            {
                foreach (TappableGuardianIdol tappableGuardianIdol in Object.FindObjectsOfType<TappableGuardianIdol>())
                {
                    if (tappableGuardianIdol.isChangingPositions)
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                        Main.GetIndex("Auto Guardian").enabled = false;
                        continue;
                    }
                    foreach (GorillaGuardianManager gorillaGuardianManager in Object.FindObjectsOfType<GorillaGuardianManager>())
                    {
                        if (gorillaGuardianManager.IsPlayerGuardian(NetworkSystem.Instance.LocalPlayer))
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                            Main.GetIndex("Auto Guardian").enabled = false;
                            continue;
                        }
                        var offlineVRRig = GorillaTagger.Instance.offlineVRRig;
                        offlineVRRig.enabled = false;
                        offlineVRRig.transform.position = tappableGuardianIdol.transform.position;
                        offlineVRRig.leftHand.rigTarget.transform.position = tappableGuardianIdol.transform.position;
                        offlineVRRig.rightHand.rigTarget.transform.position = tappableGuardianIdol.transform.position;
                        tappableGuardianIdol.manager.photonView.RPC(
                            "SendOnTapRPC",
                            RpcTarget.All,
                            tappableGuardianIdol.tappableId,
                            Random.Range(0.2f, 0.4f)
                        );
                    }
                }
            }        
            flush();
        }

        public static float BlockTime;



        public static void PcCopyGun()
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
                    Troll.rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        lineRenderer.startColor = Color.blue;
                        lineRenderer.endColor = Color.blue;
                        Troll.point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        Troll.point.GetComponent<Renderer>().material.color = Color.blue;
                        Troll.point.transform.position = Troll.lockon.transform.position;
                        lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position);
                        lineRenderer.SetPosition(1, Troll.lockon.transform.position);
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = Troll.lockon.transform.position;
                        GorillaTagger.Instance.offlineVRRig.transform.rotation = Troll.lockon.transform.rotation;
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.position = Troll.lockon.head.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.rotation = Troll.lockon.head.rigTarget.rotation;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.position = Troll.lockon.leftHand.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.rotation = Troll.lockon.leftHand.rigTarget.rotation;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.position = Troll.lockon.rightHand.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.rotation = Troll.lockon.rightHand.rigTarget.rotation;
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

        public static float delay;

        public static void CopyPlayerGun()
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
                    Troll.rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        lineRenderer2.startColor = Color.blue;
                        lineRenderer2.endColor = Color.blue;
                        Troll.point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        Troll.point.GetComponent<Renderer>().material.color = Color.blue;
                        Troll.point.transform.position = Troll.lockon.transform.position;
                        lineRenderer2.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                        lineRenderer2.SetPosition(1, Troll.lockon.transform.position);
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = Troll.lockon.transform.position;
                        GorillaTagger.Instance.offlineVRRig.transform.rotation = Troll.lockon.transform.rotation;
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.position = Troll.lockon.head.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.rotation = Troll.lockon.head.rigTarget.rotation;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.position = Troll.lockon.leftHand.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.rotation = Troll.lockon.leftHand.rigTarget.rotation;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.position = Troll.lockon.rightHand.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.rotation = Troll.lockon.rightHand.rigTarget.rotation;
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


        public static void PcFollowGun()
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
                    Troll.rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        lineRenderer.startColor = Color.blue;
                        lineRenderer.endColor = Color.blue;
                        Troll.point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        Troll.point.GetComponent<Renderer>().material.color = Color.blue;
                        Troll.point.transform.position = Troll.lockon.transform.position;
                        lineRenderer.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position);
                        lineRenderer.SetPosition(1, Troll.lockon.transform.position);
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = Vector3.MoveTowards(GorillaTagger.Instance.offlineVRRig.transform.position, lockon.transform.position, Time.deltaTime * 5f);
                        GorillaTagger.Instance.offlineVRRig.transform.LookAt(lockon.transform);
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1.5f;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1.5f;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                        GorillaTagger.Instance.offlineVRRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
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

        public static void followgun()
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
                    Troll.rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        lineRenderer2.startColor = Color.blue;
                        lineRenderer2.endColor = Color.blue;
                        Troll.point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        Troll.point.GetComponent<Renderer>().material.color = Color.blue;
                        Troll.point.transform.position = Troll.lockon.transform.position;
                        lineRenderer2.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                        lineRenderer2.SetPosition(1, Troll.lockon.transform.position);
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = Vector3.MoveTowards(GorillaTagger.Instance.offlineVRRig.transform.position, lockon.transform.position, Time.deltaTime * 5f);
                        GorillaTagger.Instance.offlineVRRig.transform.LookAt(lockon.transform);
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1.5f;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1.5f;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                        GorillaTagger.Instance.offlineVRRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
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

        public static void flingGun()
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
                    Troll.rigg = (collider2 != null) ? collider2.GetComponentInParent<VRRig>() : null;
                    if (Troll.lockon == null)
                    {
                        Troll.lockon = Troll.rigg;
                    }
                    else
                    {
                        lineRenderer2.startColor = Color.blue;
                        lineRenderer2.endColor = Color.blue;
                        Troll.point.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                        Troll.point.GetComponent<Renderer>().material.color = Color.blue;
                        Troll.point.transform.position = Troll.lockon.transform.position;
                        lineRenderer2.SetPosition(0, GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position);
                        lineRenderer2.SetPosition(1, Troll.lockon.transform.position);
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.transform.position = Troll.lockon.transform.position + Vector3.up;
                        
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


        public static void RotateSelf()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton || Mouse.current.rightButton.isPressed)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.Rotate(Vector3.left * Time.deltaTime * -10f);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        static GameObject point = null;
        public static VRRig lockon;
        public static VRRig rigg;

        

        public static void enablerig()
        {
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        public static void followclosest()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            float fl;
            VRRig rig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    var distance = 7;
                    var vrrigBody = vrrig.transform.position;
                    var bdyc = GorillaTagger.Instance.bodyCollider.transform.position;
                    var bdy = Vector3.Distance(vrrigBody, bdyc);
                    if (bdy <= distance)
                    {
                        rig = vrrig;
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = Vector3.MoveTowards(GorillaTagger.Instance.offlineVRRig.transform.position, vrrig.transform.position, Time.deltaTime * 15f);
                        GorillaTagger.Instance.offlineVRRig.transform.LookAt(lockon.transform);
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1.5f;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1.5f;
                        GorillaTagger.Instance.offlineVRRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                    else
                    {
                        enablerig();
                    }
                }
            }
        }



        public static void copyclosest()
        {
            GhostPatch.Prefix(GorillaTagger.Instance.offlineVRRig);
            GhostPatch2.Prefix(VRRigJobManager.Instance, GorillaTagger.Instance.offlineVRRig);
            float fl;
            VRRig rig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    var distance = 4;
                    var vrrigBody = vrrig.transform.position;
                    var bdyc = GorillaTagger.Instance.bodyCollider.transform.position;
                    var bdy = Vector3.Distance(vrrigBody, bdyc);
                    if (bdy <= distance)
                    {
                        rig = vrrig;
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                        GorillaTagger.Instance.offlineVRRig.transform.rotation = vrrig.transform.rotation;
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.position = vrrig.head.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.rotation = vrrig.head.rigTarget.rotation;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.position = vrrig.leftHand.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.rotation = vrrig.leftHand.rigTarget.rotation;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.position = vrrig.rightHand.rigTarget.position;
                        GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.rotation = vrrig.rightHand.rigTarget.rotation;
                    }
                    else
                    {
                        enablerig();
                    }
                }
            }
        }


        

        public static void disableslide()
        {
            GameObject slide = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/slide");
            slide.SetActive(false);
        }
        public static void enableslide()
        {
            GameObject slide = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/slide");
            slide.SetActive(true);
        }



        public static PhotonView GetPhotonViewFromVRRig(VRRig p)
        {
            return GetNetworkViewFromVRRig(p).GetView;
        }
        public static NetworkView GetNetworkViewFromVRRig(VRRig p)
        {
            return (NetworkView)Traverse.Create(p).Field("netView").GetValue();
        }

        // please don't skid :) and if you do i will touch you. at lease give credits ???!?
        public static void InvizOnTouch()
        {
            VRRig rig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    var distance = 0.52;
                    var vrrighandR = vrrig.rightHandTransform.position;
                    var vrrighandL = vrrig.leftHandTransform.position;
                    var hmpos = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
                    var rh = Vector3.Distance(vrrighandR, hmpos);
                    var lh = Vector3.Distance(vrrighandL, hmpos);
                    if (rh <= 0.5 || lh <= 0.5)
                    {
                        rig = vrrig;
                        GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, -999f, 0f);
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(0f, 0f, 0f);
                    }
                }
            }
        }


        public static void GhostOnTouch()
        {
            VRRig rig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    var distance = 0.52;
                    var vrrighandR = vrrig.rightHandTransform.position;
                    var vrrighandL = vrrig.leftHandTransform.position;
                    var hmpos = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
                    var rh = Vector3.Distance(vrrighandR, hmpos);
                    var lh = Vector3.Distance(vrrighandL, hmpos);
                    if (rh <= 0.5 || lh <= 0.5)
                    {
                        rig = vrrig;
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                    }
                }
            }
        }

    }
}
