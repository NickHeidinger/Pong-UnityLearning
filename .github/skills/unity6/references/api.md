# Unity 6.3 API Reference

## Input System

### Keyboard
```csharp
using UnityEngine.InputSystem;

// Check if a key is held
Keyboard.current.wKey.isPressed
Keyboard.current.sKey.isPressed
Keyboard.current.upArrowKey.isPressed
Keyboard.current.downArrowKey.isPressed
Keyboard.current.spaceKey.isPressed

// Check if a key was pressed this frame
Keyboard.current.spaceKey.wasPressedThisFrame

// Check if a key was released this frame
Keyboard.current.spaceKey.wasReleasedThisFrame
```

### Mouse
```csharp
Mouse.current.leftButton.isPressed
Mouse.current.rightButton.wasPressedThisFrame
Mouse.current.position.ReadValue()   // Vector2 screen position
Mouse.current.delta.ReadValue()      // Vector2 mouse delta
```

### InputAction (Asset-based)
```csharp
public InputAction moveAction;

void OnEnable() { moveAction.Enable(); }
void OnDisable() { moveAction.Disable(); }

void Update() {
    Vector2 move = moveAction.ReadValue<Vector2>();
}
```

---

## Rigidbody2D

| Property / Method | Notes |
|---|---|
| `rb.linearVelocity` | Replaces `rb.velocity` in Unity 6 |
| `rb.angularVelocity` | Unchanged |
| `rb.MovePosition(Vector2)` | Kinematic movement (use in FixedUpdate) |
| `rb.MoveRotation(float)` | Kinematic rotation |
| `rb.AddForce(Vector2, ForceMode2D)` | Dynamic force |
| `rb.AddTorque(float)` | Rotational force |
| `rb.constraints` | Freeze position/rotation axes |

### Body Types
| Type | Use Case |
|---|---|
| Dynamic | Balls, projectiles — affected by physics |
| Kinematic | Paddles, platforms — moved by script only |
| Static | Walls, ground — never moves |

---

## Transform

```csharp
transform.position           // World position (Vector3)
transform.localPosition      // Local position relative to parent
transform.Translate(x, y, z) // Move relative to current position
transform.rotation           // World rotation (Quaternion)
transform.localScale         // Scale
```

---

## MonoBehaviour Lifecycle

```csharp
void Awake()          // First call; self-initialize, cache components
void OnEnable()       // Called when object becomes active
void Start()          // Called before first Update; cross-object setup
void FixedUpdate()    // Physics timestep (default 0.02s)
void Update()         // Every frame
void LateUpdate()     // After all Updates (good for camera follow)
void OnDisable()      // Called when object deactivated
void OnDestroy()      // Cleanup
```

---

## Physics 2D Callbacks

```csharp
// Collisions (requires non-trigger collider + rigidbody)
void OnCollisionEnter2D(Collision2D col)  { }
void OnCollisionStay2D(Collision2D col)   { }
void OnCollisionExit2D(Collision2D col)   { }

// Triggers (requires isTrigger = true on at least one collider)
void OnTriggerEnter2D(Collider2D other)   { }
void OnTriggerStay2D(Collider2D other)    { }
void OnTriggerExit2D(Collider2D other)    { }
```

---

## Coroutines & Async

### Coroutine
```csharp
StartCoroutine(ExampleRoutine());

IEnumerator ExampleRoutine() {
    yield return null;                      // Wait one frame
    yield return new WaitForSeconds(1f);    // Wait 1 second
    yield return new WaitForFixedUpdate();  // Wait for next FixedUpdate
    yield return new WaitUntil(() => condition); // Wait until condition
}

StopCoroutine(ExampleRoutine());
StopAllCoroutines();
```

### Awaitable (Unity 6 preferred async)
```csharp
async Awaitable ExampleAsync() {
    await Awaitable.WaitForSecondsAsync(1f);
    await Awaitable.NextFrameAsync();
    await Awaitable.FixedUpdateAsync();
}
```

---

## Common Component APIs

### Camera
```csharp
Camera.main                               // Main camera (cached after Unity 2021)
Camera.main.WorldToScreenPoint(Vector3)   // World to screen
Camera.main.ScreenToWorldPoint(Vector3)   // Screen to world
```

### AudioSource
```csharp
audioSource.Play();
audioSource.PlayOneShot(clip);
audioSource.Stop();
```

### Animator
```csharp
animator.SetBool("isRunning", true);
animator.SetFloat("speed", 1.5f);
animator.SetTrigger("jump");
animator.Play("StateName");
```

---

## Scene Management
```csharp
using UnityEngine.SceneManagement;

SceneManager.LoadScene("SceneName");
SceneManager.LoadScene(buildIndex);
SceneManager.LoadSceneAsync("SceneName");
SceneManager.GetActiveScene().name;
```

---

## Instantiate & Destroy
```csharp
GameObject obj = Instantiate(prefab, position, rotation);
Instantiate(prefab, parent.transform);
Destroy(gameObject);
Destroy(gameObject, 2f); // Destroy after 2 seconds
DontDestroyOnLoad(gameObject);
```

---

## Vector Utilities
```csharp
Vector2.Distance(a, b)
Vector2.Lerp(a, b, t)
Vector2.MoveTowards(current, target, maxDelta)
Vector2.Reflect(direction, normal)  // Useful for ball bouncing
Vector3.Normalize(v)
Mathf.Clamp(value, min, max)
Mathf.Lerp(a, b, t)
```
