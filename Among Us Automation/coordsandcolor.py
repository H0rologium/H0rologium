import mouse as m
import time
import pyautogui as pagui
import keyboard as k
def main():
    while True:
        if m.is_pressed("right"):
            print("Mouse Pressed")
            coords = m.get_position()
            print('Coordinates: ' + str(coords))
            pix = pagui.pixel(coords[0],coords[1])
            print('\nColor: ' +  str(pix))
            time.sleep(0.20)
        if k.is_pressed("q"):
            break


if __name__ == "__main__":
    main()

