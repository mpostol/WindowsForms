
rem//  $LastChangedDate: 2013-08-29 13:53:38 +0200 (Thu, 29 Aug 2013) $
rem//  $Rev: 9645 $
rem//  $LastChangedBy: mpostol $
rem//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/PR42-SmartFactory/Scripts/CreateTag.tt $
rem//  $Id: CreateTag.tt 9645 2013-08-29 11:53:38Z mpostol $


set branchtype=tags
set TagFolder=Rel_5_00_02
set TagPath=svn://svnserver.hq.cas.com.pl/VS/%branchtype%/PR36-CAS_MAIN_CORE_PCKG/rel_5_00_02
set trunkPath=svn://svnserver.hq.cas.com.pl/VS/trunk

svn mkdir %TagPath%  -m "created new %TagPath% (in %branchtype% folder)"

svn copy %trunkPath%/PR36-CAS_MAIN_CORE_PCKG %TagPath%/PR36-CAS_MAIN_CORE_PCKG -m "created copy in %TagPath% of the project PR36-CAS_MAIN_CORE_PCKG"
svn copy %trunkPath%/PR39-CommonResources %TagPath%/PR39-CommonResources -m "created copy in %TagPath% of the project PR39-CommonResources"
svn copy %trunkPath%/ImageLibrary %TagPath%/ImageLibrary -m "created copy in %TagPath% of the project ImageLibrary"

pause ....

