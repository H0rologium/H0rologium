import mouse
import time
def main():
    loop = True
    while loop:
        if mouse.is_pressed("right"):
            print("Mouse Pressed")
            print(str(mouse.get_position()))
            time.sleep(0.20)
    


if __name__ == "__main__":
    main()

