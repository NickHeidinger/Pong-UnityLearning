---
name: unity6
description: 'Unity 6.3 API, scripting, and best practices skill. Use when writing Unity C# scripts, fixing Unity errors, working with GameObjects, components, physics, input, coroutines, lifecycle methods, Rigidbody, Camera, UI, scenes, prefabs, or any Unity engine feature. Also use when migrating from legacy Unity APIs (e.g. old Input Manager to Input System, rb.velocity to rb.linearVelocity).'
argument-hint: 'Describe the Unity feature or problem (e.g. "player movement with new Input System")'
---

# Unity 6.3 Scripting Skill

## When to Use
- Writing or fixing Unity C# MonoBehaviour scripts
- Working with Unity components (Rigidbody2D, Collider, Camera, etc.)
- Handling input using the **new Input System** package
- Scene, prefab, and GameObject management
- Physics, animation, audio, UI (uGUI / UI Toolkit)
- Coroutines, async/await in Unity context
- Migrating deprecated or legacy Unity APIs to Unity 6.3 equivalents

---

## Key Unity 6.3 API Changes & Best Practices

See [Unity 6 API Reference](./references/api.md) for detailed breakdowns.

> Official Documentation: [Unity 6.3 Manual](https://docs.unity3d.com/6000.3/Documentation/Manual/) | [Unity 6.3 Scripting API](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/)

### Input System (New vs Legacy)
- Unity 6 projects default to the **Input System package** (`UnityEngine.InputSystem`)
- **Never** use `UnityEngine.Input.GetKey()` — it throws at runtime if Input System is active
- Use `Keyboard.current.wKey.isPressed` or an `InputAction` asset instead

### Rigidbody2D Velocity
- `rb.velocity` is **deprecated** in Unity 6 — use `rb.linearVelocity`
- For angular: use `rb.angularVelocity` (unchanged)

### Physics
- Prefer `Rigidbody2D.MovePosition()` for kinematic movement over `Transform.Translate` when a Rigidbody2D is present
- Use `Physics2D.Simulate()` for manual physics stepping

### Lifecycle Order
```
Awake → OnEnable → Start → FixedUpdate → Update → LateUpdate → OnDisable → OnDestroy
```
- Use `Awake` for self-initialization (caching components)
- Use `Start` for cross-object initialization (referencing other components)
- Use `FixedUpdate` for physics (runs at fixed timestep)

### Component Caching
Always cache component references in `Awake`, never in `Update`:
```csharp
private Rigidbody2D rb;
void Awake() { rb = GetComponent<Rigidbody2D>(); }
```

### Null Safety
- Use `TryGetComponent<T>()` instead of `GetComponent<T>()` where the component may be absent
- Avoid `GameObject.Find()` in `Update` — cache in `Awake`/`Start`

### Coroutines
```csharp
StartCoroutine(MyRoutine());
IEnumerator MyRoutine() {
    yield return new WaitForSeconds(1f);
    // ...
}
```
- For async tasks, `Awaitable` (Unity 6) is preferred over `Task` for Unity thread safety

---

## Step-by-Step Procedures

### Adding Movement to a GameObject (New Input System)
1. Add `using UnityEngine.InputSystem;` at the top of the script
2. Read input via `Keyboard.current.<key>.isPressed` or bind an `InputAction`
3. Apply movement in `Update` using `transform.Translate` (no Rigidbody) or in `FixedUpdate` via `rb.linearVelocity` / `rb.MovePosition` (with Rigidbody2D)

### Setting Up Rigidbody2D for a Paddle
- Body Type: **Kinematic** (player-controlled, not gravity-affected)
- Move using `rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime)` in `FixedUpdate`

### Setting Up Rigidbody2D for a Ball
- Body Type: **Dynamic**
- Set initial velocity in `Start` with `rb.linearVelocity = new Vector2(x, y)`
- Add a **Physics Material 2D** with `Bounciness = 1` and `Friction = 0` for perfect bouncing

### Detecting Collisions
```csharp
void OnCollisionEnter2D(Collision2D col) { }   // Rigidbody2D with Collider2D
void OnTriggerEnter2D(Collider2D other) { }    // Trigger collider
```

---

## Common Mistakes to Avoid
| Mistake | Fix |
|---|---|
| `rb.velocity` | Use `rb.linearVelocity` in Unity 6 |
| `Input.GetKey()` with New Input System | Use `Keyboard.current.xKey.isPressed` |
| Moving Rigidbody via `Transform.Translate` | Use `rb.MovePosition()` in `FixedUpdate` |
| `GetComponent` in `Update` | Cache in `Awake` |
| `GameObject.Find` in `Update` | Cache reference in `Awake`/`Start` |
| `new WaitForSeconds` allocated each frame | Cache `WaitForSeconds` as a field |
