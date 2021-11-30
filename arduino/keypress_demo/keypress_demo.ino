#include <KeyboardLayout.h>
#include <Keyboard.h>

#define BUTTON_PIN 9

void setup() {
  pinMode(BUTTON_PIN, INPUT_PULLUP);

  Keyboard.begin();
}

void loop() {
  if (digitalRead(BUTTON_PIN) == HIGH) {
    Keyboard.press(' ');
    delay(100);
    Keyboard.releaseAll();
    delay(100);
  }
}
