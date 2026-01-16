# Contributing Guidelines

## Purpose
This repository produces a Windows Forms application that targets .NET Framework 4.7.2. All releases must include an installer that packages the application binaries and the fixed `drawings` folder used by the app at runtime.

## Requirements
- Installer artifact must include the `drawings` folder and any default drawing files that ship with the app.
- The installer must either install or ensure the presence of **.NET Framework 4.7.2** on target machines. Provide a bootstrapper or clear instructions for users to install the framework.
- By default the installer should place application files under `Program Files\<ProductName>` and create the `drawings` folder alongside the executable. The application already falls back to the user's Documents folder if it cannot create the `drawings` folder in the installation directory; the installer should attempt to create it to provide the expected experience.
- Provide both an MSI (or EXE) installer suitable for end users and pipeline artifacts for CI (MSI/EXE/zip).

## Supported packaging tools (recommended)
- Visual Studio Installer Projects (easy, GUI-driven)
- WiX Toolset (recommended for CI and advanced control)
- Inno Setup / NSIS (lightweight, script-driven)

## Visual Studio Installer Projects — Quick recipe
1. Install the extension: __Extensions > Manage Extensions__ ? search "Microsoft Visual Studio Installer Projects" and install.
2. In the solution: right?click the solution ? __Add > New Project...__ ? choose __Setup Project__ (under Other Project Types > Setup and Deployment).
3. In the Setup project: right?click __Application Folder__ ? __Add > Project Output...__ ? select the application project and choose __Primary output__ and __Content Files__.
4. Still under __Application Folder__: right?click ? __Add > Folder__, name it `drawings`. Right?click `drawings` ? __Add > File...__ and add any default drawing files you want shipped.
5. In the Setup project properties: set __Manufacturer__ and __ProductName__ and configure the installation folder.
6. Configure prerequisites: right?click the Setup project ? __Properties__ ? __Prerequisites...__ and select **.NET Framework 4.7.2** to include the bootstrapper (or provide online installer option).
7. Build the Setup project — output will be an MSI (and possibly a setup.exe if bootstrapper chosen).

## WiX Toolset — Quick recipe (recommended for CI)
1. Install WiX Toolset and the VS extension.
2. Create a WiX project and author a `Bundle` (Bootstrapper) that checks for and installs .NET Framework 4.7.2.
3. In the WiX `Product` element, include files from your build output and a `Directory` for the `drawings` folder with the files to be packaged.
4. Build to create MSI and EXE bundles. WiX allows automation inside build pipelines.

## Inno Setup — Quick recipe
1. Create an Inno Setup script that copies the application output and adds a `drawings` folder under {app}.
2. Provide a check for .NET 4.7.2 and either abort with message or run the offline installer.

## CI / Release notes
- CI pipelines should build the project, collect primary output, and run the installer project build to generate installer artifacts.
- Publish MSI/EXE as release assets.

## Testing the installer
1. Install on a clean VM with no developer tools and verify:
   - The app installs into the chosen folder.
   - The `drawings` folder exists alongside the executable and contains any shipped defaults.
   - Running the app can open/save drawings and create the `drawings` folder if it is missing (the app already falls back to Documents if creation fails).
2. Test scenarios: missing .NET, different user permission levels (standard user), and uninstall/repair.

## Notes for developers
- If your app needs to write into the installation folder at runtime, prefer installing per-user files under `%LOCALAPPDATA%` or use the `drawings` folder in the user's Documents folder to avoid requiring admin privileges at runtime.
- If the codebase changes the expected location for `drawings`, update these guidelines accordingly.

## Contact
For packaging issues, open an issue named "installer: <short description>" and assign to the maintainer team.