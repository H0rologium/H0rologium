import cv2
# Load image, grayscale, Otsu's threshold, and extract ROI
image = cv2.imread('in.png')
gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
thresh = cv2.threshold(gray, 0, 40, cv2.THRESH_BINARY + cv2.THRESH_OTSU)[1]
x,y,w,h = cv2.boundingRect(thresh)
ROI = image[y:y+h, x:x+w]
cv2.imshow("oof", ROI)
