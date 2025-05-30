using BepInEx;
using GorillaLocomotion;
using GorillaTagScripts;
using System.Collections;
using HarmonyLib;
using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Mods;
using StupidTemplate.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TMPro;
using Player = GorillaLocomotion.GTPlayer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.UI;
using static StupidTemplate.Menu.Buttons;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;
using static Ui;
using Button = StupidTemplate.Classes.Button;
using Object = UnityEngine.Object;
using Photon.Voice.Unity;
using System.Reflection;
using Random = UnityEngine.Random;

namespace StupidTemplate.Menu
{
    [HarmonyPatch(typeof(Player), "LateUpdate")]
    public class Main : MonoBehaviour
    {
        public static int fontC = 0;
        public static Font Arial = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        public static Font Sans = Font.CreateDynamicFontFromOSFont("Comic Sans MS", 24);
        public static Font AgencyFB = Font.CreateDynamicFontFromOSFont("Agency FB", 24);
        public static Font consolas = Font.CreateDynamicFontFromOSFont("Consolas", 24);
        public static Font Verdana = Font.CreateDynamicFontFromOSFont("Verdana", 24);
        public static Font ubuntu = Font.CreateDynamicFontFromOSFont("Candara", 24);
        public static Font MSGOTHIC = Font.CreateDynamicFontFromOSFont("MS Gothic", 24);
        public static Font impact = Font.CreateDynamicFontFromOSFont("Impact", 24);
        public static bool thickk = true;
        public static void changemenufont()
        {
            fontC++;
            if (fontC > 6)
            {
                fontC = 0;
            }
            if (fontC < 0)
            {
                fontC = 6;
            }

            if (fontC == 0)
            {
                currentFont = Arial;
            }

            if (fontC == 1)
            {
                currentFont = Sans;
            }
            if (fontC == 2)
            {
                currentFont = Verdana;
            }
            if (fontC == 3)
            {
                currentFont = consolas;
            }
            if (fontC == 4)
            {
                currentFont = ubuntu;
            }
            if (fontC == 5)
            {
                currentFont = MSGOTHIC;
            }
            if (fontC == 6)
            {
                currentFont = impact;
            }
        }

        public static int btn = 0;
        public static void changebuttonsound()
        {
            btn++;
            if (btn > 29)
            {
                btn = 0;
            }
            if (btn < 0)
            {
                btn = 29;
            }

            if (btn == 0)
            {
                Button.buttonSound = 114;
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }

            if (btn == 1)
            {
                Button.buttonSound = 123;
            }

            if (btn == 2)
            {
                Button.buttonSound = 138;
            }

            if (btn == 3)
            {
                Button.buttonSound = 146;
            }

            if (btn == 4)
            {
                Button.buttonSound = 147;
            }

            if (btn == 5)
            {
                Button.buttonSound = 140;
            }

            if (btn == 6)
            {
                Button.buttonSound = 85;
            }

            if (btn == 7)
            {
                Button.buttonSound = 84;
            }

            if (btn == 8)
            {
                Button.buttonSound = 92;
            }

            if (btn == 9)
            {
                Button.buttonSound = 91;
            }
            if (btn == 10)
            {
                Button.buttonSound = 55;
            }
            if (btn == 11)
            {
                Button.buttonSound = 73;
            }
            if (btn == 12)
            {
                Button.buttonSound = 51;
            }
            if (btn == 13)
            {
                Button.buttonSound = 15;
            }
            if (btn == 14)
            {
                Button.buttonSound = 32;
            }
            if (btn == 15)
            {
                Button.buttonSound = 64;
            }
            if (btn == 16)
            {
                sound1 = true;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 17)
            {
                sound1 = false;
                sound2 = true;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 18)
            {
                sound1 = false;
                sound2 = false;
                sound3 = true;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 19)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = true;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 20)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = true;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 21)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = true;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 22)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = true;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 23)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = true;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 24)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = true;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 25)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = true;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 26)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = true;
                sound12 = false;
                sound13 = false;
                sound14 = false;

            }
            if (btn == 27)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = true;
                sound13 = false;
                sound14 = false;
            }
            if (btn == 28)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = true;
                sound14 = false;
            }
            if (btn == 29)
            {
                sound1 = false;
                sound2 = false;
                sound3 = false;
                sound4 = false;
                sound5 = false;
                sound6 = false;
                sound7 = false;
                sound8 = false;
                sound9 = false;
                sound10 = false;
                sound11 = false;
                sound12 = false;
                sound13 = false;
                sound14 = true;
            }
        }



        public static bool sound1 = false;
        public static bool sound2 = false;
        public static bool sound3 = false;
        public static bool sound4 = false;
        public static bool sound5 = false;
        public static bool sound6 = false;
        public static bool sound7 = false;
        public static bool sound8 = false;
        public static bool sound9 = false;
        public static bool sound10 = false;
        public static bool sound11 = false;
        public static bool sound12 = false;
        public static bool sound13 = false;
        public static bool sound14 = false;


        public static ButtonInfo[] GetSearchedButtons()
        {
            List<ButtonInfo> result = new List<ButtonInfo>();
            foreach (var buttons in buttons)
                foreach (var button in buttons)
                    if (GetButtonText(button).Contains(KeyboardString))
                        result.Add(button);
            return result.ToArray();
        }

        public static void Searched()
        {
            add(11, GetSearchedButtons());
        }


        public static void add(int category, ButtonInfo[] buttoninfo, int index = -1)
        {
            List<ButtonInfo> buttonInfoList = Buttons.buttons[category].ToList();
            if (index > 0)
            {
                for (int i = 0; i < buttoninfo.Length; i++)
                    buttonInfoList.Insert(index + i, buttoninfo[i]);
            }
            else
            {
                foreach (ButtonInfo button in buttoninfo)
                    buttonInfoList.Add(button);
            }
            Buttons.buttons[category] = buttonInfoList.ToArray();
        }



        public static void Keyboardkey(string Key)
        {
            if (Key == "Space")
            {
                KeyboardString += " ";
            }
            else
            {
                if (Key == "BackSpace")
                {
                    KeyboardString = KeyboardString.Substring(0, KeyboardString.Length - 1);
                }
                else
                {
                    KeyboardString += Key.ToLower();
                }
            }
            Main.RecreateMenu();
        }



        public static ButtonInfo[] GetEnabledButtons()
        {
            List<ButtonInfo> result = new List<ButtonInfo>();
            foreach (var buttons in buttons)
            {
                foreach (var button in buttons)
                {
                    if (button.enabled)
                    {
                        result.Add(button);
                    }
                }
            }
            return result.ToArray();
        }

        public static string GetButtonText(ButtonInfo button)
        {
            return button.buttonText;
        }

        public static string KeyboardString = "";

        public static void CreateKey(Vector3 scale, Vector3 pos)
        {
            GameObject key = GameObject.CreatePrimitive(PrimitiveType.Cube);
            key.transform.localScale = scale;
            key.transform.position = pos;
        }

        public static async void LoadSoundFromURL(string url)
        {
            using (UnityWebRequest unityWebRequest = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG))
            {
                UnityWebRequestAsyncOperation unityWebRequest2 = unityWebRequest.SendWebRequest();
                while (!unityWebRequest2.isDone)
                {
                    await Task.Yield();
                }
                if (unityWebRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Failed to load because: " + unityWebRequest.error);
                }
                else
                {
                    AudioClip audioClip = DownloadHandlerAudioClip.GetContent(unityWebRequest);
                    if (audioClip == null)
                    {
                        Debug.LogError("Downloaded audio is null for whatever reason :)");
                        return;
                    }
                    AudioSource audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
                    audioSource.clip = audioClip;
                    audioSource.Play();
                    Object.Destroy(audioSource.gameObject, audioClip.length);
                }
            }
        }


        public static bool pagebuttons = true;

        public static void Save()
        {
            List<String> list = new List<String>();
            foreach (ButtonInfo[] button in Buttons.buttons)
            {
                foreach (ButtonInfo button2 in button)
                {
                    if (button2.enabled == true)
                    {
                        list.Add(button2.buttonText + button2.overlapText);
                    }
                }
            }
            Directory.CreateDirectory("XonnczReborn");
            File.WriteAllLines("XonnczReborn\\Prefabs.txt", list);
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Saved Mods!");
        }
        public static void SaveSettings()
        {
            List<String> list = new List<String>();
            foreach (ButtonInfo[] button in Menu.Buttons.buttons)
            {
                foreach (ButtonInfo button2 in button)
                {
                    if (button2.enabled == true)
                    {
                        list.Add(button2.buttonText + button2.overlapText);
                    }
                }
            }
            Directory.CreateDirectory("XonnczReborn");
            File.WriteAllLines("XonnczReborn\\Settings.txt", list);
            string text4 = string.Concat(new string[]
            {
               btn.ToString(),
               "\n",
               fontC.ToString(),
               "\n",
               Visual.t.ToString(),
               "\n",
               Rig.l.ToString(),
               "\n",
               Projectiles.a.ToString(),
               "\n",
               Projectiles.c.ToString(),
               "\n",
            });
            File.WriteAllText("XonnczReborn\\Settings.txt", text4.ToString());
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Saved Settings!");
        }

        public static void LoadSettings()
        {
            string[] array = File.ReadAllLines("XonnczReborn\\Settings.txt");
            foreach (string b in array)
            {
                foreach (ButtonInfo[] button in Buttons.buttons)
                {
                    foreach (ButtonInfo button2 in button)
                    {
                        if (button2.buttonText == b)
                        {
                            button2.enabled = button2.isTogglable;
                        }
                    }
                }
            }
            try
            {
                string text3 = File.ReadAllText("XonnczReborn\\Settings.txt");
                string[] array4 = text3.Split(new string[] { "\n" }, StringSplitOptions.None);
                btn = int.Parse(array4[0]) - 1;
                changebuttonsound();
                fontC = int.Parse(array4[1]) - 1;
                changemenufont();
                Visual.t = int.Parse(array4[2]) - 1;
                Visual.ChangeMenuTheme();
            }
            catch { /* skibidi sigma rizz :) */ }
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Loaded Settings!");
        }

        public static void Load()
        {
            String[] thing = File.ReadAllLines("XonnczReborn\\Prefabs.txt");
            foreach (String thing2 in thing)
            {
                foreach (ButtonInfo[] button in Menu.Buttons.buttons)
                {
                    foreach (ButtonInfo button2 in button)
                    {
                        if (button2.buttonText + button2.overlapText == thing2)
                        {
                            button2.enabled = true;
                        }
                    }
                }
            }
            NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESSFULLY</color><color=grey>]</color> Loaded Mods!");
        }



        // Constant
        public static void Prefix()
        {
            // Initialize Menu
            try
            {
                bool toOpen = (!rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton) || (rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton);
                bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);

                if (menu == null)
                {
                    if (toOpen || keyboardOpen)
                    {
                        CreateMenu();
                        RecenterMenu(rightHanded, keyboardOpen);
                        if (reference == null)
                        {
                            CreateReference(rightHanded);
                        }
                    }
                }
                else
                {
                    if ((toOpen || keyboardOpen))
                    {
                        RecenterMenu(rightHanded, keyboardOpen);
                    }
                    else
                    {
                        GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(true);
                        Rigidbody comp = menu.AddComponent<Rigidbody>();
                        if (rightHanded)
                        {
                            comp.velocity = GorillaLocomotion.GTPlayer.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }
                        else
                        {
                            comp.velocity = GorillaLocomotion.GTPlayer.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }
                        UnityEngine.Object.Destroy(menu, 2);
                        menu = null;
                        UnityEngine.Object.Destroy(reference);
                        reference = null;

                    }
                }
            }
            catch (Exception exc)
            {
                UnityEngine.Debug.LogError(string.Format("{0} // Error initializing at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }

            // Constant
            try
            {
                // Pre-Execution
                if (fpsObject != null)
                {
                    deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
                    float currentFPS = 1f / deltaTime;
                    timer += Time.unscaledDeltaTime;
                    if (timer >= updateInterval)
                    {
                        fps = Mathf.Ceil(currentFPS);
                        timer = 0f;
                    }
                    fpsObject.text = $"Fps : {Mathf.Ceil(fps)}";
                }
                // Execute Enabled mods
                foreach (ButtonInfo[] buttonlist in buttons)
                {
                    foreach (ButtonInfo v in buttonlist)
                    {
                        if (v.enabled)
                        {
                            if (v.method != null)
                            {
                                try
                                {
                                    v.method.Invoke();
                                }
                                catch (Exception exc)
                                {
                                    UnityEngine.Debug.LogError(string.Format("{0} // Error with mod {1} at {2}: {3}", PluginInfo.Name, v.buttonText, exc.StackTrace, exc.Message));
                                }
                            }
                        }
                    }
                }
            } catch (Exception exc)
            {
                UnityEngine.Debug.LogError(string.Format("{0} // Error with executing mods at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }
        }



        private static float deltaTime = 0f;
        private static float updateInterval = 1f;
        private static float timer = 0f;
        private static float fps = 0f;

        public static int Fade = 0;

        public static bool ClearMenu = false;

        public static void ChangeFadingColor1()
        {
            Fade++;
            if (Fade < 0)
            {
                Fade = 8;
            }
            if (Fade > 8)
            {
                Fade = 0;
            }

            if (Fade == 0)
            {
                fadingcolor1 = Color.red;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=red>Red</color>]";
            }
            if (Fade == 1)
            {
                fadingcolor1 = Color.blue;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=blue>Blue</color>]";
            }
            if (Fade == 2)
            {
                fadingcolor1 = Color.green;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=green>Green</color>]";
            }
            if (Fade == 3)
            {
                fadingcolor1 = Color.cyan;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=cyan>Cyan</color>]";
            }
            if (Fade == 4)
            {
                fadingcolor1 = Color.magenta;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=magenta>Magenta</color>]";
            }
            if (Fade == 5)
            {
                fadingcolor1 = Color.black;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=black>Black</color>]";
            }
            if (Fade == 6)
            {
                fadingcolor1 = Color.grey;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=grey>Grey</color>]";
            }
            if (Fade == 7)
            {
                fadingcolor1 = Color.yellow;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=yellow>Yellow</color>]";
            }
            if (Fade == 8)
            {
                fadingcolor1 = Color.white;
                GetIndex("Faded Menu Color 1").overlapText = "Faded Menu Color[<color=white>White</color>]";
            }
        }
        public static void ChangeFadingColor2()
        {
            Fade++;
            if (Fade < 0)
            {
                Fade = 8;
            }
            if (Fade > 8)
            {
                Fade = 0;
            }

            if (Fade == 0)
            {
                fadingcolor2 = Color.red;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=red>Red</color>]";
            }
            if (Fade == 1)
            {
                fadingcolor2 = Color.blue;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=blue>Blue</color>]";
            }
            if (Fade == 2)
            {
                fadingcolor2 = Color.green;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=green>Green</color>]";
            }
            if (Fade == 3)
            {
                fadingcolor2 = Color.cyan;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=cyan>Cyan</color>]";
            }
            if (Fade == 4)
            {
                fadingcolor2 = Color.magenta;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=magenta>Magenta</color>]";
            }
            if (Fade == 5)
            {
                fadingcolor2 = Color.black;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=black>Black</color>]";
            }
            if (Fade == 6)
            {
                fadingcolor2 = Color.grey;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=grey>Grey</color>]";
            }
            if (Fade == 7)
            {
                fadingcolor2 = Color.yellow;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=yellow>Yellow</color>]";
            }
            if (Fade == 8)
            {
                fadingcolor2 = Color.white;
                GetIndex("Faded Menu Color 2").overlapText = "Faded Menu Color[<color=white>White</color>]";
            }
        }
        public static void OutlineColor1()
        {
            Fade++;
            if (Fade < 0)
            {
                Fade = 9;
            }
            if (Fade > 9)
            {
                Fade = 0;
            }

            if (Fade == 0)
            {
                OutlineColor = Color.red;
                GetIndex("Outline Color").overlapText = "Outline Color[<color=red>Red</color>]";
            }
            if (Fade == 1)
            {
                OutlineColor = Color.blue;
                GetIndex("Outline Color").overlapText = "Outline Color[<color=blue>Blue</color>]";
            }
            if (Fade == 2)
            {
                OutlineColor = Color.green;
                GetIndex("Outline Color").overlapText = "Outline Color[<color=green>Green</color>]";
            }
            if (Fade == 3)
            {
                OutlineColor = Color.cyan;
                GetIndex("Outline Color").overlapText = "Outline Color[<color=cyan>Cyan</color>]";
            }
            if (Fade == 4)
            {
                OutlineColor = Color.magenta;
                GetIndex("Outline Color").overlapText = "Outline Color[<color=magenta>Magenta</color>]";
            }
            if (Fade == 5)
            {
                OutlineColor = Color.black;
                GetIndex("Outline Color").overlapText = "Outline Color[<color=black>Black</color>]";
            }
            if (Fade == 6)
            {
                OutlineColor = Color.grey;
                GetIndex("Outline Color").overlapText = "Outline Color[<color=grey>Grey</color>]";
            }
            if (Fade == 7)
            {
                OutlineColor = Color.yellow;
                GetIndex("Outline Color").overlapText = "Outline Color[<color=yellow>Yellow</color>]";
            }
            if (Fade == 8)
            {
                OutlineColor = Color.white;
                GetIndex("Outline Color").overlapText = "Outline Color[<color=white>White</color>]";
            }
            if (Fade == 9)
            {
                OutlineColor = MenuColor;
                GetIndex("Outline Color").overlapText = "Outline Color[<color=white>Theme</color>]";
            }
        }

        public static Color MenuColor = new Color32(255, 0, 0, 255);
        public static Color fadingcolor1 = Color.red;
        public static Color fadingcolor2 = Color.black;
        public static Color OutlineColor = new Color32(0, 0, 0, 255);
        public static Color enabledColor = MenuColor;
        public static bool fading = false;


        public static GameObject outline;

        public static bool Outlinee = true;

        public static float speed = 1f;
        public static float rad = 1f;

        public static float ang = 0f;
        public static Vector3 ax;


        public class orbitOBJ : MonoBehaviour
        {
            void Start()
            {
                ax = Random.onUnitSphere;
            }
            void Update()
            {
                Vector3 orbit = new Vector3(
                    Mathf.Cos(ang) * rad + Random.Range(-0.05f, 0.05f), 
                    Mathf.Sin(ang) * rad + Random.Range(-0.05f, 0.05f), 
                    0f
                );
                transform.localPosition = Quaternion.AngleAxis(ang * Mathf.Rad2Deg, ax) * orbit;
                ang += speed * Time.deltaTime;
                if (ang > 2 * Mathf.PI)
                {
                    ang -= 2 * Mathf.PI;
                }
            }
        }

        public static bool trail = true;
        public static bool orbit = true;

        public static void TrailOff()
        {
            trail = false;
        }

        public static void TrailOn()
        {
            trail = true;
        }
        public static void OrbitOff()
        {
            orbit = false;
        }

        public static void OrbitOn()
        {
            orbit = true;
        }

        public static void CreateMenu()
        {
            // Menu Holder
                menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
                menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);

            // Menu Background
                menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(menuBackground.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(menuBackground.GetComponent<BoxCollider>());
                menuBackground.transform.parent = menu.transform;
                menuBackground.transform.rotation = Quaternion.identity;
                menuBackground.transform.localScale = menuSize;
                menuBackground.GetComponent<Renderer>().material.color = MenuColor;

                
                // idrc if u skid this :)
                GameObject sphereobk = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                if (trail)
                {
                    try
                    {
                        if (orbit)
                        {
                            TrailRenderer Menutrail = sphereobk.AddComponent<TrailRenderer>();
                            Menutrail.startColor = new Color32(0, 0, 0, 150);
                            Menutrail.endColor = new Color32(0, 0, 0, 150);
                            Menutrail.startWidth = 0.055f;
                            Menutrail.endWidth = 0f;
                            Menutrail.minVertexDistance = 0.05f;
                            Menutrail.material.shader = Shader.Find("Sprites/Default");
                            Menutrail.time = 2f;
                            sphereobk.transform.parent = menu.transform;
                            sphereobk.transform.localScale = new Vector3(0.09f, 0.1f, 0.1f);
                            sphereobk.GetComponent<Renderer>().material.color = Color.black;
                            Object.Destroy(sphereobk.GetComponent<Collider>());
                            sphereobk.AddComponent<orbitOBJ>();
                        }
                        else
                        if (!orbit)
                        {
                            TrailRenderer Menutrail = menu.AddComponent<TrailRenderer>();
                            Menutrail.startColor = new Color32(0, 0, 0, 150);
                            Menutrail.endColor = new Color32(0, 0, 0, 150);
                            Menutrail.startWidth = 0.055f;
                            Menutrail.endWidth = 0f;
                            Menutrail.minVertexDistance = 0.05f;
                            Menutrail.material.shader = Shader.Find("Sprites/Default");
                            Menutrail.time = 2f;
                        }
                        
                    }
                    catch { }
                }
                
                

                


            if (Outlinee)
                { 
                    outline = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(outline.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(outline.GetComponent<BoxCollider>());
                    outline.transform.parent = menu.transform;
                    outline.transform.rotation = Quaternion.identity;
                    outline.transform.localScale = outlineSize;
                    if (thickk)
                    {
                        outline.transform.localScale = thick;
                    }
                    outline.transform.position = new Vector3(0.05f, 0f, 0f);
                    outline.GetComponent<Renderer>().material.color = OutlineColor;   
                    if (ClearMenu)
                    {
                        outline.GetComponent<Renderer>().enabled = false;
                    }
                    else
                    {
                        outline.GetComponent<Renderer>().enabled = true;
                    }
                }
                if (fading) 
                { 
                    GradientColorKey[] array = new GradientColorKey[3];
                    array[0].color = fadingcolor1;
                    array[0].time = 0f;
                    array[1].color = fadingcolor2;
                    array[1].time = 0.5f;
                    array[2].color = fadingcolor1;
                    array[2].time = 1f;
                    ColorChanger faded = menuBackground.AddComponent<ColorChanger>();
                    faded.colorInfo = new ExtGradient
                    {
                        colors = array
                    };
                    faded.Start();
                }
                else
                {
                    GradientColorKey[] array = new GradientColorKey[3];
                    array[0].color = MenuColor;
                    array[0].time = 0f;
                    array[1].color = MenuColor;
                    array[1].time = 0.5f;
                    array[2].color = MenuColor;
                    array[2].time = 1f;
                    ColorChanger faded = menuBackground.AddComponent<ColorChanger>();
                    faded.colorInfo = new ExtGradient
                    {
                        colors = array
                    };
                    faded.Start();
                } 
                if (ClearMenu) 
                {
                    menuBackground.GetComponent<Renderer>().enabled = false;
                    menu.GetComponent<Renderer>().enabled = false;
                }
                else
                {
                    menuBackground.GetComponent<Renderer>().enabled = true;
                }    
                menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);



            // Canvas
                canvasObject = new GameObject();
                canvasObject.transform.parent = menu.transform;
                Canvas canvas = canvasObject.AddComponent<Canvas>();
                CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
                canvasObject.AddComponent<GraphicRaycaster>();
                canvas.renderMode = RenderMode.WorldSpace;
                canvasScaler.dynamicPixelsPerUnit = 1000f;

            // Title and FPS
                Text text = new GameObject
                {
                    transform =
                    {
                        parent = canvasObject.transform
                    }
                }.AddComponent<Text>();
                text.font = currentFont;
                type(text, PluginInfo.Name);
                text.fontSize = 1;
                text.color = textColors[0];
                text.supportRichText = true;
                text.fontStyle = FontStyle.Italic;
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                text.resizeTextMinSize = 0;
                RectTransform component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.18f, 0.03f);
                component.position = new Vector3(0.06f, 0f, 0.145f);
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                if (fpsCounter)
                {
                    fpsObject = new GameObject
                    {
                        transform =
                    {
                        parent = canvasObject.transform
                    }
                    }.AddComponent<Text>();
                    fpsObject.font = currentFont;
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                    fpsObject.color = textColors[0];
                    fpsObject.fontSize = 1;
                    fpsObject.supportRichText = true;
                    fpsObject.fontStyle = FontStyle.Italic;
                    fpsObject.alignment = TextAnchor.MiddleCenter;
                    fpsObject.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
                    fpsObject.resizeTextForBestFit = true;
                    fpsObject.resizeTextMinSize = 0;
                    RectTransform component2 = fpsObject.GetComponent<RectTransform>();
                    component2.localPosition = Vector3.zero;
                    component2.sizeDelta = new Vector2(0.18f, 0.01f);
                    component2.position = new Vector3(0.06f, 0f, 0.121f);
                    component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                }

            // Buttons
                // Home                   
                    // disconnect Button
                    if (disconnectButton)
                    {
                        GameObject disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        GameObject outline = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (!UnityInput.Current.GetKey(KeyCode.Q))
                        {
                            disconnectbutton.layer = 2;
                        }
                        UnityEngine.Object.Destroy(disconnectbutton.GetComponent<Rigidbody>());
                        disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                        disconnectbutton.transform.parent = menu.transform;
                        disconnectbutton.transform.rotation = Quaternion.identity;
                        disconnectbutton.transform.localScale = new Vector3(0.07f, 0.74f, 0.14f);
                        disconnectbutton.transform.localPosition = new Vector3(0.63f, 0f, 0.57f);
                        disconnectbutton.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                        disconnectbutton.AddComponent<Classes.Button>().relatedText = "Disconnect";

                        outline.transform.parent = menu.transform;
                        outline.transform.rotation = Quaternion.identity;
                        outline.transform.localScale = new Vector3(0.06f, 0.76f, 0.15f);
                        outline.transform.localPosition = new Vector3(0.63f, 0f, 0.57f);
                        outline.GetComponent<Renderer>().material.color = OutlineColor;
                        ColorChanger colorChangers = menuBackground.AddComponent<ColorChanger>();
                        colorChangers = disconnectbutton.AddComponent<ColorChanger>();
                        colorChangers.colorInfo = buttonColors[0];
                        colorChangers.Start();              
                        Text discontext = new GameObject
                        {
                            transform =
                            {
                                parent = canvasObject.transform
                            }
                        }.AddComponent<Text>();
                        discontext.text = "Disconnect";
                        discontext.font = currentFont;
                        discontext.fontSize = 1;
                        discontext.color = textColors[0];
                        discontext.alignment = TextAnchor.MiddleCenter;
                        discontext.resizeTextForBestFit = true;
                        discontext.resizeTextMinSize = 0;
                        RectTransform rectt = discontext.GetComponent<RectTransform>();
                        rectt.localPosition = Vector3.zero;
                        rectt.sizeDelta = new Vector2(0.2f, 0.03f);
                        rectt.localPosition = new Vector3(0.067f, disconnectbutton.transform.position.y, disconnectbutton.transform.position.z + 0.006f);
                        rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                        if (ClearMenu)
                        {
                            disconnectbutton.GetComponent<Renderer>().enabled = false;
                            outline.GetComponent<Renderer>().enabled = false;
                        }
                        else
                        {
                            disconnectbutton.GetComponent<Renderer>().enabled = true;
                            outline.GetComponent<Renderer>().enabled = true;
                        }
                    }

                    if (home) 
                    { 
                        GameObject disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        GameObject outline = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (!UnityInput.Current.GetKey(KeyCode.Q))
                        {
                            disconnectbutton.layer = 2;
                        }
                        UnityEngine.Object.Destroy(disconnectbutton.GetComponent<Rigidbody>());
                        disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                        disconnectbutton.transform.parent = menu.transform;
                        disconnectbutton.transform.rotation = Quaternion.identity;
                        disconnectbutton.transform.localScale = new Vector3(0.07f, 0.74f, 0.14f);
                        disconnectbutton.transform.localPosition = new Vector3(0.63f, 0f, -0.57f);
                        disconnectbutton.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                        disconnectbutton.AddComponent<Classes.Button>().relatedText = "Home";

                        
                        outline.transform.parent = menu.transform;
                        outline.transform.rotation = Quaternion.identity;
                        outline.transform.localScale = new Vector3(0.06f, 0.76f, 0.15f);
                        outline.transform.localPosition = new Vector3(0.63f, 0f, -0.57f);
                        outline.GetComponent<Renderer>().material.color = OutlineColor;

                        ColorChanger colorChangers = menuBackground.AddComponent<ColorChanger>();
                        colorChangers = disconnectbutton.AddComponent<ColorChanger>();
                        colorChangers.colorInfo = buttonColors[0];
                        colorChangers.Start();              
                        Text discontext = new GameObject
                        {
                            transform =
                            {
                                parent = canvasObject.transform
                            }
                        }.AddComponent<Text>();
                        discontext.text = "Return";
                        discontext.font = currentFont;
                        discontext.fontSize = 1;
                        discontext.color = textColors[0];
                        discontext.alignment = TextAnchor.MiddleCenter;
                        discontext.resizeTextForBestFit = true;
                        discontext.resizeTextMinSize = 0;
                        RectTransform rectt = discontext.GetComponent<RectTransform>();
                        rectt.localPosition = Vector3.zero;
                        rectt.sizeDelta = new Vector2(0.2f, 0.03f);
                        rectt.localPosition = new Vector3(0.067f, disconnectbutton.transform.position.y, disconnectbutton.transform.position.z + 0.006f);
                        rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                        if (ClearMenu)
                        {
                            disconnectbutton.GetComponent<Renderer>().enabled = false;
                            outline.GetComponent<Renderer>().enabled = false;
                        }
                        else
                        {
                            disconnectbutton.GetComponent<Renderer>().enabled = true;
                            outline.GetComponent<Renderer>().enabled = true;
                        }
                    }

             // Page Buttons
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                GameObject outline1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                GameObject outline2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    gameObject.layer = 2;
                }
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.localScale = new Vector3(0.1f, 0.2f, 0.09f);
                gameObject.transform.localPosition = new Vector3(0.56f, 0.12f, -0.35f);
                gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                gameObject.AddComponent<Classes.Button>().relatedText = "PreviousPage";

                outline1.transform.parent = menu.transform;
                outline1.transform.rotation = Quaternion.identity;
                outline1.transform.localScale = new Vector3(0.09f, 0.23f, 0.1f);
                outline1.transform.localPosition = new Vector3(0.56f, 0.12f, -0.35f);
                outline1.GetComponent<Renderer>().material.color = OutlineColor;
                
                if (ClearMenu) 
                {
                    outline1.GetComponent<Renderer>().enabled = false;
                }
                else
                {
                    outline1.GetComponent<Renderer>().enabled = true;
                }
                
                ColorChanger colorChanger = menuBackground.AddComponent<ColorChanger>();
                colorChanger.Start();
                colorChanger = gameObject.AddComponent<ColorChanger>();
                colorChanger.colorInfo = buttonColors[0];
                colorChanger.Start();

                text = new GameObject
                {
                    transform =
                        {
                            parent = canvasObject.transform
                        }
                }.AddComponent<Text>();
                text.font = currentFont;
                text.text = "<";
                text.fontSize = 1;
                text.color = textColors[0];
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                text.resizeTextMinSize = 0;
                component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.2f, 0.03f);
                component.localPosition = new Vector3(0.064f, gameObject.transform.position.y, gameObject.transform.position.z + 0.006f);
                if (ClearMenu)
                {
                    gameObject.GetComponent<Renderer>().enabled = false;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().enabled = true;
                }
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    gameObject.layer = 2;
                }
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.localScale = new Vector3(0.1f, 0.2f, 0.09f);
                gameObject.transform.localPosition = new Vector3(0.56f, -0.13f, -0.35f);
                gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                gameObject.AddComponent<Classes.Button>().relatedText = "NextPage";

                
                outline2.transform.parent = menu.transform;
                outline2.transform.rotation = Quaternion.identity;
                outline2.transform.localScale = new Vector3(0.09f, 0.23f, 0.1f);
                outline2.transform.localPosition = new Vector3(0.56f, -0.13f, -0.35f);
                outline2.GetComponent<Renderer>().material.color = OutlineColor;
                
                if (ClearMenu) 
                {
                    outline2.GetComponent<Renderer>().enabled = false;
                }
                else
                {
                    outline2.GetComponent<Renderer>().enabled = true;
                }
                
                colorChanger = gameObject.AddComponent<ColorChanger>();
                colorChanger.colorInfo = buttonColors[0];
                colorChanger.Start();

                text = new GameObject
                {
                    transform =
                        {
                            parent = canvasObject.transform
                        }
                }.AddComponent<Text>();
                text.font = currentFont;
                text.text = ">";
                text.fontSize = 1;
                text.color = textColors[0];
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                text.resizeTextMinSize = 0;
                component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.2f, 0.03f);
                component.localPosition = new Vector3(0.064f, gameObject.transform.position.y, gameObject.transform.position.z + 0.006f);
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                if (ClearMenu) 
                {
                    gameObject.GetComponent<Renderer>().enabled = false;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().enabled = true;
                }
            ButtonInfo[] activeButtons = buttons[buttonsType].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
            for (int i = 0; i < activeButtons.Length; i++)
            {
                CreateButton(i * 0.1f, activeButtons[i]);
            }
        }



        public static async Task type(Text shit, string text)
        {
            shit.text = "";
            foreach (char letter in text)
            {
                shit.text += letter;
                await Task.Delay((int)(0.2 * 1000));
            }
        }



        public static void CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.6f, 0.08f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.25f - offset);
            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;

            GameObject outline = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(outline.GetComponent<Rigidbody>());
            outline.GetComponent<BoxCollider>().isTrigger = true;
            outline.transform.parent = menu.transform;
            outline.transform.rotation = Quaternion.identity;
            outline.transform.localScale = new Vector3(0.07f, 0.62f, 0.09f);
            outline.transform.localPosition = new Vector3(0.56f, 0f, 0.25f - offset);
            outline.GetComponent<Renderer>().material.color = OutlineColor;

            if (ClearMenu)
            {
                outline.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                outline.GetComponent<Renderer>().enabled = true;
            }

            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                gameObject.GetComponent<Renderer>().material.color = MenuColor;
            }
            else
            {
                colorChanger.colorInfo = buttonColors[0];
            }
            colorChanger.Start();

            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = method.buttonText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.1f, .02f);
            component.localPosition = new Vector3(.064f, gameObject.transform.position.y, gameObject.transform.position.z);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (ClearMenu)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
        }
        public static void CreateCategoriesButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.51f, 0.08f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0.48f, 0.25f - offset);
            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;

            GameObject outline = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(outline.GetComponent<Rigidbody>());
            outline.GetComponent<BoxCollider>().isTrigger = true;
            outline.transform.parent = menu.transform;
            outline.transform.rotation = Quaternion.identity;
            outline.transform.localScale = new Vector3(0.07f, 0.53f, 0.09f);
            outline.transform.localPosition = new Vector3(0.56f, 0.48f, 0.25f - offset);
            outline.GetComponent<Renderer>().material.color = OutlineColor;

            if (ClearMenu)
            {
                outline.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                outline.GetComponent<Renderer>().enabled = true;
            }


            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                gameObject.GetComponent<Renderer>().material.color = MenuColor;
            }
            else
            {
                colorChanger.colorInfo = buttonColors[0];
            }
            colorChanger.Start();

            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = method.buttonText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.1f, .02f);
            component.localPosition = new Vector3(.064f, gameObject.transform.position.y, gameObject.transform.position.z);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (ClearMenu)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = true;
            }
        }

        public static void RecreateMenu()
        {
            if (menu != null)
            {
                UnityEngine.Object.Destroy(menu);
                menu = null;
                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            {
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch { }
                GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(false);
                if (TPC != null)
                {
                    TPC.transform.position = new Vector3(-64f, 3.4f, -65f);
                    TPC.transform.rotation = Quaternion.identity;                    
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = TPC.transform.position + (TPC.transform.forward * 0.5f) + (TPC.transform.up * 0f);
                    Vector3 rot = TPC.transform.rotation.eulerAngles;
                    rot += new Vector3(-90f, 90f, 0f);
                    menu.transform.rotation = Quaternion.Euler(rot);

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (isRightHanded)
            {
                reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
            }
            else
            {
                reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
            }
            reference.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            buttonCollider = reference.GetComponent<SphereCollider>();

            ColorChanger colorChanger = reference.AddComponent<ColorChanger>();
            colorChanger.colorInfo = backgroundColor;
            colorChanger.Start();
        }

        /*
        public static void Enabled()
        {
            add(11, GetEnabledButtons());
        }

        public static ButtonInfo[] Idk(string[] str)
        {
            List<ButtonInfo> buttonInfo = new List<ButtonInfo>();
            foreach (string skib in str)
            {
                buttonInfo.Add(GetIndex(skib));
            }
            return buttonInfo.ToArray();
        }
        */

        public static void Toggle(string buttonText)
        {
            int lastPage = ((Buttons.buttons[buttonsType].Length + buttonsPerPage - 1) / buttonsPerPage) - 1;
            /*
            if (buttonsType == 11)
            {
                ButtonInfo[] buttoninfo = Buttons.buttons[buttonsType];
                List<string> enabledMods = new List<string>() { "Return To Main" };
                foreach (ButtonInfo[] buttonlist in Buttons.buttons)
                {
                    foreach (ButtonInfo v in buttonlist)
                    {
                        if (v.enabled)
                        {
                            enabledMods.Add(v.buttonText);
                        }
                    }
                }
                enabledMods = Shit(enabledMods.ToArray()).ToList();
                lastPage = ((enabledMods.Count + buttonsPerPage - 1) / buttonsPerPage) - 1;
            }
            */
            if (buttonText == "PreviousPage")
            {
                pageNumber--;
                if (pageNumber < 0)
                {
                    pageNumber = lastPage;
                }
            } 
            else
            {
                if (buttonText == "NextPage")
                {
                    pageNumber++;
                    if (pageNumber > lastPage)
                    {
                        pageNumber = 0;
                    }
                }
                else 
                if (buttonText == "Disconnect")
                {
                    PhotonNetwork.Disconnect();
                }
                if (buttonText == "Home")
                {
                    Global.ReturnHome();
                }
                else
                {
                    ButtonInfo target = GetIndex(buttonText);
                    if (target != null)
                    {
                        if (target.isTogglable)
                        {
                            target.enabled = !target.enabled;
                            if (target.enabled)
                            {
                                NotifiLib.SendNotification("<color=red>[</color><color=red>ENABLE</color><color=red>]</color> " + target.toolTip);
                                if (target.enableMethod != null)
                                {
                                    try { target.enableMethod.Invoke(); } catch { }
                                }
                            }
                            else
                            {
                                NotifiLib.SendNotification("<color=red>[</color><color=red>DISABLE</color><color=red>]</color> " + target.toolTip);
                                if (target.disableMethod != null)
                                {
                                    try { target.disableMethod.Invoke(); } catch { }
                                }
                            }
                        }
                        else
                        {
                            NotifiLib.SendNotification("<color=red>[</color><color=red>ENABLE</color><color=red>]</color> " + target.toolTip);
                            if (target.method != null)
                            {
                                try { target.method.Invoke(); } catch { }
                            }
                        }
                    }
                    else
                    {
                        UnityEngine.Debug.LogError(buttonText + " does not exist");
                    }
                }
            }
            RecreateMenu();
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }

        public static ButtonInfo GetIndex(string buttonText)
        {
            foreach (ButtonInfo[] buttons in Menu.Buttons.buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        return button;
                    }
                }
            }

            return null;
        }

        // Variables
            // Important
                // Objects
                    public static GameObject menu;
                    public static GameObject menuBackground;   
                    public static GameObject reference;
                    public static GameObject canvasObject;

                    public static SphereCollider buttonCollider;
                    public static Camera TPC;
                    public static Text fpsObject;

        // Data
            public static int pageNumber = 0;
            public static int pageNumber2 = 0;
            public static int buttonsType = 0;
    }
}
