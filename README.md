<br>
<br>
<div align="center">

<!-- img src="media/ph_logo.png" width=200/ -->

<a href="https://cakeneka.github.io/Unholy-Typing"><img src="https://readme-typing-svg.demolab.com?font=Roboto+Mono&weight=500&size=30&pause=1000&color=E2B714&background=37373700&center=true&vCenter=true&repeat=false&random=true&height=80&lines=Unholy+%E2%9B%A7+Typing" alt="Typing SVG" width="60%" /></a>

_A simple typing game_

</div>
<br>
<br>

<div align="center">

[![WebGL Build 🖤](https://github.com/CakeNeka/Unholy-Typing/actions/workflows/main.yml/badge.svg)](https://github.com/CakeNeka/Unholy-Typing/actions/workflows/main.yml)&nbsp;&nbsp;
![GitHub commit activity](https://img.shields.io/github/commit-activity/t/cakeneka/unholy-typing)

</div>

<details open="open">
  <summary><b>Table of contents</b></summary>

<br>

1. [About The Project](#-about-the-project)
2. [Overview](#-overview)
3. [Technologies Used](#%EF%B8%8F-technologies-used)
4. [Development](#-development)
5. [Project Files](#-project-files)
  
</details>

## 📜 About the project

This typing game was developed as a final project, I chose to build a typing game because I thought it's something really cool, besides, I'm quite good at typing.

## 🎨 Overview

Unholy Typing is a minimalistic falling words typing game where the player must type words that appear on the screen before they fall down. The visuals are inspired by the open source typing test [monkeytype.com][monkeytype-gh].

Some **key features** of Unholy Typing are:

- **Minimalistic design:** focused on simplicity and readability
- **Customization:** Several themes available
- **Accessibility:** Game difficulty changes based on the player's speed

## ⚙️ Technologies used

![Static Badge](https://img.shields.io/badge/Unity-100000?style=flat&logo=unity) 
![Static Badge](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)

This game has been developed using the **Unity** engine, which uses **C#** as scripting language. Since Unholy Typing is basically a text-based game, it heavily relies on the **TextMeshPro** Unity library.

## ⌨ Development

### 🐙 Git and GitHub

You can follow the development of this game through the [issues][gh-issues] and [GitHub Projects kanban table][gh-projects].
I'm using the [Conventional Commits][conventional-commits] standard so the git log is clean and understandable.

## 💾 Project files

- [`Assets`](./Assets/) It contains most of the game's files
  - [`Art`](./Assets/Art/) Font files
  - [`Prefabs`](./Assets/Prefabs/)  Prefab GameObjects. Prefabs are like GameObject templates to be cloned
  - [`Resources`](./Assets/Resources/) Text files source of random words
  - [`Scenes`](./Assets/Scenes/) Scenes are like levels in Unity
  - [`ScriptableObjects`](./Assets/ScriptableObjects/) Scriptable objects are data containers to save large amounts of data
  - [`Scripts`](./Assets/Scripts/) Game logic (c# scripts)
  - [`Sounds`](./Assets/Sounds/) Sound assets
  - [`StyleSheets`](./Assets/StyleSheets/) Custom stylesheets for TextMesh Pro
  - [`TextMesh Pro`](./Assets/TextMesh%20Pro/) Unity library for UI text.
- [`Packages`](./Packages/) Unity packages
- [`ProjectSettings`](./ProjectSettings/) Project config files
- [`media`](./media/) Resources for README.md

---

#### 🖤 Credits

![Static Badge](https://img.shields.io/badge/Made_without_🧠_by-Martina_Victoria-pink)

[gh-issues]: https://github.com/CakeNeka/Unholy-Typing/issues
[gh-projects]: https://github.com/users/CakeNeka/projects/5/views/1
[conventional-commits]: https://www.conventionalcommits.org/en/v1.0.0/
[monkeytype-gh]: https://github.com/monkeytypegame/monkeytype
[keyboard-icon]: https://fonts.google.com/icons?selected=Material+Symbols+Outlined:keyboard_alt:FILL@0;wght@400;GRAD@0;opsz@48&icon.query=keyboard&icon.size=512&icon.color=%23e2b714