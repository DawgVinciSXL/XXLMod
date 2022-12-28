﻿using GameManagement;
using HarmonyLib;
using Newtonsoft.Json;
using ReplayEditor;
using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XXLMod.Data.Enums;

namespace XXLMod.Controller
{
    public class XXLController : MonoBehaviour
    {
        public static XXLController Instance { get; private set; }

        public static XXLPopType PopType;

        private void Awake() => Instance = this;

        private void Start()
        {
        }

        private void Update()
        {
        }

        private void LateUpdate()
        {
            Physics.gravity = new Vector3(0, Main.Settings.GeneralSettings.Gravity, 0);
        }
    }
}