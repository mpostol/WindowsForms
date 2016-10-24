echo off
rem//  $LastChangedDate$
rem//  $Rev$
rem//  $LastChangedBy$
rem//  $URL$
rem//  $Id$


rem DEL [/P] [/F] [/S] [/Q] [/A[[:]attributes]] names
rem   names         Specifies a list of one or more files or directories.
rem                 Wildcards may be used to delete multiple files. If a
rem                 directory is specified, all files within the directory
rem                 will be deleted.
rem 
rem   /P            Prompts for confirmation before deleting each file.
rem   /F            Force deleting of read-only files.
rem   /S            Delete specified files from all subdirectories.
rem   /Q            Quiet mode, do not ask if ok to delete on global wildcard
rem   /A            Selects files to delete based on attributes
rem   attributes    R  Read-only files            S  System files
rem                 H  Hidden files               A  Files ready for archiving
rem                 -  Prefix meaning not
REM RMDIR [/S] [/Q] [drive:]path
REM RD [/S] [/Q] [drive:]path

REM     /S      Removes all directories and files in the specified directory
REM             in addition to the directory itself.  Used to remove a directory
REM             tree.

REM     /Q      Quiet mode, do not ask if ok to remove a directory tree with /S


echo "$URL$"
cd ..\..\

if "%1"=="local" goto LOCAL
del /Q  .\CommonBinaries\PR36-CAS_MAIN_CORE_PCKG\*.*
:LOCAL


RD /S /Q .\PR36-CAS_MAIN_CORE_PCKG\bin 
RD /S /Q .\PR36-CAS_MAIN_CORE_PCKG\Deliverables 
RD /S /Q .\PR36-CAS_MAIN_CORE_PCKG\TestResults
RD /S /Q ".\PR36-CAS_MAIN_CORE_PCKG\BK.CodeProtect\bin"
RD /S /Q ".\PR36-CAS_MAIN_CORE_PCKG\BK.CodeProtect\obj"
RD /S /Q ".\PR36-CAS_MAIN_CORE_PCKG\CommonBus\bin"
RD /S /Q ".\PR36-CAS_MAIN_CORE_PCKG\CommonBus\obj"
RD /S /Q ".\PR36-CAS_MAIN_CORE_PCKG\PR36-CAS_MAIN_CORE_PCKG\obj"
RD /S /Q ".\PR36-CAS_MAIN_CORE_PCKG\PR36-CAS_MAIN_CORE_PCKG\bin"
RD /S /Q ".\PR36-CAS_MAIN_CORE_PCKG\RTLibComm\bin"
RD /S /Q ".\PR36-CAS_MAIN_CORE_PCKG\RTLibComm\obj"
RD /S /Q ".\PR36-CAS_MAIN_CORE_PCKG\RTLibComm.UT\bin"
RD /S /Q ".\PR36-CAS_MAIN_CORE_PCKG\RTLibComm.UT\obj"
RD /S /Q .\PR36-CAS_MAIN_CORE_PCKG\Scripts\bin 
RD /S /Q .\PR36-CAS_MAIN_CORE_PCKG\Scripts\obj 
rem deleting project user files
del /F /S /Q /A:H .\PR36-CAS_MAIN_CORE_PCKG\*.suo
del /F /S /Q /A:H .\PR36-CAS_MAIN_CORE_PCKG\*.user
rem deleting objects
del /F /S /Q  .\PR36-CAS_MAIN_CORE_PCKG\*.obj
rem deleting intellisence
del /F /S /Q  .\PR36-CAS_MAIN_CORE_PCKG\*.ncb
rem deleting debuger informations
del /F /S /Q  .\PR36-CAS_MAIN_CORE_PCKG\*.pdb
rem deletind desktop.ini
del /F /S /Q /A:H .\PR36-CAS_MAIN_CORE_PCKG\*.ini

rem returning to base directory
cd .\PR36-CAS_MAIN_CORE_PCKG\Scripts