# IRM Lab 1 – Cactus AR (Unity + Vuforia)

Experiență de realitate augmentată cu doi cactuși animați, plasați pe
două image targets. Când cele două imagini se apropie (sub 0.25 m),
cactușii trec din animația Idle în Attack; când se depărtează, revin în Idle.

## Versiuni
- Unity 6000.3.25f1
- Vuforia Engine 11.4.4

## Cum se rulează
1. Clonează repo-ul și deschide-l cu Unity 6000.3.25f1.
2. Instalează Vuforia Engine 11.4.4 (developer.vuforia.com → Downloads).
   Pachetul nu este inclus în repo (peste 100 MB).
3. Window → Vuforia Engine → Vuforia Configuration: introdu propriul
   App License Key (cheie gratuită din developer.vuforia.com).
   Cheia nu este inclusă în repo din motive de securitate.
4. Deschide `Assets/Scenes/SampleScene` și apasă Play (se folosește
   webcamul PC-ului).
5. Afișează în fața camerei cele două imagini din folderul `Images/`
   (pe telefon, pe un al doilea ecran sau printate).

## Cum se testează
- O singură imagine vizibilă: cactusul rămâne în Idle.
- Ambele imagini vizibile și apropiate: cactușii trec în Attack.
- Imaginile se depărtează: cactușii revin în Idle.

## Implementare (corespondență cu cerințele)
- **Image tracking (Vuforia):** 2 Image Targets din baza `Cactus_DB`,
  Max Simultaneous Tracked Images = 2. Cactușii sunt copii ai targeturilor.
- **Animator:** controller `CactusController` cu stările Idle (implicită)
  și Attack, parametru bool `IsAttacking`, tranziții fără Exit Time.
- **Proximitate:** `CactusProximity.cs` măsoară distanța dintre cele două
  targeturi și setează `IsAttacking` când distanța este sub prag
  (`Attack Distance`, implicit 0.25).
- **Asset:** Character Cactus din Unity Asset Store.

## Demo

## Autor
Andreea Ninicu, grupa 3E3
