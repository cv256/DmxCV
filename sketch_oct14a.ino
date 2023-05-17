// Arduino Nano clone windowsdriver=«USB-SERIAL CH340»   Processor=328P(Old)   Board=«Arduino Duomilanove»   Programmer=«Arduino As ISP»

/* DmxSimple is compatible with the Tinker.it! DMX shield and all known DIY Arduino DMX control circuits.
** DmxSimple is available from: http://code.google.com/p/tinkerit/
** Help and support: http://groups.google.com/group/dmxsimple       */
// Due to the small amount of RAM on 168 and Mega8 Arduinos, only the first 128 channels are supported. 
// Arduinos with processor sockets can easily be upgraded to a 328 to control all 512 channels.
// Timer 2 is used. 
#include <DmxSimple.h>

#define MAXCH 50 

unsigned long waiting=0;

void setup() {
  // put your setup code here, to run once:
  
  DmxSimple.maxChannel(MAXCH);
  DmxSimple.usePin(3);
  
  Serial.begin(9600);

}

void loop() {
  // put your main code here, to run repeatedly:

  if (Serial.available() >= 2) {
    byte channel = Serial.read();

    if (channel>MAXCH) {
      Serial.print("INVALID");
      Serial.println(channel);   
    }
    else {
      byte value = Serial.read();
      DmxSimple.write(channel, value);
      // Serial.print("OK");
      // Serial.print(channel);
      // Serial.print("=");
      // Serial.println(value);
      waiting = 0;
    }

  }
  else if (Serial.available() == 1) {
          waiting += 1;
  }
  
  if (waiting>50000) {
    byte discarded = Serial.read();
    Serial.print("DISCARDED");
    Serial.println(discarded);   
    waiting = 0;
  }

} // ...loop
