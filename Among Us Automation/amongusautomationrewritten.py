import pyautogui as pagui
import mouse as m
import keyboard as k
import cv2 as ocv
import numpy as np
import time
import sys
import os
from PIL import Image
from PIL import ImageGrab
import pyscreeze as ps5
roundOver = False
mongus = "1MP0$T3R" #window title
majorIncidentPubba = 'skeld' #why
usetuple = (255,255,255) #RGB of use button
#note that these coordinates are based on running the game at 1920 x 1200 resolution.
usebtncoords = (1762, 1005) #Coordinates of the use button
reportbtncoords = (1735, 838) #Report button coords
taskcoords = [(907, 224), (32, 241)] #The 'task' bar
images = '\\training'
DESTINATIONCOORDS = (960, 572)#Center of screen
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
def doJob(name, centercoords, mapdir):
    rootdir = os.path.join(os.getcwd() + images + '\\' + majorIncidentPubba + 'jobs\\')
    #initialize job-specific variables
    #note that these coordinates are based on running the game at 1920 x 1200 resolution.
    #centercoords is the x,y coordinates returned from determineTaskList's pyscreeze function
    gascanfillemptybuttoncoords = (1500, 1005)#Could use pagui.locateCenter but right now we're fine with coords (faster)
    asteroidscreenupcheckcoords = (546, 1001)#Makes sure the asteroid task window is still open
    ASTEROIDS_REGION = (501, 200, 890, 889)#Bounding region for asteroid window, x,y,width,height
    ELECTRICAL_RED_PULLSWITCH_COLOR = (255, 98, 0)
    #Left to right
    ELECTRICAL_RED_PULLSWITCH_LOCATIONS = [(583, 870),(688, 872),(798, 872),(905, 870),(1011, 874),(1118, 875),(1224, 875),(1335, 874)]


    #strip filename to match method
    shorthand = name.removesuffix('.png')
    #Determine and run job
    if shorthand == 'gascan' or shorthand == 'refuel':
        #Pathing is simple, gascan is always in the storage room and the engines never move
        #Only thing would be 'guessing' which engine first. Possibly get angle of yellow arrow?
        print('Committing to gascan / refuel task!')
        m.move(gascanfillemptybuttoncoords[0], gascanfillemptybuttoncoords[1],True,0)
        m.press()
        time.sleep(4)
        m.release()
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'downloadbtn' or shorthand == 'uploadbtn':
        #Simply clicking the button then waiting 8 seconds.
        print('Committing to upload / download task!')
        m.move(centercoords[0], centercoords[1])
        m.click()
        time.sleep(8)
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == '1to10':
        #Finding 1 through ten and clicking them in order
        #We need to get the mouse out of the way to make sure that its not highlighting anything
        print('Committing to the sequence task')
        m.move(centercoords[0],centercoords[1])#The image we have for this task will center the mouse on the top bar, away from the buttons
        sequence = []#sigma male
        for i in range(10):
            #Identify the current number location then save the coordinates
            val = ps5.locateCenterOnScreen(rootdir + str(i+1) + '.png', confidence=0.9)
            print(str(val))
            if not val == None:
                print('Found element ' + str(i) + ' at location ' + str(val) + '.')
                #The array is already ordered, no sorting needs to be done. This is essentially guaranteed unless filenames get changed in \traininig\
                sequence.append((val[0], val[1]))
        for button in sequence:#This array/loop structure is moreso here to animate the mouse on this task and make it look cooler
            #You could easily just move and click inside of the original loop if you don't want to be fancy.
            #Button is a tuple of (i, (x,y))
            m.move(button[0],button[1],True,0.2)
            m.click()
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'adminswipecard':
        #Swiping the card in admin is actually pretty easy
        print('Committing to swiping the card in admin')
        val = ps5.locateCenterOnScreen(rootdir + 'pocketedcard.png')
        print(str(val))
        if not val == None:
            m.move(val[0],val[1])
            m.press()
            m.move(0, -500, False, 0.7)
            m.release()
            time.sleep(0.7)
        else:
            print('What? cannot find the card?')
        val2 = ps5.locateCenterOnScreen(rootdir + 'id.png')
        print(str(val2))
        if not val2 == None:
            m.move(val2[0]-100, val2[1]-180)
            m.drag(val2[0]-100, val2[1]-180, 1000, 0, False, 0.3)
        else:
            print('Sorry, can\'t find the id picture for some reason?')
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'centercrosshairs':
        #Moving the crosshairs into the center of the screen
        print('Committing to moving the crosshairs to the middle!')
        print('TODO: Add crosshairmove functionality')
        centercoords = ps5.locateCenterOnScreen(rootdir + 'centercrosshairs.png', grayscale=True, confidence=0.7)
        m.move(centercoords[0],centercoords[1],True,0.4)
        m.drag(centercoords[0],centercoords[1],DESTINATIONCOORDS[0],DESTINATIONCOORDS[1],True,0.6)
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == '1_crosshairs':
        #My nemesis, those dang assteroids
        print('Committing to shooting asteroids')
        #Detect motion is probably the best method for this
        #Nah we're looking for colors again
        while True:
            target = pagui.locateOnScreen(rootdir + 'asteroid.png', region=ASTEROIDS_REGION, confidence=0.8)
            if not target == None:
                m.move(target[0], target[1]-5,0.1)
                m.click()
            #pixelMatchesColor is not working in python 3.9
            val = pagui.locateOnScreen(mapdir + '1_crosshairs.png', grayscale=True, confidence=0.8)
            if val == None:
                print('Asteroid task complete')
                break
        k.send('escape')
        count = 0
        time.sleep(1.7)
        return
    if shorthand == 'electricalslidingbars':
        #Slide the red-highlighted slider vertically up
        print('Committing to the red slider task')
        for switch in ELECTRICAL_RED_PULLSWITCH_LOCATIONS:
            m.move(switch[0]-30,switch[1],True,0.3)
            spot = m.get_position()
            pix = ImageGrab.grab().load()[spot[0], spot[1]]
            if pix[0] >= 200:
                m.press()
                m.move(0,-600,False,0.2)
                m.release()
                break
        
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'enginealignment':
        #Aligning the engine outline to match the middle line
        #Could check to see when green, green only appears near the middle when lined up.
        print('Comitting to enginealignment')
        print('TODO: Add enginealignment functionality')
        
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'fusebox':
        #Clicking the middle fuse, wayyyy to complex :)
        m.move(centercoords[0],centercoords[1],True,0.3)
        time.sleep(0.4)
        m.click()
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'leafvent':
        #Move the leaves into the trash vent
        print('Comitting to leaf vent task')
        print('TODO: Add leaf vent functionality')
        
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'leverjob':
        #Pull the lever kronk!
        print('Comitting to leaf vent task')
        print('TODO: Add leverjob functionality')
        
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'navshipup':
        #Drag the navigation ship up
        print('Comitting to leaf vent task')
        print('TODO: Add leaf vent functionality')
        
        k.send('escape')
        time.sleep(1.7)
        return
    elif shorthand == 'navshipdown':
        #Drag the navigation ship down
        print('Comitting to leaf vent task')
        print('TODO: Add leaf vent functionality')
        
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'patternmatcher':
        #Matching blue patterns
        print('Comitting to leaf vent task')
        print('TODO: Add leaf vent functionality')
        
        k.send('escape')
        time.sleep(1.7)
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
        if file == '1_crosshairs.png':
            #This image is always hard to find due to a changing background
            val = ps5.locateCenterOnScreen(rootdir + file, confidence=0.6)
            if not val == None:
                print('Found job for' + file)
                doJob(file, val, rootdir)
                return
            else:
                continue
        else:
            #Pyscreeze is old cheese, piece of broken junk, silly little goose
            val = ps5.locateCenterOnScreen(rootdir + file)
            #Friendship ended with pyscreez, now pyautogui is best friend
            if not val == None:
                print('Found job for' + file)
                doJob(file, val, rootdir)
                return
            else:
                continue
    k.send('escape')
    return

def crewloop():
    m.move(taskcoords[0][0], taskcoords[0][1], True, 0.1)
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
        if frame.getpixel(reportbtncoords) == (220, 37, 0):
            m.move(reportbtncoords[0],reportbtncoords[1])
            m.click()
        #Try to find the active 'use' button
        #Using an absolute position, this location never changes. Using pixel differences to see if ready.
        #Using pixel values is a massive performance boost since we can leave our image object alone
        if frame.getpixel(usebtncoords) == usetuple:#
            print('Found fullwhiteusebtn, clicking...')
            m.move(usebtncoords[0],usebtncoords[1], True, 0.1)
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
    #Using keyboard here instead of waitKey will freeze the rendering
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
    if map == 'skeld':#Determines task and pathfinding searching 
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
