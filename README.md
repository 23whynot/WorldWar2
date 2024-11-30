# World War 2

**World War 2** is a mobile arcade game developed in Unity for Android devices. Immerse yourself in the atmosphere of World War II with engaging gameplay, an adaptive interface, and a convenient save system.

## Features

- **Android Support**: Optimized for Android devices.
- **Tilemaps**: Utilizes the tilemap system for flexible and optimized level design.
- **Score Saving**: Game progress is saved in a JSON file to keep your score.
- **Adaptive UI**: The interface automatically adjusts to screens of all sizes and resolutions.
- **Sound Effects**: Realistic sound effects and music.
- **Main Menu**: Convenient menu for navigation and settings selection.
- **Settings Menu**: Adjust volume, graphics quality, and other preferences.
- **Flexible Controls**: Controls adapted for touch screens.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/23whynot/WorldWar2.git
    ```
2. Open the project in Unity:
    - Ensure you have a Unity version that supports Android builds.
    - Add the project to your workspace using Unity Hub.
3. Configure build settings:
    - Go to **File > Build Settings**.
    - Select **Android** as the platform.
    - Click **Switch Platform** to switch to Android.
4. Connect Android SDK and configure settings:
    - Ensure Unity is set up for Android builds (including SDK, NDK, and JDK).
    - You can install them via Unity Hub under **Preferences > External Tools**.
5. Build the APK:
    - In **Build Settings**, click **Build**, and choose a directory to save the APK file.
    - Install the APK on your device via USB or upload it to cloud storage.

## Controls

- **Touch Controls**:
  - Tap the screen to shoot.
  - Use a virtual joystick or arrows for movement.

## Project Structure

### Folders inside `Assets/`

- **Audio/** — Sound effects and music files used in the game.
- **Character/** — Character data such as models, animations, and settings.
- **Plugins/** — Additional libraries and plugins to extend Unity's capabilities.
- **Prefabs/** — Prefabricated objects like characters, enemies, and environment elements.
- **Resources/** — Assets dynamically loaded during gameplay.
- **Scenes/** — Game scenes, including the main menu, settings, and levels.
- **Script/** — C# scripts implementing the game logic.
- **Settings/** — Configuration files for game settings.
- **Sprite/** — Images and sprites for visual elements.
- **TextMesh Pro/** — Files for working with TextMesh Pro, used for creating high-quality text.

---

### Files inside `Assets/`

- **`*.meta` files** — Unity's system files required for project operation.

---

## Build for Google Play (Optional)

1. Configure Keystore for APK signing:
    - Go to **Player Settings > Publishing Settings**.
    - Provide the Keystore file and password for signing the app.
2. Prepare the release:
    - Set the app version (Bundle Version Code and Version Name).
    - Enable **ARMv7** and **ARM64** in architecture settings.
3. Build AAB (Android App Bundle) for Google Play upload:
    - In **Build Settings**, select the **Build App Bundle** format.
4. Test the APK/AAB on your device.

## License

The game is distributed under the [MIT](LICENSE) license.

## Acknowledgments

Special thanks to all the developers and the Unity community for their support.

## Repository Link

The source code is available on [GitHub](https://github.com/23whynot/WorldWar2).

---

Enjoy the game! 🎮