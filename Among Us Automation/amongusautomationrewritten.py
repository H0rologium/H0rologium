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
import imutils
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
    inProgress = 'NONE' #Determines if we had a job get interrupted, i.e. by reporting a body
    #---------------------------------------------------------------------
    #initialize job-specific variables
    #note that these coordinates are based on running the game at 1920 x 1200 resolution.
    #centercoords is the x,y coordinates returned from determineTaskList's pyscreeze function
    gascanfillemptybuttoncoords = (1500, 1005)#Could use pagui.locateCenter but right now we're fine with coords (faster)
    asteroidscreenupcheckcoords = (546, 1001)#Makes sure the asteroid task window is still open
    ASTEROIDS_REGION = (501, 200, 890, 889)#Bounding region for asteroid window, x,y,width,height
    ELECTRICAL_RED_PULLSWITCH_COLOR = (255, 98, 0)
    ENGINEALIGNMENT_CENTER = (1300, 592)
    ENGINEALIGNMENT_LOCATIONS = [(1371,212),(1329,328),(1297,448),(1284,575),(1285,692),(1295,794),(1328,906),(1353,995),(1376,1062),(1312, 864),(1286, 694)]
    ENGINEALIGNMENT_COLOR = (66,65,66)
    #Left to right
    ELECTRICAL_RED_PULLSWITCH_LOCATIONS = [(583, 870),(688, 872),(798, 872),(905, 870),(1011, 874),(1118, 875),(1224, 875),(1335, 874)]
    LEAFBLOWERSTARTPOS = (693, 137)
    LEAFVENTCENTER = (483, 561)
    LEVERLOCATION = (1302, 467)
    NAVSHIPSTART = (588, 302)#Upper left corner of the navship screen
    GRIDTOWATCH = []#For matching the blue squares, the location where each 
    BUTTONGRID = []
    COLOREDWIRES = [(38,38,255), (255,0,0), (255,0,255), (255,235,4)]#Blue, Red, Pink and Yellow resp.
    WIRELCOORDS = [(518, 302), (522, 509), (522,716), (523,925)]#Top to bottom left destinations.
    WIRERCOORDS = [(1358,298), (1359, 508), (1358 ,720), (1350, 926)]#Top to bottom right destinations
    SHIELDEDGES = [(696,612), (1205,334),(961,193),(702,327),(953,475),(961,469),(1201,617), (953,758), (719,331), (703,613)]
    SPINWHEELPAIRS = [((1265, 251),(0,0,0),(1266,344)),((1265,556),(0,0,0),(1252,645)),((1262, 850),(0,0,0),(1257,927))]
    #^ For the electrical spinning wheels. The middle entry is to detect when the button should be clicked (the bar only lights up at the right time)
    locs = [(705, 937), (837, 947), (962, 936), (1087, 940), (1210, 939)]#Both locs and testLoc are for test tubes
    testLoc = [(704, 650), (832, 647), (961, 648), (1091, 649), (1210, 650)]
    TESTTUBEORIGIN = (1290,1036)#The square button to press
    #For the reactor bluu squares
    REACTMONITOR = (427, 473, 813, 856)
    LASTLIGHT = [(1482,352),(0,192,0)]#First val is xy, second is rgb value
    #--------------------------------------------------------------------
    
    #strip filename to match method
    shorthand = name.removesuffix('.png')
    #Determine and run job
    #Checks at the end of doJob for any issues
    if not inProgress == 'NONE':
        print(inProgress + ' in progress!')
    else:
        inProgress = shorthand
    #
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
        for location in ENGINEALIGNMENT_LOCATIONS:
            m.move(location[0], location[1])
            pix = ImageGrab.grab().load()[location[0], location[1]]
            if not pix[0] == ENGINEALIGNMENT_COLOR[0] and pix[1] == ENGINEALIGNMENT_COLOR[1]:
                m.press()
                m.move(ENGINEALIGNMENT_CENTER[0],ENGINEALIGNMENT_CENTER[1],True,0.8)
                m.release()
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
        #Surprisingly one of the most complex tasks ever
        m.move(LEAFBLOWERSTARTPOS[0],LEAFBLOWERSTARTPOS[1], 0.6)
        for y in range(0, 13):
            m.move(0, 60, False)
            for x in range(0, 15):
                m.move(50, 0, False)
                pix = ImageGrab.grab().load()[m.get_position()[0], m.get_position()[1]]
                if pix[2] < 100:#Only the leaves have a blue value less than 100
                    print('Found a leaf! with ' + str(pix[0]) + ', ' + str(pix[1]) + ', ' + str(pix[2]) + '.')
                    cords = m.get_position()
                    m.press()
                    m.move(LEAFVENTCENTER[0],LEAFVENTCENTER[1],True,0.2)
                    m.release()
                    m.move(cords[0],cords[1], 0.2)
            m.move(-750, 0, False, 0.1)    
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'leverjob':
        #Pull the lever kronk!
        print('Comitting to lever pulling task')
        m.move(LEVERLOCATION[0], LEVERLOCATION[1])
        m.press()
        m.move(0, 1000, False, 0.4)#Animating here is necessary or the game wont register the lever moving
        time.sleep(3.5)#Have to hold the lever for this timee
        m.release()
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'navshipup' or shorthand == 'navshipdown':
        #Drag the navigation ship up
        print('Comitting to navship task')
        #Find the locations
        POINTS = []
        m.move(NAVSHIPSTART[0], NAVSHIPSTART[1], 0.1)
        x = NAVSHIPSTART[0]
        y = NAVSHIPSTART[1]
        dist = 0
        ship = []
        #Find the ship
        yy = 302
        inc = 12
        m.move(540, 302, True)
        while yy < 890:
            x, yy = m.get_position()
            pix = ImageGrab.grab().load()[x, yy]
            if pix[0] < 40 and pix[0] > 36:
                print('appending the ship at: ' + str(m.get_position()) + str(pix[0]))
                ship.append((m.get_position()[0],m.get_position()[1]))
                break
            m.move(0, inc, False)
            yy = yy + inc
            if yy >= 890:
                if len(ship) == 0:
                    inc = inc / 2
                    yy = 302
                    m.move(540, 302, True)   
        #this task alone has wasted two nights irl. why do i keep working on this
        print(str(ship))
        m.move(580, 302, True)
        while y < 890:
            while x < 1475:
                m.move(18, 0, False)
                dist = dist + 18
                x = m.get_position()[0]
                pix = ImageGrab.grab().load()[x, y]
                if pix[0] < 50 and pix[2] > 160:
                    print('appending : ' + str(pix[0]) + str(m.get_position()))
                    POINTS.append((x,y))
                    
            m.move(-dist, 69, False)
            x = m.get_position()[0]
            dist = 0
            y = m.get_position()[1]
            pix = ImageGrab.grab().load()[x, y]
        #Move the ship through
        m.move(ship[0][0], ship[0][1], True)#To where the ship was originally found
        x, y = m.get_position()
        m.press()
        POINTS.sort(key=lambda x: x[0])
        print(str(POINTS))
        for location in POINTS:
            m.move(location[0], location[1],True, 0.3)
            x, y = m.get_position()
            time.sleep(0.1)
        m.release()
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'wires':
        colorOrder = []
        #Criss crossing the wires
        for cable in WIRELCOORDS:
            m.move(cable[0],cable[1],True,0.2)
            pix = ImageGrab.grab().load()[m.get_position()[0], m.get_position()[1]]
            for color in COLOREDWIRES:
                if pix == color:
                    colorOrder.append((pix ,(m.get_position()[0], m.get_position()[1])))
        print('Color order: ' + str(colorOrder))
        #Now we have the colors in order, we need to match them up!
        #colorOrder values: two tuples: ((color-of-pixel),(coordinateX,coordinateY))
        for leftcable in colorOrder:
            for cables in WIRERCOORDS:
                m.move(cables[0],cables[1],True,0.2)
                pix = ImageGrab.grab().load()[m.get_position()[0], m.get_position()[1]]
                if leftcable[0] == pix:#These lines need to connect
                    m.move(leftcable[1][0],leftcable[1][1])
                    m.press()
                    m.move(cables[0],cables[1],True,0.2)
                    m.release()
        #The task loops one additional time so theres no need to exit or wait
        return
    if shorthand == 'spinnywheels':
        #Clicking the button at the right time
        print('Comitting to the spinny wheel task')
        for paris in SPINWHEELPAIRS:
            m.move(paris[0][0],paris[0][1], True, 0.4)
            while True:
                value = ImageGrab.grab().load()[paris[0][0],paris[0][1]]
                if value != paris[1]:
                    m.move(paris[2][0],paris[2][1])
                    m.click()
                    break
        time.sleep(1.7)
        k.send('escape')
        return
    if shorthand == 'testtubes':
        #Testing the tubes
        print("Starting test tube scanner")
        m.move(TESTTUBEORIGIN[0], TESTTUBEORIGIN[1],True,0.1)
        m.click("left")
        time.sleep(62.5)
        for i in range(4):
            x,y = testLoc[i]
            m.move(x,y,True,0.3)
            color = ImageGrab.grab().load()[x,y]
            if ImageGrab.grab().load()[x,y] == (246,134,134):
                x,y = locs[i]
                m.move(x,y,True,0.4)
                m.click("left")
                break
        time.sleep(1.6)
        print("Scan complete")
        return
    if shorthand == 'scanner':
        #Waiting for scanner
        print('Comitting to waiting for the scanner to finish \'task\'')
        time.sleep(11.5)
        return
    if shorthand == 'patternmatcher':
        #Matching blue patterns
        print('Comitting to pattern matching task')
        #Possibly record each step as an image and use that to click?
        #^ this is kind of what i ended up doing
        while True:
            k.send('escape')
            time.sleep(0.5)
            m.move(usebtncoords[0],usebtncoords[1],True,0.1)
            print('click!')
            m.click()
            time.sleep(1.08)
            spotsToClick = []
            while True:
                val = pagui.locateCenterOnScreen(rootdir + 'square.png', region=REACTMONITOR)
                if not val == None:
                    print('blue square at: ' + str(val))
                    spotsToClick.append(val)
                    time.sleep(0.2)
                else:
                    break
            for cliccer in spotsToClick:
                m.move(cliccer[0] + 650 ,cliccer[1],True,0.2)
                m.click()
            m.move(LASTLIGHT[0][0],LASTLIGHT[0][1], True,0.1)
            if ImageGrab.grab().load()[m.get_position()[0],m.get_position()[1]] == LASTLIGHT[1]:
                break
            else:
                print('onto the next stage of the reactor!')    
        print('Finally, done with the blue square reactor')
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'cleanvent':
        #Cleaning out the sussy vent
        print('Committing to cleaning out the vent')
        m.move(centercoords[0],centercoords[1])
        m.click()
        #We're gonna be reeeal sussy and do this the 'shit' way as they say down south
        x = 512
        y = 205
        m.move(x, y, True, 0.1)
        while y < 983:
            while x < 1412:
                x = x + 70
                m.move(70, 0, False, 0.1)
                m.click()
            m.move(512, y, True, 0.1)
            x = 512
            m.move(0, 90, False, 0.1)
            y = y + 90
            val = pagui.locateOnScreen(rootdir + 'lunchbox.png', grayscale=True)
            if val == None:
                print('Done with the lunchbox!')
                break
        k.send('escape')
        time.sleep(1.7)
        return
    if shorthand == 'shields':
        #Clicking the shield tiles
        print('Comitting to shield task')
        #im still LAUGHING at some of the old methods i tried in the past, including a randomized clicker
        #Some of these index values correspond to the center of the circles. only God knows which..
        for z in range(2):
            #I swear on my yeezys this function went through more iterations than 
            #tyson foods went through chicken poisoners.
            #That single bloody gradient is barely visible WHY WOULD YOU PUT THAT IN THERE???
            #Iteration 47: Moves to each edge, at each edge sees if the color is whiter or more red, if red click
            for i in range(len(SHIELDEDGES)):
                a,b = SHIELDEDGES[i]
                amtWhite = ImageGrab.grab().load()[a,b]
                if amtWhite[1] < 211:
                    m.move(a,b-20,True,0.5)
                    m.click("left")
        k.send('escape')
        time.sleep(1.7)
        return
    #Make sure job didnt get interrupted
    if not pagui.locateOnScreen(os.path.join(os.getcwd() + images + '\\reportedstripes.png')) == None:
        print('Task was interrupted by someone dying')
        return
    else:
        print('Nothing in progress, resetting')
        inProgress = 'NONE'
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
                print('Found job for: ' + file)
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
    m.move(taskcoords[0][0], taskcoords[0][1], True, 0.1)#Compacts the task list
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
