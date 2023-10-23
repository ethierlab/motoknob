static const int buzzerPin = 9;

void setup(void) {
Serial.begin(9600);
pinMode(buzzerPin, OUTPUT);
}

void loop() {

int valeur0 = analogRead(A0);
float voltage= valeur0 * (5.0 / 1023.0);
Serial.println(voltage);
//delay(100);


if (voltage >  4){
tone(buzzerPin, 4000, 200);
}
else if (voltage <   0.5){
tone(buzzerPin, 1000, 200);
} 
 

}  
