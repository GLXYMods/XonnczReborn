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

namespace StupidTemplate.Mods
{
    public class Visual
    {
        public static List<TMPro.TextMeshPro> s = new List<TMPro.TextMeshPro> { };
        public static List<TMPro.TextMeshPro> d = new List<TMPro.TextMeshPro> { };
        public static GameObject motdText = null;
        public static GameObject mot = null;
        public static GameObject motdText2 = null;
        public static string livemotd = new WebClient().DownloadString("https://pastebin.com/raw/wxKmEsSE");
        public static string liveTitle = new WebClient().DownloadString("https://pastebin.com/raw/k8UgdFGS");
        public static void boards() // thanks to iidk for most of this i take no credit
        {
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor/monitorScreen").GetComponent<Renderer>().material.color = MenuColor;
            GameObject motdThing = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdtext");
            motdText = UnityEngine.Object.Instantiate(motdThing, motdThing.transform.parent);
            motdThing.SetActive(false);
            motdText.GetComponent<PlayFabTitleDataTextDisplay>().enabled = false;
            TextMeshPro motdTextB = motdText.GetComponent<TextMeshPro>();
            if (!s.Contains(motdTextB))
            {
                s.Add(motdTextB);
            }
            motdTextB.text = string.Format(livemotd);
            if (mot == null)
            {
                GameObject motdThing2 = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motd (1)");
                mot = UnityEngine.Object.Instantiate(motdThing2, motdThing2.transform.parent);
                motdThing2.SetActive(false);
            }
            TextMeshPro motdTC = mot.GetComponent<TextMeshPro>();
            if (!d.Contains(motdTC))
            {
                d.Add(motdTC);
            }
            motdTC.text = liveTitle;
        }
        public static float sig;
        public static int but = 1;
        public static void tracers()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
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
                MenuColor = Color.blue;
                OutlineColor = Color.cyan;
                GetIndex("Change Theme").overlapText = "Theme : Blue";
            }
            if (t == 2)
            {
                MenuColor = Color.black;
                OutlineColor = Color.grey;
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
                MenuColor = new Color32(255, 192, 203, 255);
                OutlineColor = new Color32(219, 112, 147, 255);
                GetIndex("Change Theme").overlapText = "Theme : Pink";
            }
            if (t == 6)
            {
                MenuColor = new Color32(207, 159, 255, 255);
                OutlineColor = new Color32(0, 0, 0, 255);
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
                {
                    rigs.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                    rigs.mainSkin.material.color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1f));
                    GorillaTagger.Instance.offlineVRRig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                    GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = GorillaTagger.Instance.offlineVRRig.playerColor;
                }
            }
        }
        public static void ChamsOff()
        {
            foreach (VRRig rigs in GorillaParent.instance.vrrigs)
            {
                rigs.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                rigs.mainSkin.material.color = rigs.playerColor;
                GorillaTagger.Instance.offlineVRRig.mainSkin.material.shader = Shader.Find("GorillaTag/UberShader");
                GorillaTagger.Instance.offlineVRRig.mainSkin.material.color = GorillaTagger.Instance.offlineVRRig.playerColor;
            }         
        }





    }
}
