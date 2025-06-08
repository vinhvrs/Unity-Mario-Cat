# Unity Mario Cat

[![Unity](https://img.shields.io/badge/Engine-Unity-1f2326.svg)](https://unity.com/)
[![C#](https://img.shields.io/badge/Language-C%23-239120.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Platformer](https://img.shields.io/badge/Game-Platformer-green.svg)]()
[![License: MIT](https://img.shields.io/badge/License-MIT-lightgrey.svg)](LICENSE)
[![Build Passing](https://img.shields.io/badge/build-passing-brightgreen.svg)]()

---

## 🐾 Overview

**Unity Mario Cat** là một dự án game 2D platformer lấy cảm hứng từ Mario kinh điển, với nhân vật chính là chú mèo dễ thương.
Game xây dựng bằng **Unity Engine**, viết toàn bộ bằng C# cho logic gameplay, hỗ trợ build đa nền tảng (PC/WebGL/Android).

![Mario](https://github.com/user-attachments/assets/1bd0ba85-9fdc-4357-b152-9ffcc9139c46)

---

## 🎮 Gameplay

* Điều khiển mèo nhảy vượt chướng ngại vật
* Ăn coin, power-up để tăng điểm
* Né kẻ địch và bẫy
* Hoàn thành màn chơi với điểm số cao nhất

---

## 🛠️ Features

* Gameplay platformer 2D cổ đi điển
* Animation mèo: idle, walk, jump, die
* Enemy patrol AI, trap logic
* Hệ thống điểm số (score), coin, power-up
* Multi-level support
* UI menu: start, game over, restart
* Âm thanh hiệu ứng & nhạc nền
* Dễ mở rộng, thêm level hoặc enemy

---

## 🏗️ Project Structure

```
Assets/
│
├── Scenes/           # Các màn chơi (level1, mainmenu...)
├── Scripts/          # CatController, Enemy, GameManager, UI, ...
├── Prefabs/          # Cat, Enemy, Coin, Trap
├── Sprites/          # Art assets (png)
├── Audio/            # Nhạc nền, hiệu ứng âm thanh
└── ...
```

---

## 🎮 Controls

| Phím          | Hành động           |
| ------------- | ------------------- |
| ← / →, A / D  | Di chuyển trái/phải |
| Space / W / ↑ | Nhảy                |
| ESC           | Tạm dừng/Mở menu    |

---

## ⚡ How to Run

### 1. Clone project

```bash
git clone https://github.com/vinhvrs/Unity-Mario-Cat.git
```

### 2. Open with Unity Editor

* Dùng Unity phiên bản **2021.x** hoặc mới hơn (khuyên dùng 2021.3 LTS).
* Mở project từ Unity Hub, open folder project.

### 3. Play!

* Chạy **Scenes/MainMenu** hoặc **Scenes/level1** để test.
* Build ra WebGL/Android/Windows theo hướng dẫn của Unity.

---

## 📦 Asset credits

* Sprites: \[OpenGameArt, itch.io] hoặc tự vẽ
* Âm thanh: \[freeSFX, opengameart] hoặc tự tạo
* Xem chi tiết trong folder `Assets/Sprites/` và `Assets/Audio/`

---

## 🚀 How to Contribute

* Fork repo, tạo nhánh mới cho feature/bugfix
* Pull Request kèm mô tả (level, enemy mới, refactor...)
* Đóng góp art, sound, hoặc sửa bug đều welcome!

---

## 📄 License

MIT License © [VinhVRS](https://github.com/vinhvrs)

---

> **Đừng quên Star repo nếu bạn thích, hoặc muốn góp phần xây dựng game!**
