import os, datetime
from shutil import copyfile

Path = os.path.join("DayZVersionToggle","bin","Release")
Build = 0

def doChangeLog():
        changes = open("CurrentChangelog.txt").read()
        outFile = open("Changelog.txt").read()
        open("Changelog.txt", "w+").write("%s\n%s\n%s\n%s\n%s" % ("#" * 200, 
        	str(datetime.datetime.now().date()) + " - Build %d" % Build, "#" * 200, changes, outFile))
        open("CurrentChangelog.txt", "w").write("")

def includeDoc():
	copyfile("Changelog.txt", os.path.join(Path, "Changelog.txt"))
	copyfile("README.md", os.path.join(Path, "README.md"))

def createArchive():
	os.popen("cd \"%s\" & 7z.exe a VersionLatest.zip *" % Path)

def doCopies():
	copyfile(os.path.join(Path, "VersionLatest.zip"), os.path.join("Versions", "VersionLatest.zip"))
	copyfile(os.path.join(Path, "VersionLatest.zip"), os.path.join("Versions", "Version %d.zip" % Build))

Build = int(open("Versions\\CurrentBuild.txt").read())
doChangeLog()
includeDoc()
createArchive()
doCopies()
Build += 1
open("Versions\\CurrentBuild.txt", "w+").write(str(Build))
