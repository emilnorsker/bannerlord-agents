# Bannerlord.GameMaster reference assembly (compile-time)

- **Version:** v1.3.14.11  
- **Source:** [GitHub release zip](https://github.com/SolWayward/Bannerlord.GameMaster/releases/download/v1.3.14.11/Bannerlord.GameMaster-v1.3.14.11.zip)  
- **Extracted:** `Bannerlord.GameMaster/bin/Win64_Shipping_Client/Bannerlord.GameMaster.dll` (+ `.xml` for IDE docs)

`AIInfluence.csproj` references this DLL with `<Private>false</Private>` so the game still loads the mod’s own copy from the **Modules** folder at runtime; this copy is only for **building** against BLGM’s public API.

To refresh after a new BLGM release, replace the DLL/XML in this folder and update the path / `SubModule.xml` dependency notes if the module id changes.
