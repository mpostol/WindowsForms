
rem//  $LastChangedDate$
rem//  $Rev$
rem//  $LastChangedBy$
rem//  $URL$
rem//  $Id$

set buildtype=%1
if "%buildtype%"=="" goto setbuildtype

:dothejob
"%Windir%\Microsoft.NET\Framework\v3.5\msbuild"  ..\PR36-CAS_MAIN_CORE_PCKG.sln /t:build /p:Configuration=%buildtype%
goto exit

:setbuildtype
set buildtype=Release
goto dothejob

:exit