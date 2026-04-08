# 🧮 Math Game

![CI Status](https://github.com/Rriarys/MathGame/actions/workflows/ci.yml/badge.svg)

A professional console-based mathematical game built with **C#** and **.NET 10**, featuring automated CI/CD pipelines and robust unit testing.

---

### 🚀 FEATURES

* **Four Operations:** Addition, Subtraction, Multiplication, and Division.
* **Smart Division:** Guarantees clean integer results with no remainders.
* **Difficulty Levels:** Dynamic range limits for Easy, Medium, and Hard modes.
* **Time Tracking:** Built-in timer to track how long it takes to solve each session.
* **History Tracking:** Session-based recording of games and scores.
* **Score System:** Earn points for every correct answer.

---

### 🧪 TESTING & QUALITY

This project implements professional software quality standards:
* **Unit Testing:** 25+ automated tests using **xUnit** covering core math logic and factory generation.
* **CI/CD:** Automated workflows via GitHub Actions for testing on every push and generating cross-platform builds.

To run tests locally:
```bash
dotnet test
```



---

### 🛠️ TECHNOLOGIES

| Technology | Description |
| :--- | :--- |
| **Language** | C# |
| **Framework** | .NET 10 |
| **Type** | Console Application |
| **Testing** | xUnit |
| **CI/CD** | GitHub Actions |

---

### 📋 REQUIREMENTS

> [!NOTE]
> * The game consists of at least **5 questions** per session.
> * Previous games are recorded in a `List`.
> * Results are deleted once the program is closed.

---

### 💻 HOW TO RUN

1.  **Clone** the repository:
    ```bash
    git clone https://github.com/Rriarys/MathGame.git
    ```
2.  **Navigate** to the project folder:
    ```bash
    cd MathGame/MathGame
    ```
3.  **Run**:
    ```bash
    dotnet run
    ```

---

### 📦 DOWNLOAD EXECUTABLES

Ready-to-run binaries for **Windows** and **Linux** are available in the [**Releases**](https://github.com/Rriarys/MathGame/releases) section. These are self-contained and do not require a pre-installed .NET runtime.

**Also available on itch.io:** 🚀 [**rriarys.itch.io/mathgame**](https://rriarys.itch.io/mathgame)


