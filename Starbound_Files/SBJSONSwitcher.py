jsondumper = "E:\\Steam\\steamapps\\common\\Starbound\\win32\\dump_versioned_json.exe"
jsonpacker = "E:\\Steam\\steamapps\\common\\Starbound\\win32\\make_versioned_json.exe"
tempPath = " C:\\users\\horo\\AppData\\Local\\Temp\\"
playerFolder = " E:\\Steam\\steamapps\\common\\Starbound\\storage\\player\\"
# Yeah i know but honestly i could care less that you know what my user folder is named
import os
import subprocess as sus
def main():
    for files in os.listdir(playerFolder.strip()):
        if not ".bak" in files:
            f = os.path.join(playerFolder, files)
            sus.call(jsondumper + f + tempPath + os.path.join(files + ".json"))

input('done?')



if __name__=='__main__':
    main()