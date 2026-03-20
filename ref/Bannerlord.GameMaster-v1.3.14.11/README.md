# Bannerlord.GameMaster reference assembly (compile-time)

**These binaries are not committed to `main` / feature branches.** Copy them locally to build:

- **Version:** v1.3.14.11  
- **Source:** [GitHub release zip](https://github.com/SolWayward/Bannerlord.GameMaster/releases/download/v1.3.14.11/Bannerlord.GameMaster-v1.3.14.11.zip)  
- **Extract:** `Bannerlord.GameMaster/bin/Win64_Shipping_Client/Bannerlord.GameMaster.dll` and `.xml` into **this folder** next to this README.

**Archived copies** (same paths) live on the **`random_logs`** branch for team reference — not for shipping in application repos.

`AIInfluence.csproj` references `../ref/Bannerlord.GameMaster-v1.3.14.11/Bannerlord.GameMaster.dll` with `<Private>false</Private>` so the **game** still loads BLGM from the player’s **Modules** folder at runtime.
