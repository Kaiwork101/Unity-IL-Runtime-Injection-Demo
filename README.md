# Unity IL Runtime Injection Demo (Harmony Transpiler)

## Overview
This repository demonstrates dynamic runtime modification of .NET Intermediate Language (IL) opcodes without access to original source code. 

## Technical Implementation
* **Reverse Engineering:** Analyzed target game assembly (`Assembly-CSharp.dll`) using **dnSpy** to inspect class structures and method execution flows.
* **Stack Balance & Opcode Injection:** Built a Harmony Transpiler patch targeting `JUnitAvatar::Update`. Injected a frame-based timer loop via `UnityEngine.Time.get_frameCount()` to dynamically generate a custom MP regeneration mechanism (`mp + 1` every 22 frames) while preserving evaluation stack integrity.

## Tech Stack
* **Language:** C# / .NET
* **Tools & Libraries:** HarmonyLib, dnSpy, CIL (Common Intermediate Language)
* **Use Cases:** Legacy .NET code recovery, binary patching, and runtime security analysis.
