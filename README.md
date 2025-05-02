# Basic BepInEx Cuphead modding template

## How to start
1. Download BepInEx: https://github.com/BepInEx/BepInEx/releases  
2. How to install BepInEx: https://docs.bepinex.dev/articles/user_guide/installation/index.html#installing-bepinex  
3. Install BlenderAPI: https://gamebanana.com/mods/532236
4. Install Visual Studio 2022 (not Visual Studio Code): https://visualstudio.microsoft.com/vs/  
5. Install .NET Sdk v7.0: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.410-windows-x64-installer  
6. Download this modding template using "git clone https://github.com/UserNotFoundXEption/CupheadModdingTemplate" in cmd console or pasting the link in VS2022.  
7. Download original Cuphead code using "git clone https://github.com/UserNotFoundXEption/OriginalCupheadCode" in cmd console or pasting the link in VS2022.  
8. Open both projects with VS2022.
9. If anything is underlined red in modding template, look for references in the right panel, right click them, "add packages" and add everything from "AddTheseToReferences" folder
10. Modding template has some instructions and basic code inside. Have fun and mod something.  
11. Press Ctrl + B to build project.
12. Copy "CupheadModdingTemplate/bin/debug/net35/CupheadModdingTemplate.dll" to "Cuphead directory/BepInEx/plugins"
13. Launch the game and see if it works.

## Additional stuff
- Open "Cuphead directory/BepInEx/config/BepInEx.cfg", look for "[Logging.Console]" and set "Enabled" to "true". Now you'll see a logs after launching your game.
- Install UnityExplorer. It's very useful when trying to understand the game: https://github.com/sinai-dev/UnityExplorer/releases
- Keep in mind that installing multiple mods at the same time can break things. 
- Join BlenderAPI Discord server: https://discord.gg/fejJWHtK
- Use newest version of Cuphead (no beta / legacy versions)