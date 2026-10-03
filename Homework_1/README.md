# IRM Lab 1 – Cactus AR (Unity + Vuforia)

An AR experience with two animated cacti placed on two UNO cards (Vuforia image targets).
When the cards get close (under 0.15 m), the cacti switch from Idle to Attack.
When they move apart, the cacti go back to Idle.

Demo video: https://youtu.be/TMpviT1_Iiw

## Requirements
- Unity 6000.3.25f1
- Vuforia Engine 11.4.4 (not included in the repo, download it from developer.vuforia.com)
- A free Vuforia license key

## How to run
1. Clone the repo and open `Homework_1` in Unity.
2. Go to `Window → Vuforia Engine → Vuforia Configuration` and enter your own App License Key (not included in the repo).
3. Open `Assets/Scenes/SampleScene` and press Play (uses the PC webcam).
4. Show the webcam the two card images from `Images/`, printed or on screens. Each card is 6 cm wide.

## How it works
- **Image tracking:** two Image Targets (`uno_1card`, `uno_2card`) from the `Cactus_DB` database. Each cactus is a child of its target.
- **Animator:** `CactusController` has an Idle state (default) and an Attack state, switched by the bool `IsAttacking`.
- **Proximity:** `CactusProximity.cs` measures the distance between the two targets and sets `IsAttacking` when it is below `Attack Distance` (0.15 in the scene). It also shows the distance and state on screen.
- **Asset:** Character Cactus from the Unity Asset Store.

## Author
Andreea Ninicu, group 3E3
