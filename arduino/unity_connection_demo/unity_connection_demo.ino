int BUTTON_PIN = 9;
int buttonState = 0;
char myCol[20];
int led = 5;

void setup() {
  Serial.begin(9600);
  pinMode(BUTTON_PIN, INPUT);
}

void loop() {
  //buttonState = digitalRead(BUTTON_PIN);
  //Serial.println(buttonState);

  int lf = 10;
  Serial.readBytesUntil(lf, myCol, 1);
  if(strcmp(myCol,"s")==0){
    digitalWrite(led, HIGH);
    delay(2000);
    digitalWrite(led, LOW);
  }else{
    digitalWrite(led, LOW);
  }
}
