# Unity Sandbox

A small 2D platformer built in Unity 6, developed as a hands-on learning project to
bridge embedded/C++ software development experience into Unity and C# game
development. Move, jump, stomp enemies, collect coins, and reach the goal — built
from scratch across a full engine learning arc (Editor basics → physics/input →
a complete shipped game).

---

## Overview

- **Genre:** 2D platformer
- **Engine:** Unity 6.4 (Universal Render Pipeline, 2D)
- **Platform:** Windows (standalone `.exe`)
- **Development period:** Summer learning project
- **Status:** Feature-complete vertical slice — title screen, one full level,
  patrol enemies, scoring, pause, win/lose flow, audio, and polish, built and
  tested as a standalone executable.

---

## Features

- **Movement & physics** — Rigidbody2D-driven horizontal movement and jumping,
  with grounded detection via `Physics2D.OverlapCircle`.
- **Enemies** — patrolling enemies with raycast-based wall and ledge detection
  (reverse direction at walls or platform edges). Stomp from above to defeat an
  enemy (with a bounce and screen shake); touch from the side and you die.
- **Coins** — trigger-based pickups that add to a running score, with a particle
  burst and desynced spin animation per coin.
- **Full UI flow** — title screen with Start button, in-game HUD (live score),
  a pause menu (Esc, gated so it can't be opened once the game has ended), and a
  Game Over / You Win end screen with Restart and Main Menu options.
- **Audio** — jump and coin pickup sound effects, persistent looping background
  music that survives scene reloads without restarting or duplicating.
- **Polish** — hit-flash on taking damage, camera screen shake on impactful
  moments, particle effects, and sprite animations (including an animated
  enemy collider synced to its walk-cycle hop).
- **Camera** — smoothed follow camera (`SmoothDamp`) with manual world-bounds
  clamping (accounting for orthographic size and aspect ratio, not raw pixels),
  plus a Pixel Perfect Camera setup for crisp, seam-free pixel art rendering.

---

## Controls

| Action | Binding |
|---|---|
| Move | WASD or Arrow Keys |
| Jump | Space |
| Pause | Esc |
| UI navigation | Mouse |

Input is handled via Unity's Input System package (action maps, not the legacy
`Input.GetKey` API).

---

## Project structure

```
Assets/
  Scripts/
    Camera/
      CameraFollow.cs       — smoothed follow + world-bounds clamping + shake offset
      ScreenShake.cs        — coroutine-driven temporary camera jitter
    Gameplay/
      PlayerMovement.cs     — Input System-driven movement, jump, grounded check
      EnemyPatrol.cs        — raycast wall/edge detection, direction flip
      EnemyContact.cs       — stomp-vs-side-touch detection, enemy defeat / player death
      EnemyAnimationOffset.cs
      Coin.cs               — trigger pickup, score, SFX, particle burst
      CoinAnimationOffset.cs
      GameManager.cs        — score singleton
      KillZone.cs           — fall-based death trigger
      Finish.cs             — level goal trigger
      HitFlash.cs           — temporary color flash on damage (uses unscaled time)
      Blinker.cs            — early coroutine exercise (color toggle over time)
      Mover.cs               — early Time.deltaTime exercise
    UI/
      EndScreen/
        EndScreenManager.cs — Game Over / Win screen singleton, restart/menu routing
      PauseMenu/
        PauseManager.cs     — Esc toggle, Time.timeScale gating, input gating
      TitleScreen/
        TitleScreenManager.cs — Start button → scene load
    Logger.cs                — early MonoBehaviour lifecycle exercise
    MusicManager.cs          — persistent looping music (DontDestroyOnLoad singleton)
```

`Scripts/Camera`, `Scripts/Gameplay`, and `Scripts/UI` separate concerns by
system; a handful of early exercise scripts (`Logger.cs`, `Mover.cs`,
`Blinker.cs`) remain in the project as a record of the learning process rather
than because they're used by the shipped game.

---

## Building the project

1. Open the project in Unity 6.4 (or later) via Unity Hub.
2. Confirm `File → Build Settings` lists the `TitleScreen` scene at index 0 and
   the gameplay scene below it.
3. Confirm the platform is set to **Windows**.
4. Click **Build**, choose an output folder (outside `Assets/`), and wait for
   the build to complete.
5. Run the produced `.exe` directly — no Unity installation required to play.

---

## Tech notes / things worth knowing if you open this project

- **Input** is handled via the Input System package's generated `PlayerControls`
  C# class, not the legacy `Input` class.
- **Tilemap collision** uses a `Composite Collider 2D` (merged tile edges) to
  avoid corner-catching on flat runs of tiles, and a zero-friction
  `Physics Material 2D` on the player to prevent wall-sticking.
- **Pause** freezes gameplay via `Time.timeScale = 0`, and separately disables
  the player's Input System action map — these are independent systems, and
  both need to be gated, since raw input events aren't affected by `timeScale`.
- **Time-based effects that must survive a freeze** (hit-flash, screen shake)
  use `WaitForSecondsRealtime` / `Time.unscaledDeltaTime` rather than the
  scaled-time equivalents, so they still complete correctly even when
  `Time.timeScale` drops to 0 (e.g., right as the end screen appears).
- **Persistent singletons** (`GameManager`, `EndScreenManager`, `MusicManager`)
  use the standard `Instance` + `Awake()` guard-clause pattern; `MusicManager`
  additionally uses `DontDestroyOnLoad` so music survives scene reloads.
- **Camera bounds** are computed from `Camera.orthographicSize` and `aspect`,
  not screen pixel dimensions — pixel dimensions are screen-space, not
  world-space, and don't correspond to how much world the camera shows.

---

## Assets & Credits

### Sound effects
- [Impact Sounds](https://kenney.nl/assets/impact-sounds) — Kenney
- [Interface Sounds](https://kenney.nl/assets/interface-sounds) — Kenney
- [Sci-fi Sounds](https://kenney.nl/assets/sci-fi-sounds) — Kenney

### Sprites
- [Pixel Platformer](https://kenney.nl/assets/pixel-platformer) — Kenney

### Music
- "Air Shifter" — [Jens Vide](https://jens-vide.itch.io/air-shifter)

---

## What's next

This project (Phases 0–4 of a broader Unity learning plan) is complete. The
next phase moves into 3D fundamentals — a separate project focused on 3D
movement, physics, interaction systems, and basic AI navigation, building
toward a small explorable/interactive 3D world. See `unity_3d_learning_plan.md`
in the accompanying project documentation.