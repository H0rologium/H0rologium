#import matplotlib.pyplot as plt
#import numpy as np
import pytesseract
import cv2
import mouse as m
import keyboard as k
import pyautogui as pic
import time
import os
from PIL import Image
from PIL import ImageGrab
import pyscreeze
pytesseract.pytesseract.tesseract_cmd = r'C:\\Program Files\\Tesseract-OCR\\tesseract.exe'
trainPath = "C:\\Users\\horo\\Dropbox\\Programming\\Python\\Among Us Automator\\training\\"
isImposter = False
roundOver = False


def get_pixel_color(i_x, i_y):
	import PIL.ImageGrab
	return PIL.ImageGrab.grab().load()[i_x, i_y]
#TASKS------------------------------------------------------------------
def reportJob():
    print("Auto Reporting")
    m.move(1734, 828)
    m.click("left")

def leverJob():
     m.move(1276, 456)
     m.press("left")
     m.move(1276, 817, True, 0.1)
     time.sleep(1.75)
     m.release("left")
     time.sleep(0.5)    

def cardJob():
    m.move(734, 909)
    m.press("left")
    m.move(477, 452, True, 0.7)
    m.release("left")
    time.sleep(0.7)
    m.move(477,452)
    m.press("left")
    m.move(1717, 470, True, 0.4)#Speed needs to be exact
    m.release("left")
    time.sleep(0.4)

def upordownJob():
    m.move(951, 727)
    m.click("left")
    time.sleep(8.2)
    print("Transfer Complete")

def sliderJob():
    xDist = 0
    for i in range(9):
        m.move(580 + xDist,869)
        m.press("left")
        m.move(580 + xDist, 716, True, 0.2)
        m.release("left")
        xDist = i * 110#Distance between each slider
        time.sleep(0.05)

def clickCenter(x, y):
    m.move(x, y)
    m.click("left")

def fuseBox():
    print("Fuse box open")
    #This one is a bit trickier. Need to match colors from both sides and drag to them.
    colors = [(0,0,255), (255,0,0), (255,0,255), (255,235,4)]#Blue, Red, Pink and Yellow resp.
    coords = [(492, 300), (494, 509), (493, 716), (488, 922)]#Top to bottom left destinations.
    rcoords = [(1358,298), (1359, 508), (1358 ,720), (1350, 926)]#Top to bottom right destinations
    repre = ["Blue", "Red", "Pink", "Yellow"]
    currcol = 0
    for i in range(4):#Starts at 1 remember
        for z in range(4):
            a, b = coords[i]
            if get_pixel_color(a,b) == colors[z]:
                print("[Color is " + repre[z] + "]")
                currcol = colors[z]
                break
        x, y = coords[i]        
        m.move(x, y)
        m.press("left")
        for e in range(4):
            a, b = rcoords[e]
            if get_pixel_color(a,b) == currcol:
                print("[Destionation color is " + repre[z] + "]")
                break
        x, y = rcoords[e]
        m.move(x, y, True, 0.2)
        m.release("left")
        time.sleep(0.2)
    time.sleep(0.6)
    value = pyscreeze.locateOnScreen(trainPath + "fuselight.png")#Click fuse in electrical box
    if value != None:
        fuseBox()
    else:
        print("Closing fusebox")

def testJob():
    locs = [(705, 937), (837, 947), (962, 936), (1087, 940), (1210, 939)]
    testLoc = [(704, 650), (832, 647), (961, 648), (1091, 649), (1210, 650)]
    print("Starting test tube scanner")
    m.move(1290,1036)
    m.click("left")
    time.sleep(62.5)
    for i in range(4):
        x,y = testLoc[i]
        m.move(x,y,True,0.3)
        color = get_pixel_color(x,y)
        if get_pixel_color(x,y) == (246,134,134):
            x,y = locs[i]
            m.move(x,y,True,0.4)
            m.click("left")
            break
    time.sleep(1.6)
    print("Scan complete")

def moveCrosshair():
    x,y = pyscreeze.locateCenterOnScreen(trainPath + "crosshairs.png")
    print("Moving crosshair")
    m.move(x,y)
    x,y = (939, 622)#Center of the screen
    m.press("left")
    m.move(x,y,True,0.2)
    m.release("left")
    time.sleep(0.5)
    print("Crosshair moved")

def calibratorM():
    endLoop = False
    time.sleep(0.3)
    print("--Starting Circle 1--")
    while not endLoop:
        value = get_pixel_color(1265, 251)
        if value != (0,0,0):
            m.move(1266, 344)
            m.click("left")
            endLoop = True
    endLoop = False
    print("--Starting Circle 2--")
    while not endLoop:
        value = get_pixel_color(1255, 556)
        if value != (0,0,0):
            m.move(1252,645)
            m.click("left")
            endLoop = True
    endLoop = False
    print("--Starting Circle 3--")
    while not endLoop:
        value = get_pixel_color(1262,850)
        if value != (0,0,0):
            m.move(1257, 927)
            m.click("left")
            endLoop = True
    print("--Task Complete--")

def shields():
    print("**Beginning Shield Operations**")
    edges = [(696,612), (1205,334),(961,193),(702,327),(953,475),(961,469),(1201,617), (953,758), (719,331), (703,613)]
    #Some of these index values correspond to the center of the circles. only God knows which..
    for z in range(2):
        #I swear on my yeezys this function went through more iterations than 
        #tyson foods went through chicken poisoners.
        #That single bloody gradient is barely visible WHY WOULD YOU PUT THAT IN THERE???
        #Iteration 47: Moves to each edge, at each edge sees if the color is whiter or more red, if red click
        for i in range(len(edges)):
            a,b = edges[i]
            amtWhite = get_pixel_color(a,b)
            if amtWhite[1] < 211:
                m.move(a,b-20)
                m.click("left")

def greyButtonJobs(briish):
    print("Holding down a button")
    x,y = pyscreeze.center(briish)
    m.move(x,y,True,0.1)
    m.press("left")
    time.sleep(4)
    m.release("left")

            
def asteroidGame():
    print("Shooting some asteroids: pew pew!")
    x,y = 1252, 180
    gameOver = False
    shots = 0
    m.move(x,y)
    hBonus = 1
    while not gameOver:
        #Scan whole image for asteroid
        while y < 950 and x > 800:
            y += 36
            x -= 15
            m.move(x,y)
            value = get_pixel_color(x,y)
            if value == (55,112,66) or value == (60,125,71) or value == (23,63,46) or value == (33,81,42):
                m.move(x,y)
                m.click("left")
                shots += 1
            if shots > 20 or k.is_pressed("w") or k.is_pressed("a") or k.is_pressed("s") or k.is_pressed("d"):
                return
        y = 180
        x = 1252
        
       
                

                
#-----------------------------------------------------------------------------
#Evaluate to determine jobs
#Check pixel by screenshot dimensions, use screen dimensions for i/o
def evalScreen():
    global trainPath
    value = get_pixel_color(1376, 570)
    if value == (145, 175, 187):#Do we have lever task?
        leverJob()
    value = get_pixel_color(637, 1006)
    if value == (173, 85, 57):#Is admin card?
        cardJob()
    value = get_pixel_color(729, 583)#Click upload or download?
    if value == (241, 212, 161):
        upordownJob()
    #These above methods use the old method of "grabbing screen at that instant, find pixel at x"
    #Below are examples of comparing with 'training' images instead of pixel searching
    value = pyscreeze.locateOnScreen(trainPath + "electricalslider.png")#Slide the red slider in electrical
    if value != None:
       sliderJob()
    value = pyscreeze.locateOnScreen(trainPath + "flare.png")#Click fuse in electrical box
    if value != None:
       valuex, valuey = pyscreeze.center(value)
       clickCenter(valuex, valuey)
    value = pyscreeze.locateOnScreen(trainPath + "fuselight.png")#Click fuse in electrical box
    if value != None:
        fuseBox()
    value = pyscreeze.locateOnScreen(trainPath + "testtubes.png")
    if value != None:
        testJob()
    value = pyscreeze.locateOnScreen(trainPath + "medscanner.png")
    if value != None:
        print("Scanning form...")
        time.sleep(10)
        print("Scan complete")
        return
    value = pyscreeze.locateOnScreen(trainPath + "crosshairs.png")
    if value != None:
        moveCrosshair()
    value = pyscreeze.locateOnScreen(trainPath + "calibrator.png")
    if value != None:
        calibratorM()
    value = pyscreeze.locateOnScreen(trainPath + "shields.png")#I hate this job more than PETA hates strays
    if value != None:#Note to self: never modify this job if you want peace in your life.
        shields()
    value = pyscreeze.locateOnScreen(trainPath + "greybtn.png")
    if value != None:
        greyButtonJobs(value)
    value = get_pixel_color(958,547)
    if value ==(22,73,46):#Asteroid shooting, looking at pixels of crosshairs
        asteroidGame()
    k.send("escape")

#Easier than a loop but 100% hardcoded
def removeAll():
    os.remove("der.png")
    return

#Captures screen for later use
#Captured to read text from, job checking uses active screen
def screnshot(name):
    screenshot = pic.screenshot()
    screenshot.save(name + ".png")
    return
#Gets our screenshot and returns all readable text
def deriveText(filter):
    img = cv2.imread("der.png")
    if filter in pytesseract.image_to_string(img).lower():
        return True
    else:
        return False

#Our code that will capture the screen and check during the round
def roundStart():
    global roundOver
    global isImposter
    while not roundOver:
        value = get_pixel_color(1750, 826)
        if value == (221, 34, 0) and not isImposter:#Should we report?
            reportJob()
        screnshot("der")
        if deriveText("defeat") or deriveText("victory") or deriveText("dead"):
            roundOver = True
            isImposter = False
            print("Round End for Player!")
            input("Press ENTER to start new round")
        value = pyscreeze.locateOnScreen(trainPath + "usekey.png")
        if value != None and get_pixel_color(1781, 982) == (221,221,221):
            x, y = pyscreeze.center(value)
            m.move(x,y)
            m.click("left")
            print("{Opening Task}")
            time.sleep(0.3)
            evalScreen()
        removeAll()
    main()

#Checks if we are the imposter
def imposterCheck():
    global imposternamepath
    global crewnamepath
    global isImposter
    if deriveText("imposter") or deriveText("fake"):
        isImposter = True
        print('[Detected that Imposter is TRUE]')
        return True
    elif deriveText("crewmate") or deriveText("tasks"):
        print('[Detected that Imposter is FALSE]')
        isImposter = False
        return True
    else:
        print('Searching:')
        return False

#Starts the program. When run will automatically begin looking, run at round start
def main():
    global isImposter
    global roundOver
    isImposter = False
    roundOver = False
    print("Waiting for Input")
    while True:
        if k.is_pressed("enter"):
            while not k.is_pressed("escape"):
                screnshot("der")
                if imposterCheck():
                    os.remove("der.png")
                    roundStart()
        

if __name__ == "__main__":
    main()
