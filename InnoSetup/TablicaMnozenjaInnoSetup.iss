; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "TablicaMnozenjaProvera"
#define MyAppVersion "1.0"
#define MyAppPublisher "NothingSpecial, Inc."
#define MyAppURL "https://www.youtube.com/watch?v=d63P7SIWTw0"
#define MyAppExeName "TablicaMnozenjaApp.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{D5FD45D7-2835-4681-9D4A-DFB2018A41CC}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=D:\Workspace\TablicaMnozenjaAplikacija\TablicaMnozenjaApp\
OutputBaseFilename=TablicaMnozenjaSetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\Workspace\TablicaMnozenjaAplikacija\TablicaMnozenjaApp\bin\Debug\TablicaMnozenjaApp.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Workspace\TablicaMnozenjaAplikacija\TablicaMnozenjaApp\bin\Debug\TablicaMnozenjaApp.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Workspace\TablicaMnozenjaAplikacija\TablicaMnozenjaApp\bin\Debug\TablicaMnozenjaApp.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Workspace\TablicaMnozenjaAplikacija\TablicaMnozenjaApp\bin\Debug\TablicaMnozenjaApp.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Workspace\TablicaMnozenjaAplikacija\TablicaMnozenjaApp\bin\Debug\Media\*"; DestDir: "{app}\Media"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

