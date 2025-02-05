using System;
using System.Collections.Generic;
using System.Text;
using GorillaLocomotion;
using UnityEngine;
using Unity;
using static StupidTemplate.Menu.Main;
using UnityEngine.UI;
using TMPro;
using Object = UnityEngine.Object;
using System.Net;
using StupidTemplate.Classes;
using Photon.Pun;
using GorillaNetworking;
using StupidTemplate.Notifications;
using System.IO;
using StupidTemplate.Menu;
using HarmonyLib;
using static StupidTemplate.Settings;

namespace StupidTemplate.Mods
{
    public class Visual
    {


        public static void BoxEsp()
        {
            foreach (VRRig vrrigs in GorillaParent.instance.vrrigs)
            {
                if (!vrrigs.isOfflineVRRig && !vrrigs.isMyPlayer)
                {
                    GameObject Box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Box.transform.localScale = new Vector3(0.6f, 0.6f, 0f);
                    Box.transform.position = vrrigs.transform.position;
                    Object.Destroy(Box.GetComponent<BoxCollider>());
                    Box.GetComponent<TextMeshPro>().renderer.material.shader = Shader.Find("GUI/Text Shader");
                    Box.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 50);
                    Box.transform.LookAt(Camera.main.transform.position);
                    Object.Destroy(Box, Time.deltaTime);
                }
            }
        }

        public static TMP_FontAsset gtagfont = GameObject.Find("motdtext").GetComponent<TextMeshPro>().font;

        public static void NameTags()
        {
            foreach (VRRig vrigs in GorillaParent.instance.vrrigs)
            {
                if (!vrigs.isOfflineVRRig && !vrigs.isMyPlayer)
                {
                    GameObject NameTags = vrigs.transform.Find("NameTags")?.gameObject;
                    NameTags = new GameObject("NameTags");
                    TextMeshPro textMeshPro = NameTags.AddComponent<TextMeshPro>();
                    textMeshPro.text = vrigs.OwningNetPlayer.NickName;
                    textMeshPro.fontSize = 2f;
                    textMeshPro.alignment = TextAlignmentOptions.Center;
                    textMeshPro.color = Color.red;
                    textMeshPro.font = gtagfont;
                    NameTags.transform.SetParent(vrigs.transform);
                    Object.Destroy(NameTags, Time.deltaTime);
                    Transform Nametag = NameTags.transform;
                    Nametag.GetComponent<TextMeshPro>().renderer.material.shader = Shader.Find("GUI/Text Shader");
                    Nametag.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    Nametag.position = vrigs.headConstraint.position + new Vector3(0f, 0.4f, 0f);
                    Nametag.LookAt(Camera.main.transform.position);
                    Nametag.Rotate(0f, 180f, 0f);
                }
            }
        }


        public static GameObject motdText = null;
        public static GameObject motdTextB = null;
        public static GameObject Tos = null;
        public static float fl;
        public static void boards()
        {
            float h = (Time.frameCount / 180f) % 1f;
            motdText = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motd (1)");
            motdText.GetComponent<TextMeshPro>().text = string.Format("X O N N C Z | R E B O R N");
            motdText.GetComponent<TextMeshPro>().color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            motdTextB = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdtext");
            motdTextB.GetComponent<TextMeshPro>().text = "Thank you for using X O N N C Z Reborn!\nThe Menu Status is : UND\nWe really hope that you have fun while using this menu, and don't forget DO NOT GET BANNED, AND IF YOU DO IT IS NOT OUR FAULT!\n"+ DateTime.Now.ToString("hh:mm tt");
            motdTextB.GetComponent<TextMeshPro>().color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            coc = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/CodeOfConduct");
            coc.GetComponent<TextMeshPro>().text = string.Format("X O N N C Z | R E B O R N");
            coc.GetComponent<TextMeshPro>().color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));
            coc2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/COC Text");
            
            coc2.GetComponent<TextMeshPro>().text = "This Menu Has Been devopled for some time we do hope that you enjoy it and make sure that you do not get yourself banned! and if you do please report it in the discord so we can fix it. But it is not our fault if you get banned!\nThe Menu is : UNDETECTED";
            coc2.GetComponent<TextMeshPro>().color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject df = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest");
            df.SetActive(true);

            


            Computer = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor/monitorScreen");
            Computer.SetActive(false);

            GameObject WallMonitor = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomBoundaryStones/BoundaryStoneSet_Forest/wallmonitorforestbg");
            WallMonitor.SetActive(false);

            KeyBoard = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)");
            KeyBoard.GetComponent<Renderer>().material.color = Color.black;

            GameObject K1 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/a");
            K1.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject K2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/b");
            K2.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject K3 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/c");
            K3.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject K4 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/d");
            K4.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject K5 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/e");
            K5.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k6 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/f");
            k6.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k7 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/g");
            k7.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k8 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/h");
            k8.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k9 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/i");
            k9.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k10 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/j");
            k10.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k11 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/k");
            k11.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k12 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/l");
            k12.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k13 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/m");
            k13.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k14 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/n");
            k14.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k15 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/o");
            k15.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k16 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/p");
            k16.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k17 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/q");
            k17.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k125 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/r");
            k125.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k18 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/s");
            k18.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k19 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/t");
            k19.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k20 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/u");
            k20.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k21 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/v");
            k21.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k22 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/w");
            k22.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k23 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/x");
            k23.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k24 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/y");
            k24.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject k25 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/z");
            k25.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n0 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/0");
            n0.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n1 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/1");
            n1.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/2");
            n2.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n3 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/3");
            n3.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n4 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/4");
            n4.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n5 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/5");
            n5.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n6 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/6");
            n6.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n7 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/7");
            n7.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n8 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/8");
            n8.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject n9 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/9");
            n9.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject del = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/delete");
            del.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject ent = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/enterkeyforest");
            ent.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject opt1 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/option 1");
            opt1.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject opt2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/option 2");
            opt2.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject opt3 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/option 3");
            opt3.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));
            
            GameObject up = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/up");
            up.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));

            GameObject down = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/keyboard (1)/Buttons/Keys/down");
            down.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));
            GorillaKeyboardButton g = new GorillaKeyboardButton();
            g.GetComponent<Renderer>().material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));
            g.PressButtonColourUpdate();

            PhotonNetworkController.Instance.UpdateTriggerScreens();
        }


        public static float sig;
        public static int but = 1;
        public static GameObject coc;
        public static GameObject coc2;
        public static GameObject MotdBoard;
        public static GameObject Computer;
        public static GameObject KeyBoard;






        public static void makeeveryonergb()
        {
            float h = (Time.frameCount / 180f) % 1f;

            foreach (VRRig vrrig in (VRRig[])GameObject.FindObjectsOfType(typeof(VRRig)))
            {
                vrrig.mainSkin.material.color = Color.HSVToRGB(h, 1f, 1f);
            }
        }








        public static void tracers()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig && !rig.isMyPlayer)
                {
                    GameObject line = new GameObject("Line");
                    LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
                    var color = MenuColor;
                    lineRenderer.startColor = color;
                    lineRenderer.endColor = color;
                    lineRenderer.startWidth = 0.01f;
                    lineRenderer.endWidth = 0.01f;
                    lineRenderer.positionCount = 2;
                    lineRenderer.useWorldSpace = true;
                    lineRenderer.SetPosition(0, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                    lineRenderer.SetPosition(1, rig.transform.position);
                    lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    Object.Destroy(lineRenderer, Time.deltaTime);
                    Object.Destroy(line, Time.deltaTime);
                }              
            }            
        }
        public static void head()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig && !rig.isMyPlayer)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    sphere.transform.localPosition = rig.transform.position + new Vector3(0f, 1f, 0f);
                    sphere.GetComponent<SphereCollider>().enabled = false;
                    sphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    sphere.GetComponent<Renderer>().material.color = MenuColor;
                    GameObject.Destroy(sphere, Time.deltaTime);
                    GameObject line = new GameObject("Line");
                    LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
                    var color = MenuColor;
                    lineRenderer.startColor = color;
                    lineRenderer.endColor = color;
                    lineRenderer.startWidth = 0.01f;
                    lineRenderer.endWidth = 0.01f;
                    lineRenderer.positionCount = 2;
                    lineRenderer.useWorldSpace = true;
                    lineRenderer.SetPosition(0, GorillaLocomotion.Player.Instance.rightControllerTransform.position);
                    lineRenderer.SetPosition(1, sphere.transform.position);
                    lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    Object.Destroy(lineRenderer, Time.deltaTime);
                    Object.Destroy(line, Time.deltaTime);
                }
            }
        }

        public static void sphereEsp()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig && !rig.isMyPlayer)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    sphere.transform.localPosition = rig.transform.position;
                    sphere.GetComponent<SphereCollider>().enabled = false;
                    sphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    sphere.GetComponent<Renderer>().material.color = MenuColor;
                    GameObject.Destroy(sphere, Time.deltaTime);
                }
                
            }
        }

        public static int t = 0;
        public static void ChangeMenuTheme()
        {
            t++;
            if (t > 11)
            {
                t = 0;
            }

            if (t == 0)
            {
                MenuColor = Color.red;
                OutlineColor = Color.black;
                GetIndex("Change Theme").overlapText = "Theme : Red";
            }
            if (t == 1)
            {
                MenuColor = new Color32(11, 34, 117, 255);
                OutlineColor = new Color32(48, 93, 221, 255);
                GetIndex("Change Theme").overlapText = "Theme : Blue";
            }
            if (t == 2)
            {
                MenuColor = Color.black;
                OutlineColor = Color.black;
                GetIndex("Change Theme").overlapText = "Theme : Black";
            }
            if (t == 3)
            {
                MenuColor = Color.grey;
                OutlineColor = Color.black;
                GetIndex("Change Theme").overlapText = "Theme : Grey";
            }
            if (t == 4)
            {
                MenuColor = Color.green;
                OutlineColor = Color.black;
                GetIndex("Change Theme").overlapText = "Theme : Green";
            }
            if (t == 5)
            {
                MenuColor = new Color32(254, 192, 255, 255);
                OutlineColor = new Color32(251, 0, 255, 255);
                GetIndex("Change Theme").overlapText = "Theme : Pink";
            }
            if (t == 6)
            {
                MenuColor = new Color32(200, 130, 255, 255);
                OutlineColor = new Color32(142, 0, 255, 255);
                GetIndex("Change Theme").overlapText = "Theme : Purple";
            }
            if (t == 7)
            {
                MenuColor = new Color32(255, 255, 143, 255);
                OutlineColor = new Color32(0, 0, 0, 255);
                GetIndex("Change Theme").overlapText = "Theme : Yellow";
            }
            if (t == 8)
            {
                MenuColor = new Color32(0, 158, 255, 255);
                OutlineColor = new Color32(0, 0, 0, 255);
                GetIndex("Change Theme").overlapText = "Theme : Light Blue";
            }
            if (t == 9)
            {
                MenuColor = new Color32(255, 135, 0, 255);
                OutlineColor = new Color32(0, 0, 0, 255);
                GetIndex("Change Theme").overlapText = "Theme : Orange";
            }
            if (t == 10)
            {
                MenuColor = new Color32(120, 255, 0, 255);
                OutlineColor = new Color32(0, 0, 0, 255);
                GetIndex("Change Theme").overlapText = "Theme : Lime";
            }
            if (t == 11)
            {
                MenuColor = new Color32(0, 248, 255, 255);
                OutlineColor = new Color32(0, 0, 0, 255);
                GetIndex("Change Theme").overlapText = "Theme : Aqua";
            }
            if (t == 12)
            {
                ClearMenu = true;
                GetIndex("Change Theme").overlapText = "Theme : Clear";
            }
            else
            {
                ClearMenu = false;
            }
        }

        public static void MakeRain()
        {
            for (int i2 = 1; i2 < BetterDayNightManager.instance.weatherCycle.Length; i2++)
            {
                BetterDayNightManager.instance.weatherCycle[i2] = BetterDayNightManager.WeatherType.Raining;
            }
        }
        public static void DontMakeRain()
        {
            for (int i2 = 1; i2 < BetterDayNightManager.instance.weatherCycle.Length; i2++)
            {
                BetterDayNightManager.instance.weatherCycle[i2] = BetterDayNightManager.WeatherType.None;
            }
        }

        public static void Chams()
        {
            foreach (VRRig rigs in GorillaParent.instance.vrrigs)
            {
                if (rigs.mainSkin.material.name.Contains("fected"))
                {
                    rigs.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    rigs.mainSkin.material.color = new Color32(255, 0, 0, 255);
                    GorillaTagger.Instance.offlineVRRig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                    GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = GorillaTagger.Instance.offlineVRRig.playerColor;
                }
                else
                {
                    rigs.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    rigs.mainSkin.material.color = new Color32(0, 255, 0, 255);
                    GorillaTagger.Instance.offlineVRRig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                    GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = GorillaTagger.Instance.offlineVRRig.playerColor;
                }
            }
        }
        public static void Chams2()
        {
            foreach (VRRig rigs in GorillaParent.instance.vrrigs)
            {
                if (!rigs.isOfflineVRRig || !rigs.isMyPlayer)
                {
                    rigs.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    rigs.mainSkin.material.color = Color.Lerp(MenuColor, Color.black, Mathf.PingPong(Time.time, 1f));
                }
            }
        }
        public static void ChamsOff()
        {
            foreach (VRRig rigs in GorillaParent.instance.vrrigs)
            {
                if (!rigs.isOfflineVRRig || !rigs.isMyPlayer)
                {
                    rigs.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                    rigs.mainSkin.material.color = rigs.playerColor;
                }
            }
                 
        }


    }
}
