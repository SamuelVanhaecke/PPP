#include <KeyboardLayout.h>
#include <Keyboard.h>

#define BUTTON_1 9
#define BUTTON_2 8

void setup() {
  pinMode(BUTTON_1, INPUT_PULLUP);
  pinMode(BUTTON_2, INPUT_PULLUP);
  Keyboard.begin();
}

void loop() {
  
  if(digitalRead(BUTTON_1) == HIGH) {
    Keyboard.press(0xB0);
    delay(70);    
    Keyboard.releaseAll();
    delay(70);  
  }
  if (digitalRead(BUTTON_2) == HIGH) {
    Keyboard.press(' ');
    delay(70);    
    Keyboard.releaseAll();
    delay(70);                     
  }
}    
