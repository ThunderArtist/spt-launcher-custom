## A Fork of [SP-Tushonka Launcher](https://github.com/SP-Tushonka/launcher) with Linux improvements *(in my opinion)*

This launcher is exactly the same as the official one, with all its differences listed below.

### What this launcher does differently:
- Lets you set the **Wine Prefix** path to an **empty folder**!
- Lets you copy a profile's ID and even the **launch arguments** - if you wish to launch SP-Tushonka with **another launcher** (for example Lutris/Heroic/Steam).
- Checks for Protons downloaded through Lutris and Heroic Games Launcher - the official launcher only checks 2 Steam directories which is why you may not be seeing some of your Protons.

**Works on SP-Tushonka 4.1.X**

**You don't need to copy this into the game folder. It can work standalone.**

*You can click `"This branch is [amount] commits ahead of/behind SP-Tushonka/launcher:master"` above this to see my changes/commits.*

Link to this fork's [source code](https://github.com/ThunderArtist/spt-launcher-custom).


## Launcher

Custom launcher for Escape From Tarkov to start the game in offline mode

**Project**        | **Function**
------------------ | --------------------------------------------
SPTushonka.Core      | Core functionality of the launcher
SPTushonka.Launcher  | Primarily the UI part of the launcher

## Privacy
SPT is an open source project. Your commit credentials as author of a commit will be visible by anyone. Please make sure you understand this before submitting a PR.
Feel free to use a "fake" username and email on your commits by using the following commands:
```bash
git config --local user.name "USERNAME"
git config --local user.email "USERNAME@SOMETHING.com"
```

## Requirements

- Escape From Tarkov *****
- .NET 10 SDK
- Visual Studio or Jetbrains Rider (I use VSCodium)
- webkit2gtk-4.1 dependency for linux users (might be called something slightly different depending on distro :cringe:)
- WebView2 dependency for windows users, this should be on windows by default

## Build
- Open your terminal at `RepositoryFolder`
- use this command `dotnet publish "./SPTushonka.Launcher/SPTushonka.Launcher.csproj" -c Release --self-contained false --framework net10.0 --runtime {REPLACE ME WITH RUNTIME} -p:PublishSingleFile=true -p:SptVersion={REPLACE ME WITH SERVER VERSION}`
- Two parts need changing to publish
- - `--runtime` is either `win-x64 or linux-x64`
- - `SptVersion` is the servers version number. for example `4.1.0` = `-p:SptVersion=4.1.0`
- this will create a build folder at the repository root

## Code Style

We use [CSharpier](https://csharpier.com/) to keep the project's code styled/formatted. It is pinned as a local tool, so no global install is required. Restore it once with:

```bash
dotnet tool restore
```

You may then apply the formatting rules by running the following from the repository root:

```bash
dotnet csharpier format .
```

Please ensure this is run before your PR is created to make merges easier. The `Format` workflow will fail a PR if formatting changes are required.

### Format On Save

There are plugins for both [VS](https://marketplace.visualstudio.com/items?itemName=csharpier.csharpier-vscode) and [Rider](https://plugins.jetbrains.com/plugin/18243-csharpier) which allow you to automatically format project code when a file is saved.