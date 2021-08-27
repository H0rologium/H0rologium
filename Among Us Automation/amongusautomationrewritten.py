import pyautogui as pagui
import mouse as m
import keyboard as k
import cv2 as ocv
import numpy as np
import time
import sys
import os
from PIL import Image
import pyscreeze as ps5
roundOver = False
mongus = "1MP0$T3R" #window title
majorIncidentPubba = 'skeld' #why
usetuple = (255,255,255) #RGB of use button
usebtncoords = (1762, 1005) #Coordinates of the use button
taskcoords = [(907, 224), (32, 241)] #The 'task' bar
images = '\\training'
#thats a bit
sussy = """
&&dqmkyc{{ixvv)r*^<;;===!!!!!!!!!==;;>^^*r)vxi{uckhapbd&
dqaezclixv(r*^<;=!!!::::,,,,,,,,,::::!!==;^^*)vxilcwompb
pejyu{x(r^<;;=!::,,,,_______________,,,:::!=;<*r(vi{cwoa
oyu{xvr^>;!!::,,____-----------------____,,::!=;^*)vilcz
cliv)*<=!::,,___------------<{ckkyc{v^_--___,::!=;^r?xiu
{xvr^;!::,___-----------_)ag###########d<---__,,:!=<*rvi
vr*^;!:,,__-----------:kggg##############jr---__,::=;^rv
r*>=!:,,_-------)qg#####dg####@@@@@@@@@##gdz---__,,:!;^r
*>=!:,__-----,cg##@@###jpg####@@@@@@@@@####d_----_,,:!;^
>=!:,__-----c###@@####@&aq&g###############&{-----_,,:!;
;!:,,_----;&##@@@####@@@@@###############g$&#!----__,:!=
!::,__---l##@@@@####@@@@@@@@@@@@@@@#####gg&##q-----__,:!
::,,_--_s##@@@@####@@@@@@@@@@@@@@@@@@@@@@@@@##r-----_,:!
::__---p##@@@@###@@@@@@@@@@@@@@@@@@@@@@@@@@@##&_----__,:
!:,_--u###@@@####@@@@@@@@@@@@@@@@@@@@@@@@@@@@##i----__,:
::,_-,###@@@####@@@@@@@@@@@@@@@@@@@@@@@@@@@@@##&----__,:
!:,_-v####@####@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###!---_,,:
!:,,_*########@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@###c--__,:!
=!:,__j########@@@@@@@@@@#############@@@@@@@@##d-__,:!=
;=::,_-;c####@@@@@@@@####################@@@@@###:_,,:!;
^;!:,,__c#####@@@@@######gggggggggggg############),,:!=^
r^;!:,,;#####@@@@#####ggg$&&&&&dd&&&&$gg#########c,:!;^r
vr*;=!:a#####@@@####gg$&dbqppaaaappqqbd&gg#######p:!=^*(
vrr*<;<######@#####gg&dqpaz*=:::::;*lppb&gg######&=;<*?i
{iv?r*h###########gg&dqamy_---------_vapb&$gg####g^r)?vi
zc{ix(&##########gg&dqaez:.........---lapd&gg#####vvi{lc
ahwc{x###########g$&dpah;............-_kaqd&gg####c{cyom
bqaoyu###########g&&qamc.............--=apb&gg####pwoeab
dbpaeo###########g&dqpa?..............--cpb&gg####&apbbd
$&&dqd#####@#####g$dbqp;..............--;bb&gg####gbdd$$
"""
def doJob(name, centercoords):
    #initialize job-specific variables
    #centercoords is the x,y coordinates returned from determineTaskList's pyscreeze function
    gascanfillemptybuttoncoords = (1500, 1005)#Could use pagui.locateCenter but right now we're fine with coords (faster)
    #strip filename to match method
    shorthand = name.removesuffix('.png')
    if shorthand == 'gascan' or shorthand == 'refuel':
        #Pathing is simple, gascan is always in the storage room and the engines never move
        #Only thing would be 'guessing' which engine first. Possibly get angle of yellow arrow?
        print('Committing to gascan / refuel task!')
        m.move(gascanfillemptybuttoncoords[0], gascanfillemptybuttoncoords[1],True,0)
        m.press()
        time.sleep(4)
        m.release()
        k.send('escape')
        #path to second can location 
    return

def determineTaskList(frame):
    #Set up vars
    rootdir = os.path.join(os.getcwd() + images + '\\' + majorIncidentPubba + '\\')
    #begin checking
    #Check each task and see which one it could be
    files = os.listdir(rootdir)
    print(files)
    time.sleep(0.51)
    for file in files:
        #Pyscreeze is old cheese, piece of broken junk, silly little goose
        val = ps5.locateCenterOnScreen(rootdir + file)
        #Friendship ended with pyscreez, now pyautogui is best friend
        if not val == None:
            print('Found job for' + file)
            doJob(file, val)
            return
        else:
            continue
    k.send('escape')
    return

def crewloop():
    m.move(taskcoords[0][0], taskcoords[0][1], True, 0)
    m.click()
    time.sleep(0.5)
    while roundOver == False:
        frame = pagui.screenshot()#capture screen
        winrender = np.array(frame)#Turn into BGR array
        #Convert to rgb
        smim = Image.fromarray(ocv.cvtColor(winrender, ocv.COLOR_BGR2RGB))
        smim = smim.resize((400,300))
        smim = np.array(smim)
        ocv.imshow(mongus, smim)#Show on external window
        #
        #Try to find the active 'use' button
        #usebtnpresent = pagui.locate('usebtn.png', frame, grayscale=False)
        #Using an absolute position, this location never changes. Using pixel differences to see if ready.
        #Using pixel values is a massive performance boost since we can leave our image object alone
        if frame.getpixel(usebtncoords) == usetuple:#
            print('Found fullwhiteusebtn, clicking...')
            m.move(usebtncoords[0],usebtncoords[1], True, 0.2)
            m.click()
            determineTaskList(winrender)
            time.sleep(0.5)
        #
        if ocv.waitKey(1) == ord("q"):
            break
        if ocv.waitKey(1) == ord("m"):
            print(m.get_position())
    return

def imposterloop():
    time.sleep(0.5)
    print('Not implemented yet!')
    if ocv.waitKey(1) == ord("q"):
        #break
        pass
    if ocv.waitKey(1) == ord("m"):
        print(m.get_position())
    return

def shutdown():
    ocv.destroyAllWindows()
    c = input('Enter 1 to run again or 2 to exit\n')
    if c == '1':
        launch()
    elif c == '2':
        sys.exit()
    return

def launch():
    print(sussy)
    os.chdir(os.getcwd())
    print(os.getcwd())
    print('\n\nPress Q to Quit\nM to record XY as tuple')
    map = input('\nPLEASE IDENTIFY WHICH MAP YOU ARE PLAYING ON WITH \'skeld\', \'mira\', \'polus\' or \'airship\'\n')
    if map == 'skeld':#Will determine pathfinding when implemented
        majorIncidentPubba = 'skeld'
    elif map == 'mira':
        majorIncidentPubba = 'mira'
    elif map == 'polus':
        majorIncidentPubba = 'polus'
    elif map == 'airship':
        majorIncidentPubba = 'airship'
    else:
        print('HEY, you need to enter a proper, all-lowercase map name! This program will not work otherwise')
        launch()
    print('Map being set to ' + majorIncidentPubba + '\nfound from [' + map + ']')
    ocv.namedWindow(mongus, ocv.WINDOW_NORMAL)
    ocv.resizeWindow(mongus, 800, 500)
    #eventually determine if we are imposter or crewmember
    #imposterloop()
    crewloop()
    shutdown()




if __name__=='__main__':
    launch()
